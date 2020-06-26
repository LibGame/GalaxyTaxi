using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosBulletScript : MonoBehaviour
{

    public GameObject anim;


    void FixedUpdate()
    {
        if (this.transform.position.y + this.transform.position.y <= -10 || this.transform.position.y + this.transform.position.y >= 10
        || this.transform.position.x + this.transform.position.x <= -10 || this.transform.position.x + this.transform.position.x >= 10)
        {
            Destroy(gameObject);
        }
    }

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
                CarController.GetDamage(2);
                Instantiate(anim, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                Destroy(gameObject);

            }


            if (bulletConfront.gameObject.tag == "DestroyerMap")
            {
                Destroy(gameObject);
            }
        }

    }
}
