using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Achievements : MonoBehaviour
{
    private int diamondValue;
    private int coinValue;
    public Button[] buttons;
    public Image[] locks;

    private void Start()
    {
        PlayerPrefs.GetInt("Coin100", 0);
        PlayerPrefs.GetInt("Diammond2a", 0);
        PlayerPrefs.GetInt("Diammond3a", 0);
        PlayerPrefs.GetInt("Diammond5a", 0);
        PlayerPrefs.GetInt("Diammond7", 0);
        PlayerPrefs.GetInt("Diammond10", 0);
        PlayerPrefs.GetInt("Coin300", 0);
        PlayerPrefs.GetInt("Diammond2b", 0);
        PlayerPrefs.GetInt("Diammond3b", 0);
        PlayerPrefs.GetInt("Diammond5b", 0);
        PlayerPrefs.GetInt("Diammond1a", 0);
        PlayerPrefs.GetInt("Diammond3c", 0);
        PlayerPrefs.GetInt("Diammond5c", 0);
        PlayerPrefs.GetInt("Diammond1b", 0);
        PlayerPrefs.GetInt("Diammond3d", 0);
        PlayerPrefs.GetInt("Diammond5d", 0);

        //kazan�nca buton b�y�y�p k���ls�n:
        if (PlayerPrefs.GetFloat("HighScore") >= 250 && PlayerPrefs.GetInt("Coin100") == 0)
        {
            
            buttons[0].animator.SetBool("Highlighted", true);
        }

        if (PlayerPrefs.GetFloat("HighScore") >= 500 && PlayerPrefs.GetInt("Diammond2a") == 0)
        {
            buttons[1].animator.SetBool("Highlighted", true);
        }
        

        if (PlayerPrefs.GetFloat("HighScore") >= 1000 && PlayerPrefs.GetInt("Diammond3a") == 0)
        {
            buttons[2].animator.SetBool("Highlighted", true);
        }
        
        if (PlayerPrefs.GetFloat("HighScore") >= 1500 && PlayerPrefs.GetInt("Diammond5a") == 0)
        {
            buttons[3].animator.SetBool("Highlighted", true);
        }
       
        if (PlayerPrefs.GetFloat("HighScore") >= 2000 && PlayerPrefs.GetInt("Diammond7") == 0)
        {
            buttons[4].animator.SetBool("Highlighted", true);
        }
        
        if (PlayerPrefs.GetFloat("HighScore") >= 2500 && PlayerPrefs.GetInt("Diammond10") == 0)
        {
            buttons[5].animator.SetBool("Highlighted", true);
        }

        if (PlayerPrefs.GetInt("levelCompleted") - 1 >= 5 && PlayerPrefs.GetInt("Coin300") == 0)
        {
            buttons[6].animator.SetBool("Highlighted", true);
        }
        
        if (PlayerPrefs.GetInt("levelCompleted") - 1 >= 10 && PlayerPrefs.GetInt("Diammond2b") == 0)
        {
            buttons[7].animator.SetBool("Highlighted", true);
        }
        
        if (PlayerPrefs.GetInt("levelCompleted") - 1 >= 15 && PlayerPrefs.GetInt("Diammond3b") == 0)
        {
            buttons[8].animator.SetBool("Highlighted", true);
        }
        
        if (PlayerPrefs.GetInt("levelCompleted") - 1 >= 20 && PlayerPrefs.GetInt("Diammond5b") == 0)
        {
            buttons[9].animator.SetBool("Highlighted", true);
        }
        
        if (PlayerPrefs.GetInt("IndexSpeed") >= 3 && PlayerPrefs.GetInt("Diammond1a") == 0)
        {
            buttons[10].animator.SetBool("Highlighted", true);
        }
        
        if (PlayerPrefs.GetInt("IndexSpeed") >= 6 && PlayerPrefs.GetInt("Diammond3c") == 0)
        {
            buttons[11].animator.SetBool("Highlighted", true);
        }
        
        if (PlayerPrefs.GetInt("IndexSpeed") >= 10 && PlayerPrefs.GetInt("Diammond5c") == 0)
        {
            buttons[12].animator.SetBool("Highlighted", true);
        }
        
        if (PlayerPrefs.GetInt("IndexHealth") >= 3 && PlayerPrefs.GetInt("Diammond1b") == 0)
        {
            buttons[13].animator.SetBool("Highlighted", true);
        }
        
        if (PlayerPrefs.GetInt("IndexHealth") >= 6 && PlayerPrefs.GetInt("Diammond3d") == 0)
        {
            buttons[14].animator.SetBool("Highlighted", true);
        }
        
        if (PlayerPrefs.GetInt("IndexHealth") >= 10 && PlayerPrefs.GetInt("Diammond5d") == 0)
        {
            buttons[15].animator.SetBool("Highlighted", true);
        }

    }


    void Update()
    {
        
        if (PlayerPrefs.GetFloat("HighScore") >= 250 && PlayerPrefs.GetInt("Coin100") == 0)
        {
            buttons[0].interactable = true;
        }
        else
        {
            buttons[0].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Coin100") != 0)
        {
            locks[0].enabled = false;
        }

        if (PlayerPrefs.GetFloat("HighScore") >= 500 && PlayerPrefs.GetInt("Diammond2a") == 0)
        {
            buttons[1].interactable = true;
        }
        else
        {
            buttons[1].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond2a") != 0)
        {
            locks[1].enabled = false;
        }

        if (PlayerPrefs.GetFloat("HighScore") >= 1000 && PlayerPrefs.GetInt("Diammond3a") == 0)
        {
            buttons[2].interactable = true;
        }
        else
        {
            buttons[2].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond3a") != 0)
        {
            locks[2].enabled = false;
        }
        if (PlayerPrefs.GetFloat("HighScore") >= 1500 && PlayerPrefs.GetInt("Diammond5a") == 0)
        {
            buttons[3].interactable = true;
        }
        else
        {
            buttons[3].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond5a") != 0)
        {
            locks[3].enabled = false;
        }
        if (PlayerPrefs.GetFloat("HighScore") >= 2000 && PlayerPrefs.GetInt("Diammond7") == 0)
        {
            buttons[4].interactable = true;
        }
        else
        {
            buttons[4].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond7") != 0)
        {
            locks[4].enabled = false;
        }
        if (PlayerPrefs.GetFloat("HighScore") >= 2500 && PlayerPrefs.GetInt("Diammond10") == 0)
        {
            buttons[5].interactable = true;
        }
        else
        {
            buttons[5].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond10") != 0)
        {
            locks[5].enabled = false;
        }
        if (PlayerPrefs.GetInt("levelCompleted") - 1 >= 5 && PlayerPrefs.GetInt("Coin300") == 0)
        {
            buttons[6].interactable = true;
        }
        else
        {
            buttons[6].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Coin300") != 0)
        {
            locks[6].enabled = false;
        }
        if (PlayerPrefs.GetInt("levelCompleted") - 1 >= 10 && PlayerPrefs.GetInt("Diammond2b") == 0)
        {
            buttons[7].interactable = true;
        }
        else
        {
            buttons[7].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond2b") != 0)
        {
            locks[7].enabled = false;
        }
        if (PlayerPrefs.GetInt("levelCompleted") - 1 >= 15 && PlayerPrefs.GetInt("Diammond3b") == 0)
        {
            buttons[8].interactable = true;
        }
        else
        {
            buttons[8].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond3b") != 0)
        {
            locks[8].enabled = false;
        }
        if (PlayerPrefs.GetInt("levelCompleted") - 1 >= 20 && PlayerPrefs.GetInt("Diammond5b") == 0)
        {
            buttons[9].interactable = true;
        }
        else
        {
            buttons[9].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond5b") != 0)
        {
            locks[9].enabled = false;
        }
        if (PlayerPrefs.GetInt("IndexSpeed") >= 3 && PlayerPrefs.GetInt("Diammond1a") == 0)
        {
            buttons[10].interactable = true;
        }
        else
        {
            buttons[10].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond1a") != 0)
        {
            locks[10].enabled = false;
        }
        if (PlayerPrefs.GetInt("IndexSpeed") >= 6 && PlayerPrefs.GetInt("Diammond3c") == 0)
        {
            buttons[11].interactable = true;
        }
        else
        {
            buttons[11].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond3c") != 0)
        {
            locks[11].enabled = false;
        }
        if (PlayerPrefs.GetInt("IndexSpeed") >= 10 && PlayerPrefs.GetInt("Diammond5c") == 0)
        {
            buttons[12].interactable = true;
        }
        else
        {
            buttons[12].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond5c") != 0)
        {
            locks[12].enabled = false;
        }
        if (PlayerPrefs.GetInt("IndexHealth") >= 3 && PlayerPrefs.GetInt("Diammond1b") == 0)
        {
            buttons[13].interactable = true;
        }
        else
        {
            buttons[13].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond1b") != 0)
        {
            locks[13].enabled = false;
        }
        if (PlayerPrefs.GetInt("IndexHealth") >= 6 && PlayerPrefs.GetInt("Diammond3d") == 0)
        {
            buttons[14].interactable = true;
        }
        else
        {
            buttons[14].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond3d") != 0)
        {
            locks[14].enabled = false;
        }
        if (PlayerPrefs.GetInt("IndexHealth") >= 10 && PlayerPrefs.GetInt("Diammond5d") == 0)
        {
            buttons[15].interactable = true;
        }
        else
        {
            buttons[15].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Diammond5d") != 0)
        {
            locks[15].enabled = false;
        }
    }

    public void Diamond1a()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 1;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond1a", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
        
    }
    public void Diamond1b()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 1;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond1b", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");

    }
    public void Diamond2a()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 2;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond2a", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }
    public void Diamond2b()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 2;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond2b", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }
    public void Diamond3a()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 3;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond3a", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }
    public void Diamond3b()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 3;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond3b", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }
    public void Diamond3c()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 3;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond3c", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }
    public void Diamond3d()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 3;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond3d", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }
    public void Diamond5a()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 5;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond5a", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }
    public void Diamond5b()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 5;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond5b", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }
    public void Diamond5c()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 5;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond5c", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }
    public void Diamond5d()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 5;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond5d", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }
    public void Diamond7()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 7;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond7", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }
    public void Diamond10()
    {
        diamondValue = PlayerPrefs.GetInt("Diamond");
        diamondValue += 10;
        PlayerPrefs.SetInt("Diamond", diamondValue);
        PlayerPrefs.SetInt("Diammond10", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }
    public void Coin100()
    {
        coinValue = PlayerPrefs.GetInt("Gold");
        coinValue += 100;
        PlayerPrefs.SetInt("Gold", coinValue);
        PlayerPrefs.SetInt("Coin100", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }
    public void Coin300()
    {
        coinValue = PlayerPrefs.GetInt("Gold");
        coinValue += 300;
        PlayerPrefs.SetInt("Gold", coinValue);
        PlayerPrefs.SetInt("Coin300", 1);
        PlayerPrefs.Save();
        AudioManager.Instance.PlaySFX("Collect");
    }


}
