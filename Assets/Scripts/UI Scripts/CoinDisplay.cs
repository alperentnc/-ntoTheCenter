using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinDisplay : MonoBehaviour
{
    public TMP_Text CoinText;
    private int currentGold;
    void Start()
    {
        currentGold = PlayerPrefs.GetInt("Gold", 0);
        CoinText.text = currentGold.ToString();
    }
}
