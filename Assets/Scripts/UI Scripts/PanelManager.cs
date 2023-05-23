using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panels;
    private int currentPanelIndex = 0;
    private string panelShownKeyPrefix = "PanelShown_";
    public GameObject button;
    private void Start()
    {
        // Initially activate the first panel if it hasn't been shown before
        if (!IsPanelShown(currentPanelIndex))
        {
            ActivatePanel(currentPanelIndex);
        }
        else
        {
            button.SetActive(false);
        }
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
                Debug.Log("No more panels"); 
                button.SetActive(false);
            }
        }
    }

    private bool IsPanelShown(int index)
    {
        string panelShownKey = panelShownKeyPrefix + index.ToString();
        return PlayerPrefs.GetInt(panelShownKey, 0) == 1;
    }

    private void MarkPanelAsShown(int index)
    {
        string panelShownKey = panelShownKeyPrefix + index.ToString();
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
        }
    }
}
