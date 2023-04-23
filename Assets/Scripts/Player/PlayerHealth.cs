using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Slider slider;
    public int maxHalth = 100;
    public int health = 100;
    public bool isGameOver = false,isLoading;
    Adds adds;
    public static bool freezer;

    private const string HealthKey = "PlayerHealth";

    void Start()
    {
        freezer = false;
        isLoading = false;
        adds = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Adds>();
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        PlayerPrefs.SetInt(HealthKey, health);
        if (PlayerPrefs.GetInt("IndexHealth") == 0)
        {
            PlayerPrefs.SetInt(HealthKey, 100);
        }
        else
        {
            PlayerPrefs.SetInt(HealthKey, (PlayerPrefs.GetInt("IndexHealth")) * 10 + 100);
        }
        // Load the player's health from PlayerPrefs, if it exists
        if (PlayerPrefs.HasKey(HealthKey))
        {
            maxHalth = PlayerPrefs.GetInt(HealthKey);
        }

        health = maxHalth;
        slider.maxValue = maxHalth;
        slider.value = health;
    }

    void Update()
    {
        // Update the health slider
        slider.value = health;
        if (freezer == true)
        {
            Time.timeScale = 0f;
        }
        // Check if the player has run out of health
        if (health <= 0 && Door.levelComplete==false)
        {
            PlayerController.meteorStarter = false;
            isGameOver = true;
            if (!isLoading)
            {
                isLoading=true;
                adds.LoadFullSize();
            }
            

        }
        else
        {
            isGameOver = false;
            //Time.timeScale = 1f;
        }
    }
}
