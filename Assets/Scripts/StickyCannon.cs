using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StickyCannon : MonoBehaviour
{
    public Transform Player;
    public Transform Turell;
    public Transform BUlletPosition;
    public Rigidbody2D PrefabOfBullets;
    Rigidbody2D rigidbodyGun;
    private bool _isChangeAngel;

    void Start()
    {
        rigidbodyGun = GetComponent<Rigidbody2D>();

    }


    void CannonAngle()
    {
        var turn = Quaternion.Lerp(Turell.rotation, Quaternion.LookRotation(Vector3.forward, -Player.position - Turell.position), Time.deltaTime * GameProperties.RotationTureSpeed1);
        rigidbodyGun.MoveRotation(turn.eulerAngles.z);
    }

    void FixedUpdate()
    {
        if (_isChangeAngel)
        {
            CannonAngle();
        }
    }

    public void StartShoot()
    {
        StartCoroutine(BulletSpawn());
        _isChangeAngel = true;
    }

    IEnumerator BulletSpawn()
    {

        while (true)
        {
            var bullet = Instantiate(PrefabOfBullets, BUlletPosition.position, Turell.rotation);
            bullet.velocity = -bullet.transform.up * GameProperties.HardSpeed;

            yield return new WaitForSeconds(3f);

        }
    }
}
