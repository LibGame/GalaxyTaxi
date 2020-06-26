using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienForthBullet : MonoBehaviour
{
    private Rigidbody2D bulletRigidbody;
    private Transform Player;

    private void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("carPlayer").GetComponent<Transform>();

        var turn = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(Vector3.forward, Player.position - transform.position), Time.deltaTime * 20000);
        bulletRigidbody.MoveRotation(turn.eulerAngles.z);
    }

    private void Update()
    {

        transform.position += transform.up * Time.deltaTime * GameProperties.RocketSpeed;


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
                CarController.GetDamage(5);
                Destroy(gameObject);

            }
        }

        if (bulletConfront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }


    }
}
