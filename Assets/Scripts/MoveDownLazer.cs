using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownLazer : MonoBehaviour
{
    public float timeToStart; // время когда начнеться атака
    public float timeToStop; // время когда закончиться атака
    private bool isCanDown;

    void Start()
    {
        Invoke("isStart", timeToStart);

    }


    void isStart()
    {
        isCanDown = true;
        Invoke("isStop", timeToStop);

    }

    void isStop()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCanDown)
        {
            this.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.SpeedEnemy));
        }
    }
}
