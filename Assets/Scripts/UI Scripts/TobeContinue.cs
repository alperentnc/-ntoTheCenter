using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TobeContinue : MonoBehaviour
{
    public GameObject Continue;
    public void CloseContinue()
    {
        Continue.SetActive(false);
    }

    public void Endless()
    {
        SceneManager.LoadScene("SampleEndlessScene");

    }
}
