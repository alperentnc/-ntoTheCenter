using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinDisplay : MonoBehaviour
{
    public TMP_Text CoinText,DiamondText;
    public int currentGold;
    public int currentDiamond;
    void Start()
    {

    }
    private void Update()
    {

        currentDiamond = PlayerPrefs.GetInt("Diamond", 0);
        currentGold = PlayerPrefs.GetInt("Gold", 0);
        CoinText.text = currentGold.ToString();
        DiamondText.text = currentDiamond.ToString();

    }
}
