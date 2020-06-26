using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeCroAlive : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rigidbodyNecromant;
    private float distance;
    public float LimitDistance;


    void Start()
    {
        Player = GameObject.Find("carPlayer");
        Invoke("DestroyNecromant", 10f);
        rigidbodyNecromant = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, Player.transform.position);

        if(distance >= 2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position,Time.deltaTime * GameProperties.RocketSpeed);
        }

        var turn = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, -Player.transform.position - transform.position), Time.deltaTime * 500f);
        rigidbodyNecromant.MoveRotation(turn.eulerAngles.z);
    }

    private void DestroyNecromant()
    {
        Destroy(gameObject);
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
                CarController.GetDamage(10);

            }
        }

    }

}
