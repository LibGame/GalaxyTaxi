using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosRocketLauncher1 : MonoBehaviour
{
    public Transform RacketOfDisgarge;
    public Rigidbody2D RocketPrefab;

    private Coroutine _shootingCoroutine;

    public void StartBulletShooting()
    {
        _shootingCoroutine = StartCoroutine(BulletSpawn());
    }

    public void StopBulletSooting()
    {
        StopCoroutine(_shootingCoroutine);
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
