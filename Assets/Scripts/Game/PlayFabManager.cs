using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayFabManager : MonoBehaviour
{
    public GameObject nameWindow;
    public TMP_InputField nameInput;
    public GameObject LeaderBoardPanel;
    public GameObject rowPrefab;
    public Transform rowsParent;
    string loggedInPlayedId;
    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    // Update is called once per frame
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters=new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile=true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);

    }
    void OnSuccess(LoginResult result)
    {
        loggedInPlayedId = result.PlayFabId;
        Debug.Log("Successful");
        string name = null;
        if(result.InfoResultPayload.PlayerProfile != null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        }
        if (name == null)
        {
            nameWindow.SetActive(true);
        }
        
    }
    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,

        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }
    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("NameUpdated");
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error");
        Debug.Log(error.GenerateErrorReport());
    }
    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName="Core Quest Leaderboard",
                    Value=score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent");
    }
    public void GetLeaderboard()
    {
        LeaderBoardPanel.SetActive(true);
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Core Quest Leaderboard",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }
    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        GetLeaderboardAroundPlayer();
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TMP_Text[] texts = newGo.GetComponentsInChildren<TMP_Text>();
            texts[0].text = (item.Position+1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
            Debug.Log(item.Position + " " + item.DisplayName + " " + item.StatValue);
        }
        
    }
    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TMP_Text[] texts = newGo.GetComponentsInChildren<TMP_Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
            if (item.PlayFabId == loggedInPlayedId)
            {
                texts[0].color = new Color(97/255f, 56/255f, 253/255f);
                texts[1].color = new Color(97 / 255f, 56 / 255f, 253 / 255f);
                texts[2].color = new Color(97 / 255f, 56 / 255f, 253 / 255f);
            }
            Debug.Log(item.Position + " " + item.DisplayName + " " + item.StatValue);
        }
    }
    public void GetLeaderboardAroundPlayer()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Core Quest Leaderboard",
            MaxResultsCount = 1
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }
}
