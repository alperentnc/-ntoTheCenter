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
    public GameObject SettingsPanel;
    PlayerHealth playerHealth;
    public LevelsCoin levelsCoin;
    GameObject player;
    Rigidbody2D rb;
    public GameObject coin;
    public TMP_Text CoinTextOver,CoinTextCompleted;
    public bool over,overlevel,levelbool;
    public GameObject Monkey, Duck, Pumpkin, Default;
    private void Start()
    {
        if (PlayerPrefs.GetInt("equipDuck") == 1)
        {
            Instantiate(Duck, new Vector3(-2, 4.9f, 4),Quaternion.identity);
        }
        if (PlayerPrefs.GetInt("equipMonkey") == 1)
        {
            Instantiate(Monkey, new Vector3(-2, 4.9f, 4), Quaternion.identity);
        }
        if (PlayerPrefs.GetInt("equipPumpkin") == 1)
        {
            Instantiate(Pumpkin, new Vector3(-2, 4.9f, 4), Quaternion.identity);
        }
        if (PlayerPrefs.GetInt("equipDefault") == 1)
        {
            Instantiate(Default, new Vector3(-2, 4.9f, 4), Quaternion.identity);
        }
        player = GameObject.FindGameObjectWithTag("Player");
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
    public void SettingsWin()
    {
        SettingsPanel.SetActive(true);
        LevelCompletedPanel.SetActive(false);
    }
    public void CloseSettingsWin()
    {
        SettingsPanel.SetActive(false);
        LevelCompletedPanel.SetActive(true);
    }

    public void SettingsLose()
    {
        SettingsPanel.SetActive(true);
        GameOverPanel.SetActive(false);
    }
    public void CloseSettingsLose()
    {
        SettingsPanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }
}
