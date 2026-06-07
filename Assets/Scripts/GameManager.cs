using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lives = 3;
    public int coins = 0;
    public int savedCoins = 0;

    [Header("Timer")]
    public float levelTime = 90f;

    private float currentTime;

    private TextMeshProUGUI livesText;
    private TextMeshProUGUI coinsText;
    private TextMeshProUGUI timerText;

    private string lastSceneName = "";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            currentTime = levelTime;

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
            return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            GameOver();
        }

        UpdateTimerUI();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Se carregou uma fase diferente da anterior,
        // reinicia o cronômetro da fase.
        if (scene.name != "GameOver" &&
            scene.name != lastSceneName)
        {
            currentTime = levelTime;
        }

        lastSceneName = scene.name;

        FindUI();

        UpdateLivesUI();
        UpdateCoinsUI();
        UpdateTimerUI();
    }

    void FindUI()
    {
        HUDLives hud = FindFirstObjectByType<HUDLives>();

        if (hud != null)
        {
            livesText = hud.livesText;
            coinsText = hud.coinsText;
            timerText = hud.timerText;
        }
    }

    void UpdateLivesUI()
    {
        if (livesText == null)
        {
            FindUI();
        }

        if (livesText != null)
        {
            livesText.text = "Vidas: " + lives;
        }
    }

    void UpdateCoinsUI()
    {
        if (coinsText == null)
        {
            FindUI();
        }

        if (coinsText != null)
        {
            coinsText.text = "Moedas: " + coins;
        }
    }

    void UpdateTimerUI()
    {
        if (timerText == null)
        {
            FindUI();
        }

        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            timerText.text =
                string.Format("{0:00}:{1:00}",
                minutes,
                seconds);
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;

        UpdateCoinsUI();

        Debug.Log("Moedas: " + coins);
    }

    public void SaveCheckpoint()
    {
        savedCoins = coins;

        Debug.Log("Checkpoint salvo. Moedas: " + savedCoins);
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
            coins = savedCoins;

            UpdateCoinsUI();

            RestartLevel();
        }
    }

    void RestartLevel()
    {
        currentTime = levelTime;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ResetGame()
    {
        lives = 3;
        coins = 0;
        savedCoins = 0;

        currentTime = levelTime;

        UpdateLivesUI();
        UpdateCoinsUI();
        UpdateTimerUI();
    }
}