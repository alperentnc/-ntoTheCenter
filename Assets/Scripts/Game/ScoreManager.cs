using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CloudOnce;
public class ScoreManager : MonoBehaviour
{
    GameObject character; // The Transform component of the character object
    TMP_Text scoreText; // The UI Text component for displaying the current score
    TMP_Text highScoreText; // The UI Text component for displaying the high score

    private float highScore; // The saved high score
    public float currentScore; // The current score

    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("CurrentScore").GetComponent<TMP_Text>();
        highScoreText= GameObject.FindGameObjectWithTag("HighScore").GetComponent<TMP_Text>();
        character = GameObject.FindGameObjectWithTag("Player");
        // Load the saved high score from PlayerPrefs
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
    }

    void Update()
    {
        // Update the current score based on the character's y position
        if (Mathf.Max(0, -(character.transform.position.y - 5) * 17 / 4) > currentScore)
        {
            currentScore = Mathf.Max(0, -(character.transform.position.y - 5) * 17 / 4);
        }
        

        // Update the UI score text
        scoreText.text = "Score: " + Mathf.RoundToInt(currentScore);

        // Update the high score if the current score exceeds it
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetFloat("HighScore", highScore);
            Leaderboards.CoreQuestHighscore.SubmitScore((long) highScore);
        }

        highScoreText.text = "Best: " + Mathf.RoundToInt(highScore);
        //Time.timeScale = 1 + currentScore * 1 / 5000;
    }
}

