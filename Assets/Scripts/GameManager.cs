using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lives = 3;

    private TextMeshProUGUI livesText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        FindLivesText();
        UpdateLivesUI();
    }

    void FindLivesText()
    {
        livesText = FindFirstObjectByType<TextMeshProUGUI>();
    }

    void UpdateLivesUI()
    {
        if (livesText == null)
        {
            FindLivesText();
        }

        if (livesText != null)
        {
            livesText.text = "Vidas: " + lives;
        }
    }

    public void LoseLife()
    {
        lives--;

        Debug.Log("Vidas restantes: " + lives);

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Invoke(nameof(UpdateLivesUI), 0.1f);
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");

        lives = 3;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Invoke(nameof(UpdateLivesUI), 0.1f);
    }
}