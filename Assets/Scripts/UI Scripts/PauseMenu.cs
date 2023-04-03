using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject LevelsPanel;
    public GameObject PausePanel;
    public Button Pause;

    public void PauseGame()
    {
        PausePanel.SetActive(true);
    }

    public void UnPauseGame()
    {
        PausePanel.SetActive(false);
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
