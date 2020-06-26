using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimePointSpawn : MonoBehaviour
{

    public GameObject PointPrefab;
    System.Random rnd = new System.Random();
    private int x1;
    private int y1;

    public int TimeToSpawn = 1;

    void Start()
    {
        StartCoroutine("SpawnTimePoint");
    }


    IEnumerator SpawnTimePoint()
    {
        while (true)
        {
            x1 = rnd.Next(-1, 2);
            TimeToSpawn = rnd.Next(4, 8);
            Instantiate(PointPrefab, new Vector3(x1, 20, 0), Quaternion.identity);
            yield return new WaitForSeconds(TimeToSpawn);

        }
    }
}
