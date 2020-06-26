using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LoseTable : PlayerWallet
{

    [SerializeField]
    private Text MoneyText;
    [SerializeField]
    private Text ScoreText;
    public Canvas canvas;

    private void Start()
    {
        DestroyAllEnemyes();
        canvas.worldCamera = Camera.main;
        MoneyText.text = SetMoney((int)Math.Round(Interface.Score)).ToString();
        ScoreText.text = Interface.Score.ToString();

    }

    private static void DestroyAllEnemyes()
    {
        var objs = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < objs.Length; i++)
            Destroy(objs[i]);
    }

}
