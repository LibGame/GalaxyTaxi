using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOFfOn : MonoBehaviour
{

    public Sprite offSprite;
    public Sprite onSprite;
    public Image spRenderer;
    private int index = 0;
    private AudioSource audio1;
    private AudioSource audio2;
    private float soundValue;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SoundOffOn"))
        {
            if (PlayerPrefs.GetInt("SoundOffOn") == 0)
            {
                spRenderer.sprite = offSprite;
                index = 1;

            }
            else if (PlayerPrefs.GetInt("SoundOffOn") == 1)
            {
                spRenderer.sprite = onSprite;
                index = 0;

            }
        }
        else
        {
            PlayerPrefs.SetInt("SoundOffOn", 1);
            PlayerPrefs.Save();
        }
        soundValue = PlayerPrefs.GetFloat("soundValue");

        audio1 = GameObject.Find("Audio").GetComponent<AudioSource>();
        audio2 = GameObject.Find("CarSound").GetComponent<AudioSource>();

    }

    public void SoundOffOn()
    {
        if(index == 0)
        {
            spRenderer.sprite = offSprite;
            if (!audio1.isPlaying)
            {
                audio1.Stop();

            }
            if (!audio2.isPlaying)
            {
                audio2.Stop();

            }
            PlayerPrefs.SetInt("SoundOffOn", index);
            PlayerPrefs.Save();
            index = 1;
        }else if(index == 1) {
            spRenderer.sprite = onSprite;
            if (!audio1.isPlaying)
            {
                audio1.Play();
                audio1.volume = soundValue;
            }
            if (!audio2.isPlaying)
            {
                audio2.Play();
                audio2.volume = soundValue / 3;
            }
            PlayerPrefs.SetInt("SoundOffOn", index);
            PlayerPrefs.Save();
            index = 0;
        }

  
    }
}
