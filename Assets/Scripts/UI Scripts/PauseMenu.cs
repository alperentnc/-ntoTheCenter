using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject LevelsPanel;
    public GameObject PausePanel;
    public Button Pause;

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 0f;
    }
    public void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Levels()
    {
        LevelsPanel.SetActive(true);
        PausePanel.SetActive(false);
    }

    public void CloseLevels()
    {
        LevelsPanel.SetActive(false);
        PausePanel.SetActive(true);
    }
}
