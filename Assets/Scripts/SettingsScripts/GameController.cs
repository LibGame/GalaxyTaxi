using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Sprite Coursor;
    public Sprite JoyStick;
    public Image spRenderer;
    private int index = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerController"))
        {
            index = PlayerPrefs.GetInt("PlayerController");

            if (index == 0)
            {
                spRenderer.sprite = JoyStick;

            }
            else if (index == 1)
            {
                spRenderer.sprite = Coursor;

            }

            index++;
            if (index >= 2)
            {
                index = 0;
            }
        }
        else
        {
            PlayerPrefs.SetInt("PlayerController", 2);
            PlayerPrefs.Save();
        }

    }

    public void SetController()
    {
        if (index == 0)
        {
            spRenderer.sprite = JoyStick;
        }
        else if (index == 1)
        {
            spRenderer.sprite = Coursor;
        }

        PlayerPrefs.SetInt("PlayerController", index);
        PlayerPrefs.Save();

        index++;
        if(index >= 2)
        {
            index = 0;
        }
    }
}
