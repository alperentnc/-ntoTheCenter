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
    private bool pause;

    private void Update()
    {
        if (pause)
        {
            Time.timeScale = 0f;
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
    }
    public void PauseGame()
    {
        PausePanel.SetActive(true);
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
    }

    public void CloseLevels()
    {
        LevelsPanel.SetActive(false);
        PausePanel.SetActive(true);
    }
}
