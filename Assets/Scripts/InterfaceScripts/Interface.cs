using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Interface : MonoBehaviour
{
    private Coroutine _startScoreCoroutine;
    [SerializeField]
    private float scoreLenght;
    private float scoreNow;
    public static float Score;
    public GameObject JoyStick;
    private int index;
    public Text scoreText;

    private void Start()
    {
        _startScoreCoroutine = StartCoroutine(ScoreColculatorSpawn());


        if (PlayerPrefs.HasKey("PlayerController"))
        {
            index = PlayerPrefs.GetInt("PlayerController");

            if(index == 0)
            {
                Instantiate(JoyStick, JoyStick.transform.position, Quaternion.identity);
                CarController.isCantMove = true;
            }
            else if (index == 1)
            {
                CarController.isCantMove = false;

            }
        }
        else
        {
            PlayerPrefs.SetInt("PlayerController", 2);
            PlayerPrefs.Save();
        }
    }

    private IEnumerator ScoreColculatorSpawn()
    {

        while (true)
        {
            if(CarController.LoseGame != true)
            {
                scoreNow++;
                Score = Mathf.Round((scoreNow / scoreLenght) * 100);
                scoreText.text = Score.ToString();
            }

            yield return new WaitForSeconds(1f);

        }
    }
}
