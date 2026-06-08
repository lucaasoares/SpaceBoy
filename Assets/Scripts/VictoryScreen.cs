using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public void PlayAgain()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ResetGame();
        }

        SceneManager.LoadScene("Fase1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}