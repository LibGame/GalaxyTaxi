using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerDamage : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D bulletConfront)
    {


        if (bulletConfront.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage == true)
            {
                Destroy(gameObject);
            }
            else if (CarController.isRage != true)
            {
                CarController.GetDamage(10);

            }
        }

        if (bulletConfront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }


    }
}
