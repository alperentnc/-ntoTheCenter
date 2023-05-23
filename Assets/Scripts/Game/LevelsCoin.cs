using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsCoin : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth playerHealth;
    GameObject player;
    public GameObject spinner;
    public static bool LevelCompleted,count,countOver;
    public static bool gameOverAccepted,levelCompletedAccepted;
    // How much gold the player earns per score point

    public static int totalGold;
    void Start()
    {
        gameOverAccepted = false;
        levelCompletedAccepted = false;
        countOver = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        LevelCompleted = false;
        count = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.isGameOver)
        {
            // Multiply the player's score by the goldPerScore value to calculate the total gold earned
            if (countOver == false)
            {
                totalGold = (PlayerPrefs.GetInt("levelCompleted") * (int)Random.Range(1, 3));
                countOver = true;
                gameOverAccepted = true;
            }
            

            // Add the total gold earned to the player's inventory (you would need to replace this code with whatever logic you have for tracking the player's gold)
            Debug.Log("You earned " + totalGold + " gold!");


            //int currentGold = PlayerPrefs.GetInt("Gold", 0);
            //currentGold += totalGold;
            //PlayerPrefs.SetInt("Gold", currentGold);
            //PlayerPrefs.Save();

            // Disable this script so that it doesn't keep calculating gold after the game is over
            enabled = false;
        }
        else if (LevelCompleted == true)
        {
            if (count == false)
            {
                
                totalGold = PlayerPrefs.GetInt("levelCompleted") * 10;
                Debug.Log(totalGold);
                count = true;
                levelCompletedAccepted = true;
            }
            
            
        }
    }
}
