using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCheckControl : MonoBehaviour
{
    public GameObject togglemusic, togglesfx;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (AudioManager.Instance.MusicSource.mute)
        {
            togglemusic.SetActive(false);
        }
        if (!AudioManager.Instance.MusicSource.mute)
        {
            togglemusic.SetActive(true);
        }
        if (AudioManager.Instance.SFXSource.mute)
        {
            togglesfx.SetActive(false);
        }
        if (!AudioManager.Instance.SFXSource.mute)
        {
            togglesfx.SetActive(true);
        }
    }
}
