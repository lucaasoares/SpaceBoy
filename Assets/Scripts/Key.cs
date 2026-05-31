using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerKey playerKey =
                other.GetComponent<PlayerKey>();

            playerKey.hasKey = true;

            Destroy(gameObject);
        }
    }
}