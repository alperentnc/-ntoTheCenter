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
    public GameObject LevelsPanel;
    public GameObject PlayBtn;
    public GameObject FreeFall;
    public GameObject FreeFallPanel;
    public static int levelCompleted = 1;
    Adds adds;
    public GameObject cam;
    private bool internet = false;
    public static bool diamondPlus, coinPlus;
    void Start()
    {
        StartCoroutine(CheckInternetConnection());
        levelCompleted = PlayerPrefs.GetInt("levelCompleted", 1);
        if (PlayerPrefs.GetInt("levelCompleted") == 0)
        {
            PlayerPrefs.SetInt("levelCompleted", 1);
        }
        adds = cam.GetComponent<Adds>();
    }
    public void PlayLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelCompleted"));
        Time.timeScale = 1.0f;
    }

    public void PlayEndless()
    {
        SceneManager.LoadScene("SampleEndlessScene");

    }
    public void PlayPopUp()
    {
        PlayPanel.SetActive(true);
        PlayBtn.SetActive(false);
    }

    public void Settings()
    {
        SettingsPanel.SetActive(true);
        PlayBtn.SetActive(false);
        FreeFall.SetActive(false);
    }

    public void Power()
    {
        PowerPanel.SetActive(true);
        PlayBtn.SetActive(false);
        FreeFall.SetActive(false);
    }
    public void Levels()
    {
        LevelsPanel.SetActive(true);
        PlayBtn.SetActive(false);
        FreeFall.SetActive(false);
    }
    public void CloseShop()
    {
        PlayPanel.SetActive(false);
        PlayBtn.SetActive(true);
        FreeFall.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
        PlayBtn.SetActive(true);
        FreeFall.SetActive(true);
    }

    public void ClosePower()
    {
        PowerPanel.SetActive(false);
        PlayBtn.SetActive(true);
        FreeFall.SetActive(true);
    }
    public void CloseLevels()
    {
        LevelsPanel.SetActive(false);
        PlayBtn.SetActive(true);
        FreeFall.SetActive(true);
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
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
