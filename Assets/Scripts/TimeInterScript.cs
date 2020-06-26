using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimeInterScript : MonoBehaviour
{
    public static int AmountTimesTablet;
    Text txt;
    private String key;
    private KeyCode kCode;
    void Start()
    {
        txt = transform.Find("TimeTabletText").GetComponent<Text>();

        if (PlayerPrefs.HasKey("timeKey"))
        {
            key = PlayerPrefs.GetString("timeKey").ToUpper();

        }
        else
        {
            key = "Q";
        }

        if (PlayerPrefs.HasKey("Time"))
        {
            AmountTimesTablet = PlayerPrefs.GetInt("Time");
        }
        else if (!PlayerPrefs.HasKey("Time"))
        {
            PlayerPrefs.SetInt("Time", 3);
            AmountTimesTablet = 3;
        }
        txt.text = Convert.ToString(AmountTimesTablet);
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
        if (AmountTimesTablet >= 1)
        {
            GameProperties.BackGroundSpeed = 5f;
            GameProperties.SpeedEnemy = 2.5f;
            GameProperties.SpeedBarnel = 1f;
            GameProperties.SpeedEnemyCar = 5f;
            GameProperties.TimeDelteEnemyCar = 2f;
            GameProperties._speed = 5f;
            GameProperties.CopterSpeed = 0.5f;
            GameProperties.MoveSpeed = 0.25f;
            GameProperties.HardSpeed = 2f;
            GameProperties.speedHelio = 1.5f;
            GameProperties.speedOil = 1f;
            GameProperties.TabletSpeed = 1f;
            GameProperties.BosRocket = 1.5f;
            GameProperties.TankMoveSpeed = 1f;
            GameProperties.RotationTureSpeed = 20f;
            GameProperties.RotationTureSpeed1 = 2f;
            GameProperties.RocketSpeed = 2.5f;
            GameProperties.thirdBGSpeed = 0.5f;
            GameProperties.thirdBGSpeed = 4f;
            GameProperties.PointsSpeed = 6f;
            GameProperties.IncocatorSpeed = 1.5f;
            GameProperties.RotationSpeedTank = 0.5f;
            GameProperties.FireBulletSpeed = 5f;
            AmountTimesTablet--;
            BackGroundMove1.speedBG = 0.75f;
            GameProperties.PlagueWallSpeed = 3f;
            Invoke("isBack", 10f);
            PlayerPrefs.SetInt("Time", AmountTimesTablet);

        }
        txt.text = Convert.ToString(AmountTimesTablet);
    }

    private void isBack()
    {
        BackGroundMove1.speedBG = 1.5f;
        GameProperties.BackGroundSpeed = 10f;
        GameProperties.SpeedEnemy = 5f;
        GameProperties.SpeedBarnel = 2f;
        GameProperties.SpeedEnemyCar = 10f;
        GameProperties.TimeDelteEnemyCar = 4f;
        GameProperties._speed = 10f;
        GameProperties.CopterSpeed = 1f;
        GameProperties.MoveSpeed = 0.5f;
        GameProperties.HardSpeed = 4f;
        GameProperties.speedHelio = 3f;
        GameProperties.speedOil = 2f;
        GameProperties.TabletSpeed = 2f;
        GameProperties.BosRocket = 3f;
        GameProperties.TankMoveSpeed = 2f;
        GameProperties.RotationTureSpeed = 40f;
        GameProperties.RotationTureSpeed1 = 4f;
        GameProperties.RocketSpeed = 5f;
        GameProperties.thirdBGSpeed = 1f;
        GameProperties.PointsSpeed = 12f;
        GameProperties.IncocatorSpeed = 3f;
        GameProperties.RotationSpeedTank = 1f;
        GameProperties.FireBulletSpeed = 10f;
        GameProperties.PlagueWallSpeed = 10f;
    }
}
