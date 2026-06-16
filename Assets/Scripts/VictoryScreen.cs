using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class VictoryScreen : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource hoverAudio;

    public void PlayAgain()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ResetGame();
        }

        SceneManager.LoadScene("Fase1");
    }

    public void BackToMenu()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ResetGame();
        }

        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverAudio != null && hoverAudio.clip != null)
        {
            hoverAudio.PlayOneShot(hoverAudio.clip);
        }
    }
}