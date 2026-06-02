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

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindLivesText();
        UpdateLivesUI();
    }

    void FindLivesText()
{
    HUDLives hud = FindFirstObjectByType<HUDLives>();

    if (hud != null)
    {
        livesText = hud.livesText;
    }
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

        UpdateLivesUI();

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
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}