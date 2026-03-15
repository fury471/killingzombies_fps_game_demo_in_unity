using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public string mainMenuSceneName = "MainMenu";

    public int requiredMedicines = 2;
    public int requiredFiles = 2;

    public int collectedMedicines = 0;
    public int collectedFiles = 0;

    private bool gameEnded = false;

    void Start()
    {
        Time.timeScale = 1f;

        collectedMedicines = 0;
        collectedFiles = 0;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
            return;
        }

        if (gameEnded)
        {
            return;
        }

        if (playerHealth != null && playerHealth.currentHealth <= 0)
        {
            LoseGame();
        }
    }

    public void CollectMedicine()
    {
        if (!gameEnded)
        {
            collectedMedicines++;
        }
    }

    public void CollectFile()
    {
        if (!gameEnded)
        {
            collectedFiles++;
        }
    }

    public bool HasAllObjectives()
    {
        return collectedMedicines >= requiredMedicines &&
               collectedFiles >= requiredFiles;
    }

    public void WinGame()
    {
        if (gameEnded)
        {
            return;
        }

        gameEnded = true;

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }

        EndGame();
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    void LoseGame()
    {
        if (gameEnded)
        {
            return;
        }

        gameEnded = true;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        EndGame();
    }

    void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}
