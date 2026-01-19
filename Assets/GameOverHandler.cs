using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public PlayerHealth playerHealth; // Kéo Player vào đây
    public GameObject gameOverPanel;  // Kéo cái chữ Game Over Text vào đây

    void OnEnable()
    {
        playerHealth.OnHealthChanged += CheckGameOver;
    }

    void OnDisable()
    {
        playerHealth.OnHealthChanged -= CheckGameOver;
    }

    void CheckGameOver(int currentHealth)
    {
        if (currentHealth <= 0)
        {
            Debug.Log("GAME OVER!");
            // Hiện chữ Game Over lên
            if (gameOverPanel != null) gameOverPanel.SetActive(true);

            // Dừng game (Optional)
            // Time.timeScale = 0; 
        }
    }
}