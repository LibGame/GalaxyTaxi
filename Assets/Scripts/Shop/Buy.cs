using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public enum BuyMode { Time = 0, Heall = 1, Speed = 2 , SecondLife = 3};
    public BuyMode buyMode = BuyMode.Time;
    public PlayerWallet wallet;
    private int TimeAmount;
    private int HeallAmount;
    private int SpeedAmount;
    private int SecondLifeAmount;
    public AudioSource notEnoghtMoney;
    public AudioSource BuySound;

    public Text amountOfPoint;

    private void Start()
    {

        if (PlayerPrefs.HasKey("Time"))
        {
            TimeAmount = PlayerPrefs.GetInt("Time");
        }
        else if(!PlayerPrefs.HasKey("Time"))
        {
            PlayerPrefs.SetInt("Time", 3);
            TimeAmount = 3;
        }

        if (PlayerPrefs.HasKey("Heall"))
        {
            HeallAmount = PlayerPrefs.GetInt("Heall");
        }
        else if (!PlayerPrefs.HasKey("Heall"))
        {
            PlayerPrefs.SetInt("Heall", 3);
            HeallAmount = 3;
        }
        if (PlayerPrefs.HasKey("Speed"))
        {
            SpeedAmount = PlayerPrefs.GetInt("Speed");
        }
        else if (!PlayerPrefs.HasKey("Speed"))
        {
            PlayerPrefs.SetInt("Speed", 3);
            SpeedAmount = 3;

        }

        if (PlayerPrefs.HasKey("SecondLife"))
        {
            SecondLifeAmount = PlayerPrefs.GetInt("SecondLife");
        }
        else if (!PlayerPrefs.HasKey("SecondLife"))
        {
            PlayerPrefs.SetInt("SecondLife", 0);
            SecondLifeAmount = 0;

        }


        if (buyMode == BuyMode.Time)
        {
            amountOfPoint.text = TimeAmount.ToString();
        }
        else if (buyMode == BuyMode.Heall)
        {
            amountOfPoint.text = HeallAmount.ToString();
        }
        else if (buyMode == BuyMode.Speed)
        {
            amountOfPoint.text = SpeedAmount.ToString();
        }

        else if (buyMode == BuyMode.SecondLife)
        {
            amountOfPoint.text = SecondLifeAmount.ToString();
        }

    }

    public void BuyPoint()
    {
        if(buyMode == BuyMode.Time)
        {

            if (wallet.money >= 1000)
            {
                TimeAmount++;

                if (PlayerPrefs.HasKey("Time"))
                {
                    PlayerPrefs.SetInt("Time", TimeAmount);
                    wallet.UpdateMoney(1000);
                    PlayerPrefs.Save();
                    if (PlayerPrefs.HasKey("SoundOffOn"))
                    {
                        if (PlayerPrefs.GetInt("SoundOffOn") == 1)
                        {
                            BuySound.Play();
                        }
                    }
                }
            }
            else
            {
                if (PlayerPrefs.HasKey("SoundOffOn"))
                {
                    if (PlayerPrefs.GetInt("SoundOffOn") == 1)
                    {
                        notEnoghtMoney.Play();
                    }
                }
            }

            amountOfPoint.text = TimeAmount.ToString();
        }
        else if (buyMode == BuyMode.Heall)
        {

            if (wallet.money >= 2000)
            {
                HeallAmount++;

                if (PlayerPrefs.HasKey("Heall"))
                {
                    PlayerPrefs.SetInt("Heall", HeallAmount);
                    wallet.UpdateMoney(2000);
                    PlayerPrefs.Save();
                    if (PlayerPrefs.HasKey("SoundOffOn"))
                    {
                        if (PlayerPrefs.GetInt("SoundOffOn") == 1)
                        {
                            BuySound.Play();
                        }
                    }
                }

                amountOfPoint.text = HeallAmount.ToString();
            }
            else
            {
                if (PlayerPrefs.HasKey("SoundOffOn"))
                {
                    if (PlayerPrefs.GetInt("SoundOffOn") == 1)
                    {
                        notEnoghtMoney.Play();
                    }
                }
            }
        }
        else if (buyMode == BuyMode.Speed)
        {

            if(wallet.money >= 1000)
            {
                SpeedAmount++;

                if (PlayerPrefs.HasKey("Speed"))
                {
                    PlayerPrefs.SetInt("Speed", SpeedAmount);
                    wallet.UpdateMoney(1000);
                    PlayerPrefs.Save();
                    if (PlayerPrefs.HasKey("SoundOffOn"))
                    {
                        if (PlayerPrefs.GetInt("SoundOffOn") == 1)
                        {
                            BuySound.Play();
                        }
                    }
                }
            }
            else
            {
                if (PlayerPrefs.HasKey("SoundOffOn"))
                {
                    if (PlayerPrefs.GetInt("SoundOffOn") == 1)
                    {
                        notEnoghtMoney.Play();
                    }
                }
            }
            amountOfPoint.text = SpeedAmount.ToString();
        }

        else if (buyMode == BuyMode.SecondLife)
        {

            if (wallet.money >= 5000)
            {
                SecondLifeAmount++;

                if (PlayerPrefs.HasKey("SecondLife"))
                {
                    PlayerPrefs.SetInt("SecondLife", SecondLifeAmount);
                    wallet.UpdateMoney(5000);
                    PlayerPrefs.Save();
                    if (PlayerPrefs.HasKey("SoundOffOn"))
                    {
                        if (PlayerPrefs.GetInt("SoundOffOn") == 1)
                        {
                            BuySound.Play();
                        }
                    }
                }
            }
            else
            {
                if (PlayerPrefs.HasKey("SoundOffOn"))
                {
                    if (PlayerPrefs.GetInt("SoundOffOn") == 1)
                    {
                        notEnoghtMoney.Play();
                    }
                }
            }


            amountOfPoint.text = SecondLifeAmount.ToString();
        }

    }
}
