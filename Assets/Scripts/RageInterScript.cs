using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RageInterScript : MonoBehaviour
{
    public static int AmountRage;
    public GameObject RageLight;
    private String key;
    private KeyCode kCode;

    Text txt;

    void Start()
    {
        txt = transform.Find("RageTabletText").GetComponent<Text>();

        if (PlayerPrefs.HasKey("speedKey"))
        {
            key = PlayerPrefs.GetString("speedKey").ToUpper();

        }
        else
        {
            key = "E";
        }

        if (PlayerPrefs.HasKey("Speed"))
        {
            AmountRage = PlayerPrefs.GetInt("Speed");
        }
        else if (!PlayerPrefs.HasKey("Speed"))
        {
            PlayerPrefs.SetInt("Speed", 3);
            AmountRage = 3;

        }
        txt.text = Convert.ToString(AmountRage);
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
    
        if (AmountRage >= 1)
        {
            CarController.isRage = true;
            AmountRage--;
            Instantiate(RageLight, new Vector3(0, 0, 0), Quaternion.identity);
            GameProperties.BackGroundSpeed = 15f;
            GameProperties.SpeedEnemy = 7f;
            Invoke("TimeDefaultSpeed", 3f);
            PlayerPrefs.SetInt("Speed", AmountRage);

        }
        txt.text = Convert.ToString(AmountRage);
    }


    void TimeDefaultSpeed()
    {
        CarController.isRage = false;
        Destroy(GameObject.Find("RageLight(Clone)"));
        GameProperties.BackGroundSpeed = 10f;
        GameProperties.SpeedEnemy = 5f;
    }
}
