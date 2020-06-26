using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BombInterScript : MonoBehaviour
{
    public static int AmountBomb;
    public GameObject DestroyerMap;
    private Text txt;
    private String key;
    private KeyCode kCode;

    void Start()
    {
        txt = transform.Find("BombTablet").GetComponent<Text>();
        if (PlayerPrefs.HasKey("heallKey"))
        {
            key = PlayerPrefs.GetString("heallKey").ToUpper();

        }
        else
        {
            key = "W";
        }

        if (PlayerPrefs.HasKey("Heall"))
        {
            AmountBomb = PlayerPrefs.GetInt("Heall");
        }
        else if (!PlayerPrefs.HasKey("Heall"))
        {
            PlayerPrefs.SetInt("Heall", 3);
            AmountBomb = 3;
        }
        txt.text = Convert.ToString(AmountBomb);

        kCode = (KeyCode)Enum.Parse(typeof(KeyCode), key);

    }

    public void Update()
    {
        if (Input.GetKeyDown(kCode))
        {
            AmountOfPoint();
        }
    }

    public void AmountOfPoint()
    {

        if (AmountBomb >= 1)
        {
            print(CarController.Life);

            CarController.GetDamage(-20);
            PlayerPrefs.SetInt("Heall", AmountBomb);
            AmountBomb--;
        }
        txt.text = Convert.ToString(AmountBomb);
    }
}
