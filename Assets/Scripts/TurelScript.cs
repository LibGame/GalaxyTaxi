using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TurelScript : MonoBehaviour
{

    public Transform Player;
    public Transform Turell;
    public Transform BUlletPosition;
    public Rigidbody2D PrefabOfBullets;
    public float BulletSpawnSpeed = 0.5f;
    public float Rotation;
    private Coroutine _shootingCoroutine;
    private Coroutine _shootingRocketCoroutine;
    Rigidbody2D rigidbodyTurell;

    void Start()
    {
       
        var turnOfBullet = Quaternion.Lerp(BUlletPosition.rotation, Quaternion.LookRotation(Vector3.forward, Player.position - BUlletPosition.position), Time.deltaTime * GameProperties.RotationTureSpeed);
        var rigidbodyBullet = GetComponent<Rigidbody2D>();
        rigidbodyTurell = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {


        var turn = Quaternion.Lerp(Turell.rotation, Quaternion.LookRotation(Vector3.forward, Player.position - Turell.position), Time.deltaTime * GameProperties.RotationTureSpeed1);
        rigidbodyTurell.MoveRotation(turn.eulerAngles.z);
    }


    public void StartBulletShooting()
    {
        _shootingCoroutine = StartCoroutine(BulletSpawn());

    }

    public void StartRocketShooting()
    {
        _shootingRocketCoroutine = StartCoroutine(RocketSpawn());
    }

    public void StopShoot()
    {
        if(_shootingCoroutine != null)
        {
            StopCoroutine(_shootingCoroutine);
        }else if(_shootingRocketCoroutine != null)
        {
            StopCoroutine(_shootingRocketCoroutine);

        }
    }

    IEnumerator BulletSpawn()
    {

            while (true)
            {

            var bullet = Instantiate(PrefabOfBullets, BUlletPosition.position, Turell.rotation);
            bullet.velocity = bullet.transform.up * GameProperties.BulletSped;

            yield return new WaitForSeconds(0.5f);

            }
    }

    IEnumerator RocketSpawn()
    {

        while (true)
        {


            Instantiate(PrefabOfBullets, BUlletPosition.position, Turell.rotation);

            yield return new WaitForSeconds(1f);

        }
    }
}
