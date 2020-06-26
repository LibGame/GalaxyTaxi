using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeCroShadow : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyPoint", 3f);
    }

    private void DestroyPoint()
    {
        Destroy(gameObject);
    }


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
                CarController.GetDamage(10);

                Destroy(gameObject);

            }
        }

        if (Confront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }

    }
}
