using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.lives = 3;
        }

        SceneManager.LoadScene("Fase1");
    }
}