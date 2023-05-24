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
    public GameObject FirstLevelCompletedPanel;
    PlayerHealth playerHealth;
    public LevelsCoin levelsCoin;
    GameObject player, hp, index, pause;
    Rigidbody2D rb;
    public GameObject coin;
    public TMP_Text CoinTextOver, CoinTextCompleted, FirstCoinTextCompleted;
    public bool over, overlevel, levelbool, tester,closeWalk;
    public GameObject Monkey, Duck, Pumpkin, Default;
    private int currentGold;
    private int random;
    Adds adds;
    private void Start()
    {
        closeWalk = false;
        tester = false;
        currentGold = 0;
        if (PlayerPrefs.GetInt("equipDuck") == 1)
        {
            Instantiate(Duck, new Vector3(-2, 4.9f, 4), Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("equipMonkey") == 1)
        {
            Instantiate(Monkey, new Vector3(-2, 4.9f, 4), Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("equipPumpkin") == 1)
        {
            Instantiate(Pumpkin, new Vector3(-2, 4.9f, 4), Quaternion.identity);
        }
        else
        {
            Instantiate(Default, new Vector3(-2, 4.9f, 4), Quaternion.identity);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        hp = GameObject.FindGameObjectWithTag("Slider");
        pause = GameObject.FindGameObjectWithTag("pause");
        index = GameObject.FindGameObjectWithTag("upperUI");
        playerHealth = player.GetComponent<PlayerHealth>();
        levelsCoin = coin.GetComponent<LevelsCoin>();
        Time.timeScale = 1.0f;
        rb = player.GetComponent<Rigidbody2D>();
        Spinner.SetActive(false);
        overlevel = false;
    }
    void Update()
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
        if (LevelsCoin.gameOverAccepted && !over)
        {
            GameOver();
            closeWalk = true;
            over = true;
        }
        if (closeWalk == true)
        {
            player.GetComponent<Animator>().SetBool("isWalking", false);
        }
        if (LevelsCoin.levelCompletedAccepted == true && !overlevel)
        {
            LevelsCompleted();
            overlevel = true;
        }
        //else
        //{
        //    Time.timeScale = 1.0f;
        //}

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerHealth.freezer = false;
        AudioManager.Instance.PlaySFX("Click");
    }
    public void GameOver()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        FirstLevelCompletedPanel.SetActive(true);
        FirstCoinTextCompleted.text = "   You Earned: " + LevelsCoin.totalGold.ToString() + " Coins";
        hp.SetActive(false);
        index.SetActive(false);
        pause.SetActive(false);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelCompleted"));
        Time.timeScale = 1;
        AudioManager.Instance.PlaySFX("Click");
    }
    public void Skip()
    {
        FirstLevelCompletedPanel.SetActive(false);
        if (LevelsCoin.LevelCompleted == true)
        {
            PlayerHealth.freezer = true;
            if (!WheelManager.isTook)
            {
                currentGold = PlayerPrefs.GetInt("Gold");
                currentGold += LevelsCoin.totalGold;
                PlayerPrefs.SetInt("Gold", currentGold);
            }
            LevelCompletedPanel.SetActive(true);
            CoinTextCompleted.text = "   You Earned: " + LevelsCoin.totalGold.ToString() + " Coins";
            Spinner.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            PlayerHealth.freezer = true;
            if (!WheelManager.isTook)
            {
                currentGold = PlayerPrefs.GetInt("Gold");
                currentGold += LevelsCoin.totalGold;
                PlayerPrefs.SetInt("Gold", currentGold);
            }
            GameOverPanel.SetActive(true);
            CoinTextOver.text = "   You Earned: " + LevelsCoin.totalGold.ToString() + " Coins";
            Spinner.SetActive(false);
            Time.timeScale = 0;
        }
        AudioManager.Instance.PlaySFX("Equip");
    }
    public void SkipWithoutSpin()
    {
        FirstLevelCompletedPanel.SetActive(false);
        random = Random.Range(0, 9);
        if (random == 6)
        {
            adds.ShowFullSize();
        }
        if (LevelsCoin.LevelCompleted == true)
        {
            PlayerHealth.freezer = true;
            if (!WheelManager.isTook)
            {
                currentGold = PlayerPrefs.GetInt("Gold");
                currentGold += LevelsCoin.totalGold;
                PlayerPrefs.SetInt("Gold", currentGold);
            }
            LevelCompletedPanel.SetActive(true);
            CoinTextCompleted.text = "   You Earned: " + LevelsCoin.totalGold.ToString() + " Coins";
            Spinner.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            PlayerHealth.freezer = true;
            if (!WheelManager.isTook)
            {
                currentGold = PlayerPrefs.GetInt("Gold");
                currentGold += LevelsCoin.totalGold;
                PlayerPrefs.SetInt("Gold", currentGold);
            }
            GameOverPanel.SetActive(true);
            CoinTextOver.text = "   You Earned: " + LevelsCoin.totalGold.ToString() + " Coins";
            Spinner.SetActive(false);
            Time.timeScale = 0;
        }
        AudioManager.Instance.PlaySFX("Click");
    }
    public void LevelsCompleted()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        FirstLevelCompletedPanel.SetActive(true);
        FirstCoinTextCompleted.text = "   You Earned: " + LevelsCoin.totalGold.ToString() + " Coins";
        hp.SetActive(false);
        index.SetActive(false);
        pause.SetActive(false);


    }
    public void LevelsCompletedSpin()
    {
        FirstLevelCompletedPanel.SetActive(false);
        Spinner.SetActive(true);
        AudioManager.Instance.PlaySFX("Click");
    }
    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.Instance.PlaySFX("Click");
    }
    public void SettingsWin()
    {
        SettingsPanel.SetActive(true);
        LevelCompletedPanel.SetActive(false);
        AudioManager.Instance.PlaySFX("Click");
    }
    public void CloseSettingsWin()
    {
        SettingsPanel.SetActive(false);
        LevelCompletedPanel.SetActive(true);
        AudioManager.Instance.PlaySFX("Click");
    }

    public void SettingsLose()
    {
        SettingsPanel.SetActive(true);
        GameOverPanel.SetActive(false);
        AudioManager.Instance.PlaySFX("Click");
    }
    public void CloseSettingsLose()
    {
        SettingsPanel.SetActive(false);
        GameOverPanel.SetActive(true);
        AudioManager.Instance.PlaySFX("Click");
    }
}
