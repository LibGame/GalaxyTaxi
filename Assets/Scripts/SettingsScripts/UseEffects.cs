using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseEffects : MonoBehaviour
{
    public Sprite offSprite;
    public Sprite onSprite;
    public Image spRenderer;
    private int index = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("UseEffects"))
        {
            if (PlayerPrefs.GetInt("UseEffects") == 0)
            {
                spRenderer.sprite = offSprite;
                index = 1;

            }
            else if (PlayerPrefs.GetInt("UseEffects") == 1)
            {
                spRenderer.sprite = onSprite;
                index = 0;

            }
        }
        else
        {
            PlayerPrefs.SetInt("UseEffects", 0);
            PlayerPrefs.Save();
        }
    }

    public void EffectOffOn()
    {
        if (index == 0)
        {
            spRenderer.sprite = offSprite;
            PlayerPrefs.SetInt("UseEffects", index);
            PlayerPrefs.Save();
            index = 1;
        }
        else if (index == 1)
        {
            spRenderer.sprite = onSprite;
            PlayerPrefs.SetInt("UseEffects", index);
            PlayerPrefs.Save();
            index = 0;
        }


    }

}
