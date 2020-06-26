using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncocatorCar : MonoBehaviour
{

    public bool increase = true;
    public bool increaseY = true;

    public bool isStart = false;
    public float yHeight = -3f;
    public bool isCanDestroy = false;

    void Start()
    {
        Invoke("inDestroyer", 30f);
    }

    private void OnTriggerEnter2D(Collider2D confront)
    {
        if (confront.gameObject.tag == "PlayerCar")
        {

        }
    }

    void inDestroyer()
    {
        isCanDestroy = true;
    }


    void Update()
    {

        if (isCanDestroy)
        {
            isStart = false;

            if (transform.position.y >= 7)
            {
                lightsBos.isCanStart = false;
                Destroy(gameObject);
            }
            else
            {
                transform.Translate(Vector3.up * (Time.deltaTime * GameProperties._speed ));
            }
        }

        if (lightsBos.isCanStart)
        {
            if(transform.position.y >= yHeight)
            {
                lightsBos.isCanStart = false;
                isStart = true;
            }
            else
            {
                transform.Translate(Vector3.up * (Time.deltaTime * GameProperties._speed));
            }
        }

        if (isStart)
        {
            if (increase)
            {
                if (this.transform.position.x < 2)
                    transform.Translate(Vector3.right * (Time.deltaTime * GameProperties.IncocatorSpeed));
                else
                    increase = false;
            }
            else
            {
                if (this.transform.position.x > -2)
                    transform.Translate(Vector3.left * (Time.deltaTime * GameProperties.IncocatorSpeed));
                else
                    increase = true;
            }

            if (increaseY)
            {
                if (this.transform.position.y < 3)
                    transform.Translate(Vector3.up * (Time.deltaTime * GameProperties.IncocatorSpeed));
                else
                    increaseY = false;
            }
            else
            {
                if (this.transform.position.y > -3)
                    transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.IncocatorSpeed));
                else
                    increaseY = true;
            }
        }
    }
}
