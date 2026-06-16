using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Door : MonoBehaviour
{
    public string nextScene;
    public Transform enterPoint;

    private Animator animator;
    private AudioSource audioSource;

    private bool isOpen = false;
    private bool isLoading = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OpenDoor()
    {
        if (isOpen)
            return;

        isOpen = true;

        animator.SetBool("HasKey", true);

        // Toca o som da porta abrindo
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isLoading)
            return;

        if (other.CompareTag("Player"))
        {
            PlayerKey playerKey =
                other.GetComponent<PlayerKey>();

            if (playerKey != null && playerKey.hasKey)
            {
                OpenDoor();
                StartCoroutine(PlayerEnterDoor(other.gameObject));
            }
            else
            {
                Debug.Log("Precisa da chave!");
            }
        }
    }

    IEnumerator PlayerEnterDoor(GameObject player)
    {
        PlayerMovement movement =
            player.GetComponent<PlayerMovement>();

        if (movement != null)
        {
            movement.canMove = false;
        }

        float duration = 0.5f;
        float timer = 0f;

        Vector3 startPos = player.transform.position;
        Vector3 targetPos = enterPoint.position;

        while (timer < duration)
        {
            player.transform.position =
                Vector3.Lerp(
                    startPos,
                    targetPos,
                    timer / duration);

            timer += Time.deltaTime;

            yield return null;
        }

        player.transform.position = targetPos;

        player.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        GameManager.instance.SaveCheckpoint();

        SceneManager.LoadScene(nextScene);
    }
}