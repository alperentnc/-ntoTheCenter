using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject ShopPanel;
    public GameObject SettingsPanel;
    public GameObject PlayButton;

    public void GoToLevels()
    {
        SceneManager.LoadScene("Levels");
    }

    public void Shop()
    {
        ShopPanel.SetActive(true);
        PlayButton.SetActive(false);
    }

    public void Settings()
    {
        SettingsPanel.SetActive(true);
        PlayButton.SetActive(false);
    }
    public void CloseShop()
    {
        ShopPanel.SetActive(false);
        PlayButton.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
        PlayButton.SetActive(true);
    }

}
