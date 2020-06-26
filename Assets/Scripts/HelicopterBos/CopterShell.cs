using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterShell : MonoBehaviour
{
    private GameObject _playerCar;
    private Vector3 playerPos;
    private bool isCanAtack;
    private Rigidbody2D _objectRb;
    public int Damage = 20;



    private void Start()
    {
        _playerCar = GameObject.Find("carPlayer");
        _objectRb = GetComponent<Rigidbody2D>();
        Invoke("StartAtack", 0.8f);


    }


    private void Update()
    {
        if (isCanAtack)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * GameProperties._speed);
            var turn = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, playerPos - transform.position), Time.deltaTime * 500f);
            _objectRb.MoveRotation(turn.eulerAngles.z);

            if (transform.position.Equals(playerPos))
            {
                Destroy(gameObject);
            }
        }
    }

    private void StartAtack()
    {
        playerPos = _playerCar.transform.position;
        isCanAtack = true;

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
                CarController.GetDamage(1);

                Destroy(gameObject);

            }
        }

        if (bulletConfront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }


    }
}
