using UnityEngine;

public class CoinManager : MonoBehaviour
{
    ScoreManager scoreManager; // Reference to the ScoreManager script
    PlayerHealth playerHealth;
    public GameObject player;
    public float goldPerScore; // How much gold the player earns per score point

    public int totalGold; // Total gold earned by the player

    void Start()
    {
        scoreManager = player.GetComponent<ScoreManager>();
        playerHealth = player.GetComponent<PlayerHealth>();
        totalGold = 0; // Initialize total gold to zero at the start of the game
    }

    void Update()
    {
        // Check if the game is over (this code assumes the game is over when the ScoreManager's gameOver variable is true)
        if (playerHealth.isGameOver)
        {
            // Multiply the player's score by the goldPerScore value to calculate the total gold earned
            totalGold = Mathf.RoundToInt(scoreManager.currentScore * goldPerScore);

            // Add the total gold earned to the player's inventory (you would need to replace this code with whatever logic you have for tracking the player's gold)
            Debug.Log("You earned " + totalGold + " gold!");

            
            int currentGold = PlayerPrefs.GetInt("Gold", 0);
            currentGold += totalGold;
            PlayerPrefs.SetInt("Gold", currentGold);
            PlayerPrefs.Save();
            
            // Disable this script so that it doesn't keep calculating gold after the game is over
            enabled = false;
        }
    }
}
