using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource hoverAudio;

    public void PlayGame()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Fechando jogo...");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverAudio != null && hoverAudio.clip != null)
        {
            hoverAudio.PlayOneShot(hoverAudio.clip);
        }
    }
}