using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button retryButton;
    private bool isGameOver = false;

    void Start()
    {
        gameOverPanel.SetActive(false);
        retryButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Return))
        {
            RestartGame();
        }
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        isGameOver = true;
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}