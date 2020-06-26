using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeCroDeadHand : MonoBehaviour
{
    private Rigidbody2D rigidbodyCharge;

    void Start()
    {
        rigidbodyCharge = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        var turn = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward,- new Vector3(0, 0, 0) - transform.position), Time.deltaTime * 500f);
        rigidbodyCharge.MoveRotation(turn.eulerAngles.z);

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), Time.deltaTime * 8f);

        if(transform.position.Equals(new Vector3(0, 0, 0)))
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

        if (Confront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }

    }
}
