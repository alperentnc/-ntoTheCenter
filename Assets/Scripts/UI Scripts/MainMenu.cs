using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject ShopPanel;
    public GameObject SettingsPanel;
    public GameObject PowerPanel;
    public GameObject LevelsPanel;
    public GameObject LevelMode;
    public GameObject FreeFall;
    public GameObject FreeFallPanel;
    public static int levelCompleted = 1;
    void Start()
    {
        levelCompleted = PlayerPrefs.GetInt("levelCompleted", 1);
        if (PlayerPrefs.GetInt("levelCompleted") == 0)
        {
            PlayerPrefs.SetInt("levelCompleted", 1);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelCompleted"));
        Time.timeScale = 1.0f;
    }

    public void FreeFallPopUp()
    {
        SceneManager.LoadScene("SampleEndlessScene");

    }
    public void Shop()
    {
        ShopPanel.SetActive(true);
        LevelMode.SetActive(false);
        FreeFall.SetActive(false);
    }

    public void Settings()
    {
        SettingsPanel.SetActive(true);
        LevelMode.SetActive(false);
        FreeFall.SetActive(false);
    }

    public void Power()
    {
        PowerPanel.SetActive(true);
        LevelMode.SetActive(false);
        FreeFall.SetActive(false);
    }
    public void Levels()
    {
        LevelsPanel.SetActive(true);
        LevelMode.SetActive(false);
        FreeFall.SetActive(false);
    }
    public void CloseShop()
    {
        ShopPanel.SetActive(false);
        LevelMode.SetActive(true);
        FreeFall.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
        LevelMode.SetActive(true);
        FreeFall.SetActive(true);
    }

    public void ClosePower()
    {
        PowerPanel.SetActive(false);
        LevelMode.SetActive(true);
        FreeFall.SetActive(true);
    }
    public void CloseLevels()
    {
        LevelsPanel.SetActive(false);
        LevelMode.SetActive(true);
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
}
