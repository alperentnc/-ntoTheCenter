using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject PlayPanel;
    public GameObject SettingsPanel;
    public GameObject PowerPanel;
    public GameObject AchievementsPanel;
    public GameObject PlayBtn;
    public GameObject FreeFall;
    public GameObject FreeFallPanel;
    public GameObject LeaderBoardPanel;
    public static int levelCompleted = 1;
    Adds adds;
    public GameObject cam;
    private bool internet = false;
    public static bool diamondPlus, coinPlus;
    PlayFabManager playFabManager;

    void Start()
    {
        playFabManager = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<PlayFabManager>();
        StartCoroutine(CheckInternetConnection());
        levelCompleted = PlayerPrefs.GetInt("levelCompleted", 1);
        if (PlayerPrefs.GetInt("levelCompleted") == 0)
        {
            PlayerPrefs.SetInt("levelCompleted", 1);
        }
        adds = cam.GetComponent<Adds>();
        AudioManager.Instance.PlayMusic("Menu");


        playFabManager.SendLeaderboard((int)PlayerPrefs.GetFloat("HighScore"));
    }
    public void PlayLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelCompleted"));
        Time.timeScale = 1.0f;
        AudioManager.Instance.PlaySFX("Click");
    }

    public void PlayEndless()
    {
        SceneManager.LoadScene("SampleEndlessScene");
        AudioManager.Instance.PlaySFX("Click");
        

    }
    public void PlayPopUp()
    {
        PlayPanel.SetActive(true);
        PlayBtn.SetActive(false);
        AudioManager.Instance.PlaySFX("Click");
    }

    public void Settings()
    {
        SettingsPanel.SetActive(true);
        PlayBtn.SetActive(false);
        FreeFall.SetActive(false);
        AudioManager.Instance.PlaySFX("Click");
    }

    public void Power()
    {
        PowerPanel.SetActive(true);
        PlayBtn.SetActive(false);
        FreeFall.SetActive(false);
        AudioManager.Instance.PlaySFX("Click");
    }
    public void Achievements()
    {
        AchievementsPanel.SetActive(true);
        PlayBtn.SetActive(false);
        FreeFall.SetActive(false);
        AudioManager.Instance.PlaySFX("Click");
    }
    public void CloseShop()
    {
        PlayPanel.SetActive(false);
        PlayBtn.SetActive(true);
        FreeFall.SetActive(true);
        AudioManager.Instance.PlaySFX("Click");
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
        PlayBtn.SetActive(true);
        FreeFall.SetActive(true);
        AudioManager.Instance.PlaySFX("Click");
    }

    public void ClosePower()
    {
        PowerPanel.SetActive(false);
        PlayBtn.SetActive(true);
        FreeFall.SetActive(true);
        AudioManager.Instance.PlaySFX("Click");
    }
    public void CloseLeaderBoard()
    {
        LeaderBoardPanel.SetActive(false);
        AudioManager.Instance.PlaySFX("Click");
    }
    public void CloseAchievements()
    {
        AchievementsPanel.SetActive(false);
        PlayBtn.SetActive(true);
        FreeFall.SetActive(true);
        AudioManager.Instance.PlaySFX("Click");
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        AudioManager.Instance.PlaySFX("Click");
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
        AudioManager.Instance.PlaySFX("Click");
    }
    
    IEnumerator CheckInternetConnection()
    {
        UnityWebRequest request = new UnityWebRequest("http://google.com");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            internet = false;
        }
        else
        {
            internet = true;
        }
    }
    public void AddforDiamond()
    {

        if (internet)
        {
            adds.ShowRewardedAd();
            diamondPlus = true;
        }
        else if (!internet)
        {
            Debug.Log("intyokrewarded");
        }
    }
    public void AddforCoin()
    {
        if (internet)
        {
            adds.ShowRewardedAd();
            coinPlus = true;
        }
        else if (!internet)
        {
            Debug.Log("intyokrewarded");
        }
    }
   
}
