using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDownIncocatorScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D confront)
    {

        if (confront.gameObject.tag == "IncocatorCar")
        {
            Destroy(gameObject);
        }

        if (confront.gameObject.tag == "PlayerCar")
        {
            CarController.GetDamage(5);

            Destroy(gameObject);
        }
    }

    void Update()
    {
        this.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.SpeedEnemyCar));


        if (this.transform.position.y + this.transform.position.y <= -20)
        {
            Destroy(gameObject);
        }
    }
}
