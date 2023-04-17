using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelsGameOver : MonoBehaviour
{
    public GameObject Spinner;
    public GameObject GameOverPanel;
    public PlayerHealth playerHealth;
    public LevelsCoin levelsCoin;
    public GameObject player;
    public GameObject coin;
    public TMP_Text CoinText;
    private void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        levelsCoin = coin.GetComponent<LevelsCoin>();
        Time.timeScale = 1.0f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
    public void GameOver()
    {
        Spinner.SetActive(true);     
        Time.timeScale = 0f;  
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
    public void WatchAd()
    {

    }
    public void Skip()
    {
        Spinner.SetActive(false);
        GameOverPanel.SetActive(true);
        CoinText.text = "   You Earned: " + levelsCoin.totalGold.ToString() + " Coins";
    }
}
