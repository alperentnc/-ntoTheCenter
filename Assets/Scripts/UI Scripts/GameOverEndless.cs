using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverEndless : MonoBehaviour
{
    public GameObject GameOverPanel;
    PlayerHealth playerHealth;
    public CoinManager coinManager;
    GameObject player;
    public GameObject coin;
    public TMP_Text CoinText;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        coinManager = coin.GetComponent<CoinManager>();
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        
        CoinText.text ="   You Earned: " + coinManager.totalGold.ToString() + " Coins";
    }
    public void RestartGame()
    {
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene("SampleEndlessScene");
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        if (playerHealth.isGameOver)
        {
            GameOver();
        }
        //else
        //{
        //    Time.timeScale = 1.0f;
        //}

    }
}
