using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkBullet : MonoBehaviour
{
    private Transform Player;
    private Rigidbody2D rigidbodyBullet;
    private bool isChangeAngel = true;
    private float _distance;
    private float limitDistance;
    private float timeToDestoy;
    private Vector3 posPlayer;
    [SerializeField]
    private int _damage = 1;

    void Start()
    {
        rigidbodyBullet = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("carPlayer").GetComponent<Transform>();
        posPlayer = Player.position;
        _distance = Vector3.Distance(posPlayer, transform.position);
        timeToDestoy = _distance / GameProperties.RocketSpeed + 0.3f;
        Invoke("DestroyArcBullet", timeToDestoy);
        limitDistance = _distance / 1.3f;
    }


    void Update()
    {

        transform.position += transform.up * Time.deltaTime * GameProperties.RocketSpeed;
        _distance = Vector3.Distance(posPlayer, transform.position);


        if (_distance < limitDistance && isChangeAngel)
        {
            var turn = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(Vector3.forward, posPlayer - transform.position), Time.deltaTime * 2.1f);
            rigidbodyBullet.MoveRotation(turn.eulerAngles.z);
        }


        if (transform.position.y + transform.position.y <= -10 || transform.position.y + transform.position.y >= 10
            || transform.position.x + transform.position.x <= -10 || transform.position.x + transform.position.x >= 10)
        {
            Destroy(gameObject);
        }
    }


    private void DestroyArcBullet()
    {
        isChangeAngel = false;
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
