using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeCroContrackt : MonoBehaviour
{
    private GameObject Necromant;
    private GameObject Player;
    private Rigidbody2D rigidbodyCharge; 
    public float angle = 0; // угол 
    public float radius = 0.5f; // радиус
    private bool isCircle = true; // условие движения по кругу
    private CarController _carController;

    void Start()
    {
        rigidbodyCharge = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("carPlayer");
        Necromant = GameObject.Find("NecroBos");

        Invoke("shootAtPlayer", 5f);
    }

    private void Update()
    {
        if (isCircle)
        {
            angle += Time.deltaTime; // меняется плавно значение угла
            var turn = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, Player.transform.position - transform.position), Time.deltaTime * 500f);
            rigidbodyCharge.MoveRotation(turn.eulerAngles.z);
            var x = Mathf.Cos(angle * 4f) * radius;
            var y = Mathf.Sin(angle * 4f) * radius;
            transform.position = new Vector2(x, y) + new Vector2(Necromant.transform.position.x, Necromant.transform.position.y);
        }
        else
        {
            if (this.transform.position.y + this.transform.position.y <= -10 || this.transform.position.y + this.transform.position.y >= 10
                || this.transform.position.x + this.transform.position.x <= -10 || this.transform.position.x + this.transform.position.x >= 10)
            {
                Destroy(gameObject);
            }
        }

        if (NeCroBos._isCanDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void shootAtPlayer()
    {
        isCircle = false;

        rigidbodyCharge.velocity = rigidbodyCharge.transform.up * GameProperties.RocketSpeed;

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
                if(CarController.Life != 100)
                {
                    CarController.GetDamage(-40);

                }
                _carController = Player.GetComponent<CarController>();
                _carController.payContrackt();
                Destroy(gameObject);

            }
        }

        if (Confront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }

    }
}
