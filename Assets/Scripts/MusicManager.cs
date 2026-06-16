using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    private AudioSource audioSource;

    [Header("Músicas")]
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip winMusic;
    public AudioClip gameOverMusic;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeMusic(AudioClip newMusic)
    {
        if (audioSource.clip == newMusic)
            return;

        audioSource.clip = newMusic;
        audioSource.Play();
    }

    public void PlayMenu()
    {
        ChangeMusic(menuMusic);
    }

    public void PlayGame()
    {
        ChangeMusic(gameMusic);
    }

    public void PlayWin()
    {
        ChangeMusic(winMusic);
    }

    public void PlayGameOver()
    {
        ChangeMusic(gameOverMusic);
    }
}