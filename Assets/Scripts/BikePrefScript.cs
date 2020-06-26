using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikePrefScript : MonoBehaviour
{

    private float bikeDestroy = 5f;

    private void OnTriggerEnter2D(Collider2D Confront)
    {


        if (Confront.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage == true)
            {
                Destroy(gameObject);
            }
            else if (CarController.isRage != true)
            {
                CarController.GetDamage(5);
                Destroy(gameObject);

            }
        }
        if (Confront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        Invoke("DestroyBike", bikeDestroy);
    }


    void DestroyBike()
    {
        Destroy(gameObject);
    }
}
