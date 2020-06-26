using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomPointSpawn : MonoBehaviour
{
    public GameObject[] PrefabCar;
    public int amountCar;
    public GameObject[] Points;
    public int WayCar = 200;
    private int[] xPosition = new int[20];
    private int[] yPosition = new int[20];
    System.Random rnd = new System.Random();

    private int i;
    private int rndCarCount;
    void Start()
    {
        for (int i = 0; i < amountCar; i++)
        {
            for (int j = 0; j < Points.Length; j++)
            {
                    xPosition[i] = rnd.Next(-2, 3);
                    yPosition[i] = rnd.Next(3, WayCar);

                    rndCarCount = rnd.Next(PrefabCar.Length);

                    Points[j].transform.position = new Vector3(xPosition[i], yPosition[i], 0);

                    Instantiate(PrefabCar[rndCarCount], Points[j].transform.position, Points[j].transform.rotation);
            }
        }
    }


    void Update()
    {
        if(Time.time > ((WayCar/4)/ GameProperties.SpeedEnemy))
        {
            if (GameProperties.SpeedEnemy < 7f)
                GameProperties.SpeedEnemy += Time.deltaTime * 2f;
        }
    }
}
