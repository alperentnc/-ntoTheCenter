using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject ShopPanel;
    public GameObject SettingsPanel;
    public GameObject LevelMode;
    public GameObject FreeFall;

    public void GoToLevels()
    {
        SceneManager.LoadScene("Levels");
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

}
