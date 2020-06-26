using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class OilCar : MonoBehaviour
{
    System.Random rndPref = new System.Random();

    public float speedOil = 2f;
    public float angle = 0; // угол 
    public float radius = 1f; // радиус
    public float yHeight;
    public float DestroyTime = 5f;
    private int RandomPref;

    private bool isCircle = false; // условие движения по кругу
    private bool toDestroy = false;

    private bool isInvoke = true;
    private bool downCar = true;
    public bool isSpawn = true;

    public Transform PositionOilDisgarge;
    public GameObject[] PrefabsOil;
    public Transform CarPlayer;


    void Update() {


        if (isCircle)
        {
            angle += Time.deltaTime; // меняется плавно значение угла

            var x = Mathf.Cos(angle * GameProperties.speedOil) * radius;
            var y = Mathf.Sin(angle * GameProperties.speedOil) * radius;
            transform.position = new Vector2(x, y);
        }


        if(this.transform.position.y <= yHeight && isInvoke == true)
        {
            isCircle = true;
            downCar = false;
            Invoke("DestroyOilCar", DestroyTime);
            isInvoke = false;
        }
        else if(downCar==true)
        {
                this.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.BackGroundSpeed));

            
        }

        if ((int) this.transform.position.x == (int)CarPlayer.transform.position.x && downCar != true)
        {
            if (isSpawn)
            {
                RandomPref = rndPref.Next(0, 2);
                Instantiate(PrefabsOil[RandomPref], PositionOilDisgarge.position, PositionOilDisgarge.rotation);
                Invoke("isSpawnBool", 1f);
                isSpawn = false;
            }
        }


        if (toDestroy)
        {
            if (this.transform.position.y + this.transform.position.y <= -20)
            {
                Destroy(gameObject);
            }
            else
            {
                this.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.SpeedEnemy));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D OilCarConfront)
    {


        if (OilCarConfront.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage == true)
            {
                Destroy(gameObject);
            }
            else if (CarController.isRage != true)
            {
                CarController.GetDamage(20);



            }
        }
        if (OilCarConfront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }

    }

    void isSpawnBool()
    {
        isSpawn = true;
    }

    void DestroyOilCar()
    {
        isCircle = false;
        toDestroy = true;
    }
}
