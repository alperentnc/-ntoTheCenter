using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Slider slider;
    public int maxHalth = 100;
    public int health = 100;
    public bool isGameOver = false,isLoading;
    Adds adds;

    private const string HealthKey = "PlayerHealth";

    void Start()
    {
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

        // Check if the player has run out of health
        if (health <= 0)
        {
            PlayerController.meteorStarter = false;
            isGameOver = true;
            if (!isLoading)
            {
                isLoading=true;
                adds.LoadFullSize();
            }
            

            //Time.timeScale = 0f;
        }
        else
        {
            isGameOver = false;
            //Time.timeScale = 1f;
        }
    }
}
