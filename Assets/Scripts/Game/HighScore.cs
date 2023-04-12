using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text CurrentScoreText;
    public Text HighScoreText;
    public int highscore;
    public int score;
    public Vector2 firstPos;
    public int yDifferance;
    public int firstPosY;
    public PlayerController playerController;
    void Start()
    {
        firstPos = new Vector2(transform.position.x, firstPosY);
        playerController = gameObject.GetComponent<PlayerController>();
        PlayerPrefs.GetInt("score");
        if (PlayerPrefs.GetInt("score") > score)
        {
            PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
        }
        HighScoreText.text = "HighSCORE: " + PlayerPrefs.GetInt("highscore").ToString();
    }
    void Update()
    {
        if (!playerController.isJumping && playerController.IsGrounded())
        {
            yDifferance = Mathf.Abs((int)transform.position.y - firstPosY - 5);
        }
        score = yDifferance * 17 / 4;
        PlayerPrefs.SetInt("score", score);
        CurrentScoreText.text = "Score: " + PlayerPrefs.GetInt("score").ToString();
    }
    
    
}
