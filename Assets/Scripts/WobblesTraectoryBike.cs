using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WobblesTraectoryBike : MonoBehaviour
{
    public float TimeToDestory = 4f;
    public float MoveSpeed = 20f;

    public float frequency = 3.0f; // Скорость виляния по синусоиде
    public float magnitude = 1f; // Размер синусоиды (радиус, по сути..можно заменить на "R")
    private bool isUp;
    private Vector3 axis;
    private Vector3 pos;
    System.Random rnd = new System.Random();

    private void OnTriggerEnter2D(Collider2D Confront)
    {


        if (Confront.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage == true)
            {
                Destroy(gameObject);
            }
            else if (CarController.isRage != true)
            {
                CarController.GetDamage(10);

                Destroy(gameObject);

            }
        }
        if (Confront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        pos = transform.position;
        axis = transform.right;
        Invoke("DestroyObj", TimeToDestory);

        magnitude = rnd.Next(1, 3);

        if (WildBikerBos.randomBikePosition == 3)
        {
            isUp = false;
            this.transform.rotation = Quaternion.Euler(180, 0, 0);

        }
        else if (WildBikerBos.randomBikePosition == 2)
        {
            isUp = true;

        }

    }

    void Update()
    {
        if (isUp == false)
        {
            pos += transform.up * Time.deltaTime * MoveSpeed;
            transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
        }
        else if(isUp == true)
        {
            pos += transform.up * Time.deltaTime * MoveSpeed;
            transform.position = pos - axis * Mathf.Sin(Time.time * frequency) * magnitude;
        }
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }
}
