using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{


    void Update()
    {
        this.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.BackGroundSpeed));

        if(this.transform.position.y + this.transform.position.y <= -20)
        {
            Destroy(gameObject);
        }
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


            }
        }

    }
}
