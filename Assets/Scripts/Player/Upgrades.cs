using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private GameObject[] speedUpgradeBars;
    [SerializeField] private GameObject[] healthUpgradeBars;
    private int currentGold;
    private int currentDiamond;
    [SerializeField] private TMP_Text speedBuyText;
    [SerializeField] private TMP_Text healthBuyText;
    private int currentIndexSpeed = 0;
    private int currentIndexHealth = 0;
    private int savedIndexSpeed;
    private int savedIndexHealth;
    private int savedSpeedBuyValue;
    private int savedHealthBuyValue;

    public GameObject playerEndless;
    public GameObject playerLevel;
    PlayerController playerControllerEndless;
    PlayerController playerControllerLevel;
    PlayerHealth playerHealthEndless;
    PlayerHealth playerHealthLevel;

    private const string HealthKey = "PlayerHealth";
    public int maxHealth;
    void Start()
    {
        if (PlayerPrefs.HasKey(HealthKey))
        {
            maxHealth= PlayerPrefs.GetInt(HealthKey);
        }

        
        playerControllerEndless = playerEndless.GetComponent<PlayerController>();
        playerControllerLevel = playerLevel.GetComponent<PlayerController>();
        playerHealthEndless = playerEndless.GetComponent<PlayerHealth>();
        playerHealthLevel = playerLevel.GetComponent<PlayerHealth>();


        currentGold = PlayerPrefs.GetInt("Gold", 0);
        currentDiamond = PlayerPrefs.GetInt("Diamond", 0);
        savedIndexSpeed = PlayerPrefs.GetInt("IndexSpeed", 0);
        savedIndexHealth = PlayerPrefs.GetInt("IndexHealth", 0);
        savedSpeedBuyValue = PlayerPrefs.GetInt("SpeedBuyValue", int.Parse(speedBuyText.text));
        savedHealthBuyValue = PlayerPrefs.GetInt("HealthBuyValue", int.Parse(healthBuyText.text));

        for (int i = 0; i < savedIndexSpeed; i++)
        {
            speedUpgradeBars[i].SetActive(true);
        }

        for (int i = 0; i < savedIndexHealth; i++)
        {
            healthUpgradeBars[i].SetActive(true);
        }

        currentIndexSpeed = savedIndexSpeed;
        currentIndexHealth = savedIndexHealth;
        speedBuyText.text = savedSpeedBuyValue.ToString();
        healthBuyText.text = savedHealthBuyValue.ToString();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("IndexSpeed", currentIndexSpeed);
        PlayerPrefs.SetInt("IndexHealth", currentIndexHealth);
        PlayerPrefs.SetInt("SpeedBuyValue", int.Parse(speedBuyText.text));
        PlayerPrefs.SetInt("HealthBuyValue", int.Parse(healthBuyText.text));
    }

    public void SpeedUpgrade()
    {
        int currentValue = int.Parse(speedBuyText.text);

        if (currentIndexSpeed < 10 && currentGold >= currentValue)
        {
            Debug.Log(1);
            speedUpgradeBars[currentIndexSpeed].gameObject.SetActive(true);
            currentIndexSpeed++;
            int newValue = currentValue * 2;
            speedBuyText.text = newValue.ToString();
            savedSpeedBuyValue = newValue;
            currentGold -= currentValue;
            PlayerPrefs.SetInt("Gold", currentGold);
            PlayerPrefs.SetInt("IndexSpeed", currentIndexSpeed);
            PlayerPrefs.SetInt("SpeedBuyValue", int.Parse(speedBuyText.text));
            //playerControllerEndless.normalSpeed += 0.3f;
            //playerControllerLevel.normalSpeed += 0.3f;
            //playerControllerEndless.slowSpeed += 0.3f;
            //playerControllerLevel.slowSpeed += 0.3f;

        }
    }

    public void HealthUpgrade()
    {
        int currentValue = int.Parse(healthBuyText.text);

        if (currentIndexHealth < 10 && currentGold >= currentValue)
        {
            healthUpgradeBars[currentIndexHealth].gameObject.SetActive(true);
            currentIndexHealth++;
            int newValue = currentValue * 2;
            healthBuyText.text = newValue.ToString();
            savedHealthBuyValue = newValue;
            currentGold -= currentValue;
            PlayerPrefs.SetInt("Gold", currentGold);

            playerHealthEndless.maxHalth += 10;
            PlayerPrefs.SetInt(HealthKey, playerHealthEndless.maxHalth);
            PlayerPrefs.SetInt("IndexHealth", currentIndexHealth++);
            PlayerPrefs.SetInt("HealthBuyValue", int.Parse(healthBuyText.text));
        }
    }
    public void BuyMonkey()
    {
        if (currentDiamond >= 10)
        {
            currentDiamond -= 10;
            PlayerPrefs.SetInt("Diamond", currentDiamond);
        }
    }
}
