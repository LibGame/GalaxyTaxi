using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusic : MonoBehaviour
{

    public AudioSource audio;
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip music4;
    private int index = 0;
    public Text MusicName;
    public Color color1;
    public Color color2;
    private Coroutine _fadeCoroutine;
    public void SoundChange()
    {
        if (index == 0)
        {
            audio.clip = music1;
            audio.Play();
            MusicName.text = music1.name;
            Invoke("StartFade", 1);
            MusicName.enabled = true;
        }
        else if (index == 1)
        {
            audio.clip = music2;
            audio.Play();
            MusicName.text = music2.name;
            Invoke("StartFade", 1);
            MusicName.enabled = true;
        }
        else if (index == 2)
        {
            audio.clip = music3;
            audio.Play();
            MusicName.text = music3.name;
            Invoke("StartFade", 1);
            MusicName.enabled = true;
        }
        else if (index == 3)
        {
            audio.clip = music4;
            audio.Play();
            MusicName.text = music4.name;
            Invoke("StartFade", 1);
            MusicName.enabled = true;
        }
        else if (index == 4)
        {
            audio.Stop();
            MusicName.text = "Off";
            Invoke("StartFade", 1);
            MusicName.enabled = true;
        }


        index++;

        if (index >= 5)
        {
            index = 0;
        }

    }

    private void StartFade()
    {
        _fadeCoroutine = StartCoroutine(FadeText(0.0f, 2.0f));

    }

    IEnumerator FadeText(float value, float time)
    {


        while (true)
        {
            float k = 0.0f;
            Color c0 = MusicName.color;
            Color c1 = c0;
            c1.a = value;

            while ((k += Time.deltaTime) <= time)
            {
                MusicName.color = Color.Lerp(c0, c1, k / time);

                yield return null;
            }

            MusicName.color = c0;
            MusicName.enabled = false;
            StopCoroutine(_fadeCoroutine);

        }
    }
}
