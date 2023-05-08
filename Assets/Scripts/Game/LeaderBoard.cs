using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class LeaderBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cloud.OnInitializeComplete += CloudOnceInitializeComplete;
    }

    public void CloudOnceInitializeComplete()
    {
        Cloud.OnInitializeComplete -= CloudOnceInitializeComplete;
    }

}
