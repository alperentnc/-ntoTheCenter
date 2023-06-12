using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panels;
    private int currentPanelIndex = 0;
    private string panelShownKeyPrefix = "PanelShown_";
    public GameObject button;
    private int prefs;
    private string panelShownKey;
    public bool panelFinisher;
    private void Start()
    {
        panelFinisher = false;
        // Initially activate the first panel if it hasn't been shown before
        if (!IsPanelShown(currentPanelIndex))
        {
            ActivatePanel(currentPanelIndex);
        }
        else
        {
            button.SetActive(false);
        }
        prefs = PlayerPrefs.GetInt(panelShownKey);
    }

    private void Update()
    {
        // Check for user input
        if (Input.GetMouseButtonDown(0))
        {
            // Deactivate the current panel
            DeactivatePanel(currentPanelIndex);
            
            // Move to the next panel
            currentPanelIndex++;

            // Check if there are more panels
            if (currentPanelIndex < panels.Length)
            {
                // Activate the next panel if it hasn't been shown before
                if (!IsPanelShown(currentPanelIndex))
                {
                    ActivatePanel(currentPanelIndex);
                }
            }
            else
            {
                // No more panels, do something else
                if (panelFinisher == false)
                {
                    Debug.Log("No more panels");
                    PlayFabManager.panelclosed = true;
                    button.SetActive(false);
                    panelFinisher = true;
                }
                
            }

        }
    }

    private bool IsPanelShown(int index)
    {
         panelShownKey = panelShownKeyPrefix + index.ToString();
        return PlayerPrefs.GetInt(panelShownKey, 0) == 1;
    }

    private void MarkPanelAsShown(int index)
    {
         panelShownKey = panelShownKeyPrefix + index.ToString();
        PlayerPrefs.SetInt(panelShownKey, 1);
    }

    private void ActivatePanel(int index)
    {
        if (index >= 0 && index < panels.Length)
        {
            panels[index].SetActive(true);
        }
    }

    private void DeactivatePanel(int index)
    {
        if (index >= 0 && index < panels.Length)
        {
            panels[index].SetActive(false);
            MarkPanelAsShown(index);
            if (prefs == 0)
            {
                AudioManager.Instance.PlaySFX("Equip");
            }
            
        }
    }
}
