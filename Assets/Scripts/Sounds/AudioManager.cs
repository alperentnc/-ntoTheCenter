using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] MusicSounds, SFXSounds;
    public AudioSource MusicSource, SFXSource;
    public bool testMusic, testSFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Theme");

    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(MusicSounds, x => x.Name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            MusicSource.clip = s.Clip;
            MusicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFXSounds, x => x.Name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            SFXSource.PlayOneShot(s.Clip);
        }
    }

    public void ToggleMusic()
    {
        MusicSource.mute = !MusicSource.mute;
        //if (!MusicSource.mute)
        //{
        //    Debug.Log(1);
        //    testMusic = true;
        //}
        //if (MusicSource.mute)
        //{
        //    Debug.Log(0);
        //    testMusic = false;
        //}
        
    }

    public void ToggleSFX()
    {
        SFXSource.mute = !SFXSource.mute;
        if (!SFXSource.mute)
        {
            Debug.Log(1);
            testSFX = true;
        }
        if (SFXSource.mute)
        {
            Debug.Log(0);
            testSFX = false;
        }
    }
}