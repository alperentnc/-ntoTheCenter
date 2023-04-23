using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

}
