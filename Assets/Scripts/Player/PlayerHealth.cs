using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

	public Slider slider;
    public int health=100;
    public bool isGameOver = false;

   void Update()
    {
        slider.value = health;
        if (health<=0)
        {
            PlayerController.meteorStarter = false;
            isGameOver = true;
        }
        else
        {
            isGameOver = false;
        }
    }
}