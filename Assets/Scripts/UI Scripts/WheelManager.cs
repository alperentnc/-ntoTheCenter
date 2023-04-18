using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WheelManager : MonoBehaviour {

    //Creates the wheel
    SpinWheel wheel = new SpinWheel(8);
    int money = 2500;
    public GameObject go;
    //public Text text;
    public Text winT;
    public bool oneTime;

    void Start () {
        oneTime = false;
        int currentGold = PlayerPrefs.GetInt("Gold", 0);
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
                    winT.text = "1.2x";
                    Debug.Log(LevelsCoin.totalGold);
                    break;
                case 2:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 1.4f);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "1.4x";
                    Debug.Log(LevelsCoin.totalGold);
                    break;
                case 3:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 1.8f);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "Diamond";
                    Debug.Log(LevelsCoin.totalGold);
                    break;
                case 4:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 1.6f);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "1.6x";
                    Debug.Log(LevelsCoin.totalGold);
                    break;
                case 5:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 1.8f);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "1.8x";
                    Debug.Log(LevelsCoin.totalGold);
                    break;
                case 6:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 2);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "2x";
                    Debug.Log(LevelsCoin.totalGold);
                    break;
                case 7:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 3);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "3x";
                    Debug.Log(LevelsCoin.totalGold);
                    break;
                case 8:
                    LevelsCoin.totalGold = (int)(LevelsCoin.totalGold * 4);
                    currentGold += LevelsCoin.totalGold;
                    PlayerPrefs.SetInt("Gold", currentGold);
                    PlayerPrefs.Save();
                    winT.text = "4x";
                    Debug.Log(LevelsCoin.totalGold);
                    break;
            }
            UpdateText();
        });
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
            
    }

    public void ok()
    {
        go.SetActive(false);
    }
}
