using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptExplosion : MonoBehaviour
{
    public GameObject ExplosionPref;

    void Start()
    {
        Invoke("Destoroy", 0.3f);
    }


    private void OnTriggerEnter2D(Collider2D Confront)
    {


        if (Confront.gameObject.tag == "PlayerCar")
        {

            CarController.GetDamage(50);

            Destroy(gameObject);

        }

    }

    void Destoroy()
    {
        Destroy(ExplosionPref);
    }
}
