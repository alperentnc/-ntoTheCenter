using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text HighscoreText;
    public int highscore;
    public Vector2 firstPos;
    public int yDifferance;
    public int firstPosY;
    public PlayerController playerController;
    void Start()
    {
        firstPos = new Vector2(transform.position.x, firstPosY);
        playerController = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        
        if (!playerController.isJumping && playerController.IsGrounded())
        {
            yDifferance = Mathf.Abs((int)transform.position.y - firstPosY - 5);
        }
        int hscore = yDifferance * 17/4;
        HighscoreText.text = hscore.ToString();
    }
}
