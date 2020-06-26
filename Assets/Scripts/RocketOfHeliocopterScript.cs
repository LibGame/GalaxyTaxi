using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketOfHeliocopterScript : MonoBehaviour
{
    public Transform RocketPosition;
    public float TimeIsUp = 1f;
    private bool isTimeUp = false;
    private bool isStart = true;
    Rigidbody2D rigidbodyRocket;
    GameObject PlayerCar;

    void Start()
    {
        Invoke("TimeIsUpDestroy", TimeIsUp);
        rigidbodyRocket = GetComponent<Rigidbody2D>();
        PlayerCar = GameObject.Find("carPlayer");
    }


    void Update()
    {

        if (this.transform.position.y + this.transform.position.y <= -10 || this.transform.position.y + this.transform.position.y >= 10
           || this.transform.position.x + this.transform.position.x <= -10 || this.transform.position.x + this.transform.position.x >= 10)
        {
            Destroy(gameObject);
        }

        if (isStart)
        {
            if (isTimeUp != true)
            {
                var turn = Quaternion.Lerp(RocketPosition.rotation, Quaternion.LookRotation(Vector3.forward, PlayerCar.transform.position - RocketPosition.position), Time.deltaTime * 40f);
                rigidbodyRocket.MoveRotation(turn.eulerAngles.z);
                transform.position = Vector2.MoveTowards(transform.position,
                                        PlayerCar.transform.position, GameProperties.BosRocket * Time.deltaTime);
            }
            else
            {
                rigidbodyRocket.velocity = rigidbodyRocket.transform.up * BosHelicopter.SpeedRocket;
            }
        }
    }

    void TimeIsUpDestroy()
    {
        isTimeUp = true;
    }



    private void OnTriggerEnter2D(Collider2D rocketConfront)
    {
        if (rocketConfront.gameObject.tag == "PlayerCar")
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

        if (rocketConfront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }
    }
}
