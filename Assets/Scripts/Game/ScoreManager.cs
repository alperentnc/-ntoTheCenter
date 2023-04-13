using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Transform character; // The Transform component of the character object
    public Text scoreText; // The UI Text component for displaying the current score
    public Text highScoreText; // The UI Text component for displaying the high score

    private float highScore; // The saved high score
    private float currentScore; // The current score

    void Start()
    {
        // Load the saved high score from PlayerPrefs
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
    }

    void Update()
    {
        // Update the current score based on the character's y position
        if (Mathf.Max(0, -(character.position.y - 5) * 17 / 4) > currentScore)
        {
            currentScore = Mathf.Max(0, -(character.position.y - 5) * 17 / 4);
        }
        

        // Update the UI score text
        scoreText.text = "Score: " + Mathf.RoundToInt(currentScore);

        // Update the high score if the current score exceeds it
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }

        // Update the UI high score text
        highScoreText.text = "High Score: " + Mathf.RoundToInt(highScore);
    }
}

