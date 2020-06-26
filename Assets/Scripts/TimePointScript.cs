using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimePointScript : MonoBehaviour
{

    Text txt;

    void Start()
    {
        txt = GameObject.Find("TimeTabletText").GetComponent<Text>();

    }

    void Update()
    {
        this.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.SpeedEnemy));

        if(this.transform.position.y + this.transform.position.y <= -20)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D Confront)
    {
        if (Confront.gameObject.tag == "PlayerCar")
        {
            TimeInterScript.AmountTimesTablet++;
            txt.text = Convert.ToString(TimeInterScript.AmountTimesTablet);
            Destroy(gameObject);
        }
    }



    }
