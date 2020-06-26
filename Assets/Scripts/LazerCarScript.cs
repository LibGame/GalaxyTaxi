using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LazerCarScript : MonoBehaviour
{

    public GameObject LazerCarFirst;
    public GameObject LazerCarSecond;
    public GameObject LazerPrefabs;
    public GameObject LazerPointPlace;
    public GameObject LazerCars;
    public Transform LazerCarss;
    public Transform  LazerOfdischarge;
    public Transform LazerCarFirstTransform;
    public Transform LazerCarSecondTransform;
    public float CorectionOfLazer = 11f;
    public float TimeSpawnLazer = 1f;
    private float Distances;
    float distLazer;
    public float DistanceLazerCar = 2;
    public static float DestroyTimeCarLizer = 10f;

    private bool LazerCreate = true;
    private float PointLazer;
    public float YPosition = 0;

    void Start()
    {
        Invoke("DestroyCars", DestroyTimeCarLizer);

    }


    void Update()
    {


        PointLazer = (float)LazerOfdischarge.position.y;

        distLazer = Vector3.Distance(LazerCarFirstTransform.position, LazerCarSecondTransform.position);


        if (LazerCars.transform.position.y >= YPosition)
        {
            LazerCars.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.SpeedEnemy));
        }else if(LazerCars.transform.position.y <= YPosition)
        {
            if (distLazer > DistanceLazerCar)
            {
                LazerCarFirst.transform.Translate(Vector3.right * (Time.deltaTime * 5));
                LazerCarSecond.transform.Translate(Vector3.left * (Time.deltaTime * 5));
            }
            else if (distLazer <= DistanceLazerCar + 0.2 && LazerCreate != false)
            {
                //LazerPointPlace.transform.position = new Vector3(distLazer / CorectionOfLazer, PointLazer, 0);          
                Invoke("LazerDischarge", TimeSpawnLazer);
                LazerCreate = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D confronts)
    {
        if (confronts.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage == true)
            {
                Destroy(LazerCars);
            }
            else if (CarController.isRage != true)
            {
                CarController.GetDamage(10);

            }
        }
        if (confronts.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }
    }

    void LazerDischarge()
    {
        var lazerChild = Instantiate(LazerPrefabs, LazerOfdischarge.position, LazerOfdischarge.rotation);
        print(distLazer);
        print(LazerPrefabs.transform.localScale.x);
        print(distLazer * LazerPrefabs.transform.localScale.x);
        lazerChild.transform.localScale = new Vector3(LazerPrefabs.transform.localScale.x / (distLazer/ LazerPrefabs.transform.localScale.x), 0.5f, 0.5f);

    }

    void DestroyCars()
    {
        Destroy(LazerCars);
    }
}
