using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelsGameOver : MonoBehaviour
{
    public GameObject Spinner;
    public GameObject GameOverPanel;
    public GameObject LevelCompletedPanel;
    public PlayerHealth playerHealth;
    public LevelsCoin levelsCoin;
    public GameObject player;
    Rigidbody2D rb;
    public GameObject coin;
    public TMP_Text CoinTextOver,CoinTextCompleted;
    public bool over,overlevel,levelbool;
    private void Start()
    {

        playerHealth = player.GetComponent<PlayerHealth>();
        levelsCoin = coin.GetComponent<LevelsCoin>();
        Time.timeScale = 1.0f;
        rb = player.GetComponent<Rigidbody2D>();
        Spinner.SetActive(false);
        overlevel = false;
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
    private void Update()
    {
        if (playerHealth.isGameOver&&!over)
        {
            GameOver();
            over = true;
        }
        if (LevelsCoin.LevelCompleted == true&& !overlevel)
        {
            LevelsCompleted();
            overlevel = true;
        }
        //else
        //{
        //    Time.timeScale = 1.0f;
        //}

    }
    public void NextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelCompleted"));
        Time.timeScale = 1;
    }
    public void Skip()
    {
        
        if (LevelsCoin.LevelCompleted == true)
        {
            LevelCompletedPanel.SetActive(true);
            CoinTextCompleted.text = "   You Earned: " + LevelsCoin.totalGold.ToString() + " Coins";
            Spinner.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            GameOverPanel.SetActive(true);
            CoinTextOver.text = "   You Earned: " + LevelsCoin.totalGold.ToString() + " Coins";
            Spinner.SetActive(false);
            Time.timeScale = 0;
        }

    }
    public void LevelsCompleted()
    {
        Spinner.SetActive(true);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
