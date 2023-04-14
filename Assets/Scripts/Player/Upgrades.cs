using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private GameObject[] speedUpgradeBars;
    [SerializeField] private GameObject[] healthUpgradeBars;
    public CoinDisplay coinDisplay;
    [SerializeField] private TMP_Text speedBuyText;
    [SerializeField] private TMP_Text healthBuyText;

    void Start()
    {
        coinDisplay = GetComponent<CoinDisplay>();
    }

    
    void Update()
    {
        
    }
    void SpeedUpgrade()
    {
        
        for (int i = 0; i < 9; i++)
        {
            
        }
    }
    
    void HealthUpgrade()
    {

    }
}
