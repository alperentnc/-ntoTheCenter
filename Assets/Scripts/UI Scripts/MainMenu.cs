using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject ShopPanel;
    public GameObject SettingsPanel;
    public GameObject LevelsPanel;
    public GameObject LevelMode;
    public GameObject FreeFall;

    public void Play()
    {
        SceneManager.LoadScene("SampleSceneMob");
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
    public void CloseLevels()
    {
        LevelsPanel.SetActive(false);
        LevelMode.SetActive(true);
        FreeFall.SetActive(true);
    }


}
