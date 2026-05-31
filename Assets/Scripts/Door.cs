using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string nextScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerKey playerKey =
                other.GetComponent<PlayerKey>();

            if(playerKey.hasKey)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}