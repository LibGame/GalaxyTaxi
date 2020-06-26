using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlaneBomb : MonoBehaviour
{

    System.Random rndBomb = new System.Random();
    public GameObject BombPrefabs;
    public float TimeToStart = 1f;

    private int x1;
    private int y1;

    private int x2;
    private int y2;

    private int x3;
    private int y3;

    void Start()
    {
        Invoke("StartExplosion", TimeToStart);
    }

    void StartExplosion()
    {

        x1 = rndBomb.Next(-1, 2);
        x2 = rndBomb.Next(-1, 2);
        x3 = rndBomb.Next(-1, 2);


        y1 = rndBomb.Next(-3, 4);
        y2 = rndBomb.Next(-3, 4);
        y3 = rndBomb.Next(-3, 4);


        if (x1 == x2 || x1 == x3)
            x1 = rndBomb.Next(-1, 2);

        if (x2 == x1 || x2 == x3)
            x2 = rndBomb.Next(-1, 2);

        if (x3 == x2 || x3 == x1)
            x3 = rndBomb.Next(-1, 2);


        if (y1 == y2 || y1 == y3)
            y1 = rndBomb.Next(-1, 2);

        if (y2 == y1 || y2 == y3)
            y2 = rndBomb.Next(-1, 2);

        if (y3 == y2 || y3 == y1)
            y3 = rndBomb.Next(-1, 2);

        Instantiate(BombPrefabs, new Vector3(x1, y1, 0), Quaternion.identity);
        Instantiate(BombPrefabs, new Vector3(x2, y2, 0), Quaternion.identity);
        Instantiate(BombPrefabs, new Vector3(x3, y3, 0), Quaternion.identity);
    }

}
