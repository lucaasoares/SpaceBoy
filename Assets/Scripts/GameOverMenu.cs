using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        GameManager.instance.ResetGame();

        SceneManager.LoadScene("Fase1");
    }
}