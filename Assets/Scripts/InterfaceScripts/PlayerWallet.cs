using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWallet : MonoBehaviour
{
    public int money = 0;
    public bool _isShoop;
    public Text moneyAmount;

    private void Start()
    {

        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
        }
        else if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 1000);
            money = 1000;
        }

        if (_isShoop)
        {
            moneyAmount.text = money.ToString();

        }

    }

    public void UpdateMoney(int amount)
    {
        money -= amount;
        moneyAmount.text = money.ToString();
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.Save();
    }

    public int SetMoney(int amount)
    {
        float random = Random.Range(50f, 100f);
        float newMoney = (float) (amount / random) * 1000;
        money += (int) newMoney;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.Save();

        return money;
    }


}
