using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public AudioSource audio;

    private float soundValue;
    private void Start()
    {
        soundValue = PlayerPrefs.GetFloat("soundValue");
        audio.volume = soundValue; 

        if (PlayerPrefs.HasKey("SoundOffOn"))
        {
            if(PlayerPrefs.GetInt("SoundOffOn") == 0)
            {
                audio.Stop();
                audio.volume = 0;

            }
            else if(PlayerPrefs.GetInt("SoundOffOn") == 1)
            {
                audio.Play();
                audio.volume = soundValue;
            }
        }
        else
        {
            PlayerPrefs.SetInt("SoundOffOn", 0);
            PlayerPrefs.Save();
        }
    }

}
