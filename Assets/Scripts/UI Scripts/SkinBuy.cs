using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinBuy : MonoBehaviour
{
    private int currentDiamond;
    public Button DuckBuyer,DuckEquiper,DuckEquiped;
    public Button PumpkinBuyer,PumpkinEquiper,PumpkinEquiped;
    public Button MonkeyBuyer,MonkeyEquiper,MonkeyEquiped;
    public Button DefaultSkinEquiper;
    public int haveDuck, havePumpkin, haveMonkey,equipDuck,equipPumpkin,equipMonkey,equipDefault;
    // Start is called before the first frame update
    void Start()
    {
        currentDiamond = PlayerPrefs.GetInt("Diamond", 0);
        PlayerPrefs.GetInt("haveDuck", 0);
        PlayerPrefs.GetInt("haveMonkey", 0);
        PlayerPrefs.GetInt("havePumpkin", 0);
        PlayerPrefs.GetInt("equipDuck", 0);
        PlayerPrefs.GetInt("equipMonkey", 0);
        PlayerPrefs.GetInt("equipPumpkin", 0);
        PlayerPrefs.GetInt("equipDefault", 0);

    }

    // Update is called once per frame
    void Update()
    {
        currentDiamond = PlayerPrefs.GetInt("Diamond");
        if (PlayerPrefs.GetInt("haveDuck") == 1)
        {
            DuckBuyer.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("haveMonkey") == 1)
        {
            MonkeyBuyer.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("havePumpkin") == 1)
        {
            PumpkinBuyer.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("equipDuck") == 1)
        {
            DuckEquiper.gameObject.SetActive(false);
            DuckEquiped.gameObject.SetActive(true);
            PumpkinEquiped.gameObject.SetActive(false);
            MonkeyEquiped.gameObject.SetActive(false);
            DefaultSkinEquiper.gameObject.SetActive(true);
            PumpkinEquiper.gameObject.SetActive(true);
            MonkeyEquiper.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("equipMonkey") == 1)
        {
            MonkeyEquiper.gameObject.SetActive(false);
            DuckEquiped.gameObject.SetActive(false);
            PumpkinEquiped.gameObject.SetActive(false);
            MonkeyEquiped.gameObject.SetActive(true);
            DefaultSkinEquiper.gameObject.SetActive(true);
            PumpkinEquiper.gameObject.SetActive(true);
            DuckEquiper.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("equipPumpkin") == 1)
        {
            PumpkinEquiper.gameObject.SetActive(false);
            DuckEquiped.gameObject.SetActive(false);
            PumpkinEquiped.gameObject.SetActive(true);
            MonkeyEquiped.gameObject.SetActive(false);
            DefaultSkinEquiper.gameObject.SetActive(true);
            DuckEquiper.gameObject.SetActive(true);
            MonkeyEquiper.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("equipDefault") == 1)
        {
            PumpkinEquiper.gameObject.SetActive(false);
            DuckEquiped.gameObject.SetActive(false);
            PumpkinEquiped.gameObject.SetActive(false);
            MonkeyEquiped.gameObject.SetActive(false);
            DuckEquiper.gameObject.SetActive(true);
            MonkeyEquiper.gameObject.SetActive(true);
            PumpkinEquiper.gameObject.SetActive(true);
        }

    }
    public void DuckBuy()
    {
        if (PlayerPrefs.GetInt("Diamond") >= 10)
        {
            DuckBuyer.gameObject.SetActive(false);
            currentDiamond -= 10;
            PlayerPrefs.SetInt("Diamond", currentDiamond);
            haveDuck = 1;
            PlayerPrefs.SetInt("haveDuck", haveDuck);
            DuckEquiper.gameObject.SetActive(true);

        }
    }
    public void PumpkinBuy()
    {
        if (PlayerPrefs.GetInt("Diamond") >= 10)
        {
            PumpkinBuyer.gameObject.SetActive(false);
            currentDiamond -= 10;
            PlayerPrefs.SetInt("Diamond", currentDiamond);
            havePumpkin = 1;
            PlayerPrefs.SetInt("havePumpkin", havePumpkin);
            PumpkinEquiper.gameObject.SetActive(true);

        }
    }
    public void MonkeyBuy()
    {
        if (PlayerPrefs.GetInt("Diamond") >= 10)
        {
            MonkeyBuyer.gameObject.SetActive(false);
            currentDiamond -= 10;
            PlayerPrefs.SetInt("Diamond", currentDiamond);
            haveMonkey = 1;
            PlayerPrefs.SetInt("haveMonkey", haveMonkey);
            MonkeyEquiper.gameObject.SetActive(true);

        }
    }
    public void MonkeyEquip()
    {
        MonkeyEquiper.gameObject.SetActive(false);
        MonkeyEquiped.gameObject.SetActive(true);
        DuckEquiper.gameObject.SetActive(true);
        PumpkinEquiper.gameObject.SetActive(true);
        DefaultSkinEquiper.gameObject.SetActive(true);
        PlayerPrefs.SetInt("equipMonkey", 1);
        PlayerPrefs.SetInt("equipDuck", 0);
        PlayerPrefs.SetInt("equipPumpkin", 0);
        PlayerPrefs.SetInt("equipDefault", 0);
    }
    public void DuckEquip()
    {
        MonkeyEquiper.gameObject.SetActive(true);
        DuckEquiped.gameObject.SetActive(true);
        PumpkinEquiper.gameObject.SetActive(true);
        DefaultSkinEquiper.gameObject.SetActive(true);
        PlayerPrefs.SetInt("equipMonkey", 0);
        PlayerPrefs.SetInt("equipDuck", 1);
        PlayerPrefs.SetInt("equipPumpkin", 0);
        PlayerPrefs.SetInt("equipDefault", 0);
        DuckEquiper.gameObject.SetActive(false);

    }
    public void PumpkinEquip()
    {
        PumpkinEquiped.gameObject.SetActive(true);
        MonkeyEquiper.gameObject.SetActive(true);
        DuckEquiper.gameObject.SetActive(true);
        PumpkinEquiper.gameObject.SetActive(false);
        DefaultSkinEquiper.gameObject.SetActive(true);
        PlayerPrefs.SetInt("equipMonkey", 0);
        PlayerPrefs.SetInt("equipDuck", 0);
        PlayerPrefs.SetInt("equipDefault", 0);
        PlayerPrefs.SetInt("equipPumpkin", 1);
    }
    public void DefaultEquip()
    {
        MonkeyEquiper.gameObject.SetActive(true);
        DuckEquiper.gameObject.SetActive(true);
        PumpkinEquiper.gameObject.SetActive(true);
        DefaultSkinEquiper.gameObject.SetActive(false);
        PlayerPrefs.SetInt("equipMonkey", 0);
        PlayerPrefs.SetInt("equipDuck", 0);
        PlayerPrefs.SetInt("equipPumpkin", 0);
        PlayerPrefs.SetInt("equipDefault", 1);
    }
}
