using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTankBulet : MonoBehaviour
{


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
                CarController.GetDamage(1);
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
        Invoke("DestroyBullet", 0.4f);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
