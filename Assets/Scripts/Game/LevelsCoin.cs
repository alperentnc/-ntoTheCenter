using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsCoin : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth playerHealth;
    public GameObject player;
    // How much gold the player earns per score point

    public int totalGold;
    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.isGameOver)
        {
            // Multiply the player's score by the goldPerScore value to calculate the total gold earned
            totalGold = 5;

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
