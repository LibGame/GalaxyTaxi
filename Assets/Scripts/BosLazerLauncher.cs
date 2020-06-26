using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosLazerLauncher : MonoBehaviour
{


    public Transform BulletOfDisgarge;
    public Rigidbody2D BulletPrefab;
    private Coroutine _shootingCoroutine;
    private int angles = 110;
    private Rigidbody2D[] lazers = new Rigidbody2D[3];


    public void StartBulletShooting()
    {
        _shootingCoroutine = StartCoroutine(LazerCoroutineSpawn());
    }

    public void StopBulletSooting()
    {
        StopCoroutine(_shootingCoroutine);
    }

    private void ShootLazer()
    {

        for (int i = 0; i < lazers.Length; i++)
        {
            lazers[i] = Instantiate(BulletPrefab, BulletOfDisgarge.position, Quaternion.Euler(0, 0, angles));
            angles += Random.Range(30, 90);
        }

        for (int j = 0; j < lazers.Length; j++)
        {
            lazers[j].velocity = lazers[j].transform.up * BosHelicopter.SpeedBullet;
        }


    }


    IEnumerator LazerCoroutineSpawn()
    {

        while (true)
        {
            angles = 110;
            ShootLazer();

            yield return new WaitForSeconds(BosHelicopter.LazerTurel);

        }
    }
}
