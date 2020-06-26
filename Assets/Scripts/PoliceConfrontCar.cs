using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoliceConfrontCar : MonoBehaviour
{
    public Transform Car;
    public GameObject AllCar;

    Rigidbody2D rigidbodyCar;
    public Transform PointOfConfront;

    private int xPosition;
    private int yPosition;

    private float BxPosition;
    private float ByPosition;

    public float TimeToDestroy;

    private bool isFinish = false;
    private bool isStart = true;

    private System.Random rnd = new System.Random();

    private Vector3 wasPosition;

    void Start()
    {

        rigidbodyCar = GetComponent<Rigidbody2D>();


        BxPosition = transform.position.x;
        ByPosition = transform.position.y;

        PointOfConfront.position = new Vector3(xPosition,yPosition,0);

    }

    void Update()
    {
        wasPosition = transform.position;

        if (transform.position.y < 4 && isStart)
        {
            Invoke("TimeDestory", TimeToDestroy);
            isStart = false;
        }

        if (isFinish != true)
        {

            var turn = Quaternion.Lerp(Car.rotation, Quaternion.LookRotation(Vector3.forward, PointOfConfront.position - Car.position), Time.deltaTime * GameProperties.RotationTureSpeed1);
            rigidbodyCar.MoveRotation(turn.eulerAngles.z);

            transform.position = Vector2.MoveTowards(transform.position,
                    PointOfConfront.position, Time.deltaTime * 4);

            BxPosition = transform.position.x;
            ByPosition = transform.position.y;

        }
        else if (isFinish)
        {
            rigidbodyCar.velocity = rigidbodyCar.transform.up * GameProperties.SpeedEnemy;

            if (this.transform.position.y + this.transform.position.y <= -10 || this.transform.position.y + this.transform.position.y >= 10
                        || this.transform.position.x + this.transform.position.x <= -10 || this.transform.position.x + this.transform.position.x >= 10)
            {
                Destroy(gameObject);
            }
        }
        if (transform.position.x == BxPosition || transform.position.y == ByPosition)
        {
            xPosition = rnd.Next(-1, 2);
            yPosition = rnd.Next(-3, 4);
        }

        if (transform.position.Equals(wasPosition))
        {
            xPosition = rnd.Next(-1, 2);
            yPosition = rnd.Next(-3, 4);

            PointOfConfront.position = new Vector3(xPosition, yPosition, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D confront)
    {
        if (confront.gameObject.tag == "RandomPoint")
        {
            xPosition = rnd.Next(-1, 2);
            yPosition = rnd.Next(-3, 4);

            PointOfConfront.position = new Vector3(xPosition, yPosition, 0);
        }
        if (confront.gameObject.tag == "PlayerCar")
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

        if (confront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }
    }

    private void TimeDestory()
    {
        isFinish = true;
    }
}
