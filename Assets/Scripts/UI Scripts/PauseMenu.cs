using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject SettingsPanel;
    public GameObject PausePanel;
    public Button Pause;
    public static bool pause;

    private void Update()
    {
        if (pause)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
        }
        else if (!pause)
        {
            Time.timeScale = 1f;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
        pause = false;
    }
    public void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }

    public void UnPauseGame()
    {
        PausePanel.SetActive(false);
        pause = false;
    }
    public void RestartGame()
    {
        PausePanel.SetActive(false);
        SceneManager.LoadScene("SampleEndlessScene");
        Time.timeScale = 1.0f;
        pause = false;
    }

    public void Settings()
    {
        SettingsPanel.SetActive(true);
        PausePanel.SetActive(false);
    }
    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
        PausePanel.SetActive(true);
    }

}
