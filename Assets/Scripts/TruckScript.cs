using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour
{

    public GameObject Truck;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.right * (Time.deltaTime * GameProperties.BackGroundSpeed));


        if (this.transform.position.y + this.transform.position.y <= -20)
        {
            Destroy(Truck);
        }

    }


    private void OnTriggerEnter2D(Collider2D TruckConfront)
    {


        if (TruckConfront.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage == true)
            {
                Destroy(Truck);
            }
            else if (CarController.isRage != true)
            {
                CarController.GetDamage(30);
            }
        }

    }
}
