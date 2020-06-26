using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBullet : MonoBehaviour
{
    Rigidbody2D rigidbodyBullet;
    public float radius = 1.5f; // радиус вращения машины
    GameObject Player;
    Animator anim;
    private float timeToStopAnim;


    void Start()
    {
        rigidbodyBullet = GetComponent<Rigidbody2D>();
        timeToStopAnim = Random.Range(0.3f, 1.5f);
        anim = gameObject.GetComponent<Animator>();
        anim.SetFloat("speed", timeToStopAnim);
        Invoke("StopBullet", timeToStopAnim);


    }

    void Update()
    {
        transform.Rotate(0, 0, 2.0f);
        if (CarController.isUnderGravity)
        {

            Player.transform.RotateAround(transform.position, new Vector3(0, 0, radius), 30 * Time.deltaTime);
            Player.transform.position = Vector3.Lerp(Player.transform.position, transform.position, 0.1f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D confront)
    {

        if (confront.gameObject.tag == "PlayerCar")
        {
            Player = GameObject.FindWithTag("PlayerCar");

            CarController.isUnderGravity = true;
            CarController.isMoveCar = false;
            StartCoroutine(StartGravityCoroutine());
        }
    }

    IEnumerator StartGravityCoroutine()
    {

        while (true)
        {
            radius -= 0.05f;

            if (radius < 0.2f)
            {
                Destroy(gameObject);
                CarController.isMoveCar = true;
                Player.transform.rotation = Quaternion.Euler(0, 0, 0);

            }

            yield return new WaitForSeconds(0.4f);

        }

    }

    void StopBullet()
    {
        rigidbodyBullet.constraints = RigidbodyConstraints2D.FreezePosition;
        anim.SetBool("isChangeGravityAnimation", true);

    }

}
