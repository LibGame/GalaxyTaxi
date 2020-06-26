using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPressed : MonoBehaviour
{
    public enum ProjectMode { Time = 0, Heall = 1, Speed = 2 };
    public ProjectMode projectMode = ProjectMode.Time;
    public InputField inField;
    private void Start()
    {
        inField.characterLimit = 1;

        if (projectMode == ProjectMode.Time)
        {
            if (PlayerPrefs.HasKey("timeKey"))
            {
                inField.text = PlayerPrefs.GetString("timeKey");
            }

        }
        else if (projectMode == ProjectMode.Heall)
        {
            if (PlayerPrefs.HasKey("heallKey"))
            {
                inField.text = PlayerPrefs.GetString("heallKey");
            }

        }
        else if (projectMode == ProjectMode.Speed)
        {
            if (PlayerPrefs.HasKey("speedKey"))
            {
                inField.text = PlayerPrefs.GetString("speedKey");
            }
        }
    }

    public void SaveSettingsKey()
    {
        if(projectMode == ProjectMode.Time)
        {
            PlayerPrefs.SetString("timeKey", inField.text);

        }
        else if (projectMode == ProjectMode.Heall)
        {
            PlayerPrefs.SetString("heallKey", inField.text);

        }
        else if (projectMode == ProjectMode.Speed)
        {
            PlayerPrefs.SetString("speedKey", inField.text);

        }

        PlayerPrefs.Save();

    }

}
