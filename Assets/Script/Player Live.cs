using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxLives = 5;
    [SerializeField] private GameOverUI gameOverUI;
    [SerializeField] private Image healthBar;
    private int currentLives;

    void Start()
    {
        currentLives = maxLives;
        Time.timeScale = 1f;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentLives -= damage;
        UpdateHealthBar();
        Debug.Log($"Vies restantes: {currentLives}");

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentLives / maxLives;
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.ShowGameOver();
    }
}