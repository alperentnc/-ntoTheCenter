using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WheelManager : MonoBehaviour {

    //Creates the wheel
    SpinWheel wheel = new SpinWheel(8);
    GameObject watchAdder,spinner;
    private int diamondValue;
    public GameObject go;
    //public Text text;
    public Text winT;
    public bool oneTime,isShowing;
    Adds adds;

    void Start () {
        spinner = GameObject.FindGameObjectWithTag("Spinner");
        watchAdder = GameObject.FindGameObjectWithTag("WatchAdder");
        oneTime = false;
        int currentGold = PlayerPrefs.GetInt("Gold", 0);
        adds = GetComponent<Adds>();
        //Keep track of the player money
        UpdateText();

        //Sets the gameobject
        wheel.setWheel(gameObject);

        //Sets the callback
        wheel.AddCallback((index) => {
            switch (index)
            {
                case 1:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 1.2f);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "You earned 1.2X gold";
                    break;
                case 2:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 1.4f);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "You earned 1.4X gold";
                    break;
                case 3:
                    winT.text = "You earned a Diamond";
                    diamondValue = PlayerPrefs.GetInt("Diamond");
                    diamondValue += 1;
                    PlayerPrefs.SetInt("Diamond", diamondValue);
                    break;
                case 4:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 1.6f);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "You earned 1.6X gold";
                    break;
                case 5:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 1.8f);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "You earned 1.8X gold";
                    break;
                case 6:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 2);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "You earned 2X gold";
                    break;
                case 7:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 3);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "You earned 3X gold";
                    break;
                case 8:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 4);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "You earned 4X gold";
                    break;
            }
            UpdateText();
        });
	}
    void Update()
    {
        if (adds == null)
        {
            adds = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Adds>();
        }
    }

    public void UpdateText()
    {
        //text.text = money + "";
    }

    public void OkWin()
    {
        //win.SetActive(false);
    }

    public void Spin()
    {

            StartCoroutine(wheel.StartNewRun());
            UpdateText();
            go.SetActive(false);
            spinner.SetActive(false);
            
    }
    public void WatchAd()
    {
        adds.LoadFullSize();
        watchAdder.SetActive(false);
    }

    public void ok()
    {
        go.SetActive(false);
    }
}
