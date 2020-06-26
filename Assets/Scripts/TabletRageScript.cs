using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TabletRageScript : MonoBehaviour
{
    Text txt;

    void Start()
    {
        txt = GameObject.Find("RageTabletText").GetComponent<Text>();

    }

    void Update()
    {
        this.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.SpeedEnemy));

        if (this.transform.position.y + this.transform.position.y <= -20)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D confront)
    {
        if (confront.gameObject.tag == "PlayerCar")
        {
            RageInterScript.AmountRage++;
            txt.text = Convert.ToString(RageInterScript.AmountRage);
            Destroy(gameObject);
        }
    }

}
