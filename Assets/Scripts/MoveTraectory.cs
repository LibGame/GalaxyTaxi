using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTraectory : MonoBehaviour
{
    //Создаем переменную для точки назначения
    public GameObject Point;
    public GameObject DestroyCar;
    //Создаем переменную для обозначения скорости движения
    public float _speed = 10f;


    void FixedUpdate()
    {
        Vector3 vectorPosition = Point.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, vectorPosition, Time.deltaTime * GameProperties._speed);
    }

    private void OnCollisionEnter2D(Collision2D carConfront)
    {


        if (carConfront.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage == true)
            {
                Destroy(DestroyCar);
            }
            else if (CarController.isRage != true)
            {
                CarController.GetDamage(10);
            }
        }

        if (carConfront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }
    }
}