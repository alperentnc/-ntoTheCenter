using UnityEngine;

public class CoinManager : MonoBehaviour
{
    ScoreManager scoreManager; // Reference to the ScoreManager script
    PlayerHealth playerHealth;
    GameObject player;
    public float goldPerScore; // How much gold the player earns per score point

    public static int totalGold; // Total gold earned by the player
    public static bool gameOverAccepted;
    void Start()
    {
        gameOverAccepted = false;
        player = GameObject.FindGameObjectWithTag("Player");
        scoreManager = player.GetComponent<ScoreManager>();
        playerHealth = player.GetComponent<PlayerHealth>();
        totalGold = 0; // Initialize total gold to zero at the start of the game
    }

    void Update()
    {   
        if (playerHealth.isGameOver)
        {
            totalGold = Mathf.RoundToInt(scoreManager.currentScore * goldPerScore);
            gameOverAccepted = true;



            int currentGold = PlayerPrefs.GetInt("Gold", 0);
            
            // Disable this script so that it doesn't keep calculating gold after the game is over
            enabled = false;
        }
    }
}
