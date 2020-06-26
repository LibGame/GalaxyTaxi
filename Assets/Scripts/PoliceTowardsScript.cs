using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceTowardsScript : MonoBehaviour
{

    private GameObject PlayerCar;
    public float Speed = 5f;
    public float TimeIsUp = 3f;
    public float TimeToStart = 1f;
    public bool isTimeUp = false;
    public bool isStart = false;
    Rigidbody2D rigidbodyCar;


    void Start()
    {
        Invoke("ToStart", TimeToStart);
        PlayerCar = GameObject.FindWithTag("PlayerCar");
        rigidbodyCar = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        if (isStart)
        {
            if (isTimeUp != true)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                        PlayerCar.transform.position, Time.deltaTime * 5);
                var turn = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(Vector3.forward, PlayerCar.transform.position - this.transform.position), Time.deltaTime * 40f);
                rigidbodyCar.MoveRotation(turn.eulerAngles.z);

            }
            else
            {
                rigidbodyCar.velocity = rigidbodyCar.transform.up * GameProperties.SpeedEnemy;

                if (this.transform.position.y + this.transform.position.y <= -10 || this.transform.position.y + this.transform.position.y >= 10
                || this.transform.position.x + this.transform.position.x <= -10 || this.transform.position.x + this.transform.position.x >= 10)
                {
                    Destroy(gameObject);
                }

            }
        }
    }

    void TimeIsUpDestroy()
    {
        isTimeUp = true;
    }

    void ToStart()
    {
        isStart = true;
        Invoke("TimeIsUpDestroy", TimeIsUp);
    }


    private void OnTriggerEnter2D(Collider2D policeCarConfront)
    {
        if(policeCarConfront.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage == true)
            {
                Destroy(gameObject);
            }
            else if (CarController.isRage != true)
            {
                CarController.GetDamage(20);

                Destroy(gameObject);

            }
        }
        if (policeCarConfront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }
    }
}
