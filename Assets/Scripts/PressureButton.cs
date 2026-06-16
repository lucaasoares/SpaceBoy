using UnityEngine;

public class PressureButton : MonoBehaviour
{
    public GameObject trapDoor;

    private bool activated = false;

    private Vector3 originalScale;

    private AudioSource audioSource;

    private void Start()
    {
        originalScale = transform.localScale;

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated)
            return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            // Toca o som do botão
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }

            // Afunda o botão
            transform.localScale =
                new Vector3(
                    originalScale.x,
                    originalScale.y * 0.5f,
                    originalScale.z);

            // Abre o alçapão
            TrapDoor door = trapDoor.GetComponent<TrapDoor>();

            if (door != null)
            {
                door.Open();
            }
        }
    }
}