using UnityEngine;

public class Coin : MonoBehaviour
{
public int value = 1;
private AudioSource audioSource;

private void Start()
{
    audioSource = GetComponent<AudioSource>();
}

private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        GameManager.instance.AddCoins(value);

        if (audioSource != null)
        {
            AudioSource.PlayClipAtPoint(
                audioSource.clip,
                Camera.main.transform.position,
                1f);
        }

        Destroy(gameObject);
    }
}

}
