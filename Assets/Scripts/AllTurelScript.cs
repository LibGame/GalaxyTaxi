using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllTurelScript : MonoBehaviour
{
    private GameObject Player;
    public Transform Turell;
    public Transform BUlletPosition;
    public Rigidbody2D PrefabOfBullets;

    public float BulletSpeed = 50f;
    public float Rotation;

    public static bool isKick = false;
    public static bool isCanShoot = true;


    void Start()
    {
        Player = GameObject.FindWithTag("PlayerCar");

        var turnOfBullet = Quaternion.Lerp(BUlletPosition.rotation, Quaternion.LookRotation(Vector3.forward, Player.transform.position - BUlletPosition.position), Time.deltaTime * GameProperties.RotationTureSpeed);
        var rigidbodyBullet = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (WildBikeMove.isShoot)
            StartCoroutine(BulletSpawn());

        if (WildBikeMove.Shoot != true)
        {
            StopAllCoroutines();
        }



        var turn = Quaternion.Lerp(Turell.rotation, Quaternion.LookRotation(Vector3.forward, Player.transform.position - Turell.position), Time.deltaTime * GameProperties.RotationTureSpeed1);
        var rigidbody = GetComponent<Rigidbody2D>();
        var PrefabOfBullets = GetComponent<Rigidbody2D>();


        rigidbody.MoveRotation(turn.eulerAngles.z);
    }


    IEnumerator BulletSpawn()
    {
        WildBikeMove.isShoot = false;
        print("start");
        isKick = false;
        while (true)
        {

            var bullet = Instantiate(PrefabOfBullets, BUlletPosition.position, Turell.rotation);
            bullet.velocity = bullet.transform.up * GameProperties.RocketSpeed;
            yield return new WaitForSeconds(0.3f);

        }
    }
}
