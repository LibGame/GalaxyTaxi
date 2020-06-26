using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSounds : MonoBehaviour
{
    public AudioSource Sound;

    public void AudioPlay()
    {
        if (PlayerPrefs.HasKey("SoundOffOn"))
        {
            if (PlayerPrefs.GetInt("SoundOffOn") == 1)
            {
                Sound.Play();
            }
        }
        else
        {
            PlayerPrefs.SetInt("SoundOffOn", 0);
            PlayerPrefs.Save();
        }
    
    }
}
