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
    public void Play()
    {
        Debug.Log(Door.levelCompleted);
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelCompleted"));
        Time.timeScale = 1.0f;
    }

    public void FreeFallPopUp()
    {
        SceneManager.LoadScene("SampleEndlessScene");
        //FreeFallPanel.SetActive(true);
        //LevelMode.SetActive(false);
        //FreeFall.SetActive(false);
    }
    //public void CloseFreeFallPopUp()
    //{
    //    FreeFallPanel.SetActive(false);
    //    LevelMode.SetActive(true);
    //    FreeFall.SetActive(true);
    //}
    //public void OpenSpace()
    //{
    //    //SceneManager.LoadScene("");
    //}
    //public void OpenAir()
    //{
    //    //SceneManager.LoadScene("");
    //}
    //public void OpenIce()
    //{
    //    //SceneManager.LoadScene("");
    //}
    //public void OpenStone()
    //{
    //    //SceneManager.LoadScene("");
    //}
    //public void OpenMagma()
    //{
    //    //SceneManager.LoadScene("");
    //}
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


}
