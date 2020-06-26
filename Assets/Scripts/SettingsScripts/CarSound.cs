using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    public AudioSource CarSounds;

    private float soundValue;
    private void Start()
    {
        soundValue = PlayerPrefs.GetFloat("soundValue");
        CarSounds.volume = soundValue / 3;

        if (PlayerPrefs.HasKey("SoundOffOn"))
        {
            if (PlayerPrefs.GetInt("SoundOffOn") == 0)
            {
                CarSounds.Stop();
                CarSounds.volume = 0;

            }
            else if (PlayerPrefs.GetInt("SoundOffOn") == 1)
            {
                CarSounds.Play();
                CarSounds.volume = soundValue / 3;
            }
        }
        else
        {
            PlayerPrefs.SetInt("SoundOffOn", 0);
            PlayerPrefs.Save();
        }
    }
}
