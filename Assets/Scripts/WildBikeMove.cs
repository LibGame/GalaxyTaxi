using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildBikeMove : MonoBehaviour
{

    public Transform PlayerCar;
    public Transform PointOfTransport;
    public bool increase = true;
    public static bool isShoot = false;
    public static bool Shoot = true;
    public float Speed = 3f; // радиус
    private bool atatckUpOrDown = true;
    public bool isMove = true;
    private bool isStart = false;
    private float time = 3f;
    public float timeToDestroy = 5f;
    private bool isDestroy = false;

    // Update is called once per frame
    void Update()
    {

        if (isStart)
        {
            if (isMove)
            {
                if (increase)
                {
                    if (this.transform.position.x < 2)
                        transform.Translate(Vector3.right * (Time.deltaTime * GameProperties.TankMoveSpeed));
                    else
                        increase = false;
                }
                else
                {
                    if (this.transform.position.x > -2)
                        transform.Translate(Vector3.left * (Time.deltaTime * GameProperties.TankMoveSpeed));
                    else
                        increase = true;
                }
            }

            if (isMove != true)
            {
                if (atatckUpOrDown)
                {
                    transform.Translate(Vector3.down * (Time.deltaTime * Speed));
                    Shoot = false;
                    if (transform.position.y <= -4f)
                    {
                        time = Random.Range(5f, 8f);
                        Invoke("ChangeAtack", time);
                        isMove = true;
                        Shoot = true;
                        isShoot = true;
                        atatckUpOrDown = false;
                    }
                }
                else
                {
                    transform.Translate(Vector3.up * (Time.deltaTime * Speed));
                    Shoot = false;
                    if (transform.position.y >= 4f)
                    {
                        Shoot = true;
                        isShoot = true;
                        time = Random.Range(5f, 8f);
                        Invoke("ChangeAtack", time);
                        atatckUpOrDown = true;
                        isMove = true;
                    }
                }
            }
        }
        else if (isStart != true && isDestroy != true)
        {
            transform.Translate(Vector3.down * (Time.deltaTime * 4f));
            if (transform.position.y <= 4f)
            {
                isStart = true;
                Invoke("DestroyPlayer", timeToDestroy);
                time = Random.Range(5f, 8f);
                Invoke("ChangeAtack", time);
                isShoot = true;
            }
        }


        if (isDestroy)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * 4f));
            if (transform.position.y >= 7f)
            {
                Destroy(gameObject);

            }
        }

    }

    private void ChangeAtack()
    {
        print("4");
        isMove = false;
    }

    private void DestroyPlayer()
    {
        isMove = false;
        isStart = false;
        isDestroy = true;
    }
}
