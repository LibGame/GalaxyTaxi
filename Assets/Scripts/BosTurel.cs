using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosTurel : MonoBehaviour
{
    public Transform Player;
    public Transform Turell;
    public Transform BulletOfDisgarge;
    public Rigidbody2D BulletPrefab;

    Rigidbody2D rigidbodyTurel;
    private Coroutine _shootingCoroutine;
    private bool _isShoot = false;



    void Start()
    {
        rigidbodyTurel = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (_isShoot)
        {
            var turn = Quaternion.Lerp(Turell.rotation,
                Quaternion.LookRotation(Vector3.forward, Player.position - Turell.position), Time.deltaTime * 4f);
            rigidbodyTurel.MoveRotation(turn.eulerAngles.z);
        }

    }



    public void StartBulletShooting()
    {
        _shootingCoroutine = StartCoroutine(BulletSpawn());
        _isShoot = true;
    }

    public void StopBulletSooting()
    {
        StopCoroutine(_shootingCoroutine);
        _isShoot = false;
    }


    IEnumerator BulletSpawn()
    {

        while (true)
        {
            var bullet = Instantiate(BulletPrefab, BulletOfDisgarge.position, BulletOfDisgarge.rotation);
            bullet.velocity = bullet.transform.up * BosHelicopter.SpeedBullet;

            yield return new WaitForSeconds(0.5f);

        }
    }
}