using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverEndless : MonoBehaviour
{
    public GameObject GameOverPanel,Spinner;
    PlayerHealth playerHealth;
    public CoinManager coinManager;
    GameObject player;
    Rigidbody2D rb;
    public GameObject coin;
    public GameObject Duck, Monkey, Pumpkin, Default;
    public TMP_Text CoinText;
    private void Start()
    {
        if (PlayerPrefs.GetInt("equipDuck") == 1)
        {
            Instantiate(Duck, new Vector3(-2, 5.1f, 4), Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("equipMonkey") == 1)
        {
            Instantiate(Monkey, new Vector3(-2, 5.1f, 4), Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("equipPumpkin") == 1)
        {
            Instantiate(Pumpkin, new Vector3(-2, 5.1f, 4), Quaternion.identity);
        }
        else
        {
            Instantiate(Default, new Vector3(-2, 5.1f, 4), Quaternion.identity);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        coinManager = coin.GetComponent<CoinManager>();
        rb = player.GetComponent<Rigidbody2D>();
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
    public void GameOver()
    {
        Spinner.SetActive(true);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void Skip()
    {
        GameOverPanel.SetActive(true);
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        Spinner.SetActive(false);
        CoinText.text = "   You Earned: " + CoinManager.totalGold.ToString() + " Coins";
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
