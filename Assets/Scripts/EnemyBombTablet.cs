using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EnemyBombTablet : MonoBehaviour
{
    Text txt;

    void Start()
    {
        txt = GameObject.Find("BombTablet").GetComponent<Text>();
    }

    void Update()
    {
        this.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.SpeedEnemy));

        if (this.transform.position.y + this.transform.position.y <= -20)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D Confront)
    {
        if (Confront.gameObject.tag == "PlayerCar")
        {
            BombInterScript.AmountBomb++;
            txt.text = Convert.ToString(BombInterScript.AmountBomb);
            Destroy(gameObject);
        }

    }
}
