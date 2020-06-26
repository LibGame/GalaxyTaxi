using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject LazerDestroy;

    void Start()
    {
        Invoke("DestroyCarsLazer", LazerCarScript.DestroyTimeCarLizer - 1);
    }

    private void OnCollisionEnter2D(Collision2D confront)
    {


        if (confront.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage == true)
            {
                Destroy(LazerDestroy);
            }
            else if (CarController.isRage != true)
            {
                CarController.GetDamage(5);

            }
        }

    }

    void OnDestroy()
    {
        Destroy(LazerDestroy);
    }

    void DestroyCarsLazer()
    {
        Destroy(LazerDestroy);
    }

}
