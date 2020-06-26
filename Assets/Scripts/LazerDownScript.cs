using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerDownScript : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
        if (this.transform.position.y + this.transform.position.y <= -20)
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

                Destroy(gameObject);

            }
        }

        if (Confront.gameObject.tag == "EnemyFarmCar")
        {
            Destroy(gameObject);
        }
        if (Confront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }

    }
}
