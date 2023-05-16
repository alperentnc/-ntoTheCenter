using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class LeaderBoard : MonoBehaviour
{
    void Start()
    {
        Cloud.OnInitializeComplete += CloudOnceInitializeComplete;
        //Cloud.Initialize(false, true);
    }

    public void CloudOnceInitializeComplete()
    {
        Cloud.OnInitializeComplete -= CloudOnceInitializeComplete;
    }

}
