using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirsCarScript : MonoBehaviour
{
    public GameObject carsMove;

    void update()
    {
        carsMove.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.SpeedEnemy));
    }
}
