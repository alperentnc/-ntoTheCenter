using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverEndless : MonoBehaviour
{
    public GameObject GameOverPanel, Spinner, hp, best, score, pause, settingspanel, pausepanel;
    PlayerHealth playerHealth;
    public CoinManager coinManager;
    GameObject player, enemy, gun, explode, electric, fastmeteor;
    Rigidbody2D rb;
    public GameObject coin;
    public GameObject Duck, Monkey, Pumpkin, Default;
    public TMP_Text CoinText;
    bool test;
    bool scale;
    private int currentGold, random;
    Adds adds;
    public bool tester;
    private void Start()
    {
        currentGold = 0;
        test = false;
        scale = false;
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
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        fastmeteor = GameObject.FindGameObjectWithTag("meteor");
        playerHealth = player.GetComponent<PlayerHealth>();
        coinManager = coin.GetComponent<CoinManager>();
        rb = player.GetComponent<Rigidbody2D>();

    }
    private void Update()
    {



        if (adds == null)
        {
            adds = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Adds>();
        }
        if (adds != null && tester == false)
        {
            adds.LoadFullSize();
            tester = true;
        }
        if (playerHealth.isGameOver)
        {
            GameOver();
        }
        //else
        //{
        //    Time.timeScale = 1.0f;
        //}
        if (scale)
        {
            Time.timeScale = 0f;
        }

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerHealth.freezer = false;
        AudioManager.Instance.PlaySFX("Click");
    }
    public void Settings()
    {
        settingspanel.SetActive(true);
        GameOverPanel.SetActive(false);
        AudioManager.Instance.PlaySFX("Click");
    }
    public void CloseSettings()
    {
        settingspanel.SetActive(false);
        pausepanel.SetActive(true);
        AudioManager.Instance.PlaySFX("Click");
    }
    public void GameOver()
    {
        random = Random.Range(0, 9);
        if (random == 5)
        {
            adds.ShowFullSize();
        }
        if (!test)
        {
            Spinner.SetActive(true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            //enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //fastmeteor.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            score.SetActive(false);
            hp.SetActive(false);
            pause.SetActive(false);
            best.SetActive(false);
            test = true;
        }

    }
    public void Skip()
    {
        PlayerHealth.freezer = true;
        if (!WheelManager.isTook)
        {
            currentGold = PlayerPrefs.GetInt("Gold");
            currentGold += CoinManager.totalGold;
            PlayerPrefs.SetInt("Gold", currentGold);
        }
        Spinner.SetActive(false);
        GameOverPanel.SetActive(true);
        scale = true;
        //if (!test)
        //{
        //    Spinner.SetActive(false);
        //    rb.constraints = RigidbodyConstraints2D.FreezeAll;
        //    enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //    fastmeteor.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //    score.SetActive(false);
        //    hp.SetActive(false);
        //    pause.SetActive(false);
        //    best.SetActive(false);
        //    test = true;
        //}
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        Time.timeScale = 0;
        CoinText.text = "   You Earned: " + CoinManager.totalGold.ToString() + " Coins";
        AudioManager.Instance.PlaySFX("Equip");
    }
    public void RestartGame()
    {
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene("SampleEndlessScene");
        score.SetActive(true);
        hp.SetActive(true);
        pause.SetActive(true);
        best.SetActive(true);
        Time.timeScale = 1.0f;
        AudioManager.Instance.PlaySFX("Click");
    }

}
