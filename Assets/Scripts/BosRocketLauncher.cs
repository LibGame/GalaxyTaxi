using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosRocketLauncher : MonoBehaviour
{
    public Transform RacketOfDisgarge;
    public Rigidbody2D RocketPrefab;
    public GameObject ArkBullet;

    private Coroutine _shootingCoroutine;
    private Coroutine _arkShootingCoroutine;


    public void StartBulletShooting()
    {
        _shootingCoroutine = StartCoroutine(BulletSpawn());
    }

    public void StopBulletSooting()
    {
        if(_shootingCoroutine != null)
        {
            StopCoroutine(_shootingCoroutine);
        }
    }

    public void StartArkBulletShooting()
    {
        _arkShootingCoroutine = StartCoroutine(arkBulletSpawn());
    }

    public void StopArkBulletSooting()
    {
        if(_arkShootingCoroutine != null)
        {
            StopCoroutine(_arkShootingCoroutine);

        }
    }

    IEnumerator arkBulletSpawn()
    {
        while (true)
        {
            Instantiate(ArkBullet, RacketOfDisgarge.position, ArkBullet.transform.rotation);
            yield return new WaitForSeconds(0.5f);

        }
    }

    IEnumerator BulletSpawn()
    {
        while (true)
        {
            Instantiate(RocketPrefab, RacketOfDisgarge.position, RacketOfDisgarge.rotation);
            yield return new WaitForSeconds(1f);

        }
    }
}
