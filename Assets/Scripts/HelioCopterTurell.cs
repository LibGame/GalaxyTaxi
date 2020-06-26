using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelioCopterTurell : MonoBehaviour
{
    public Transform Player;
    public Transform Turell;
    public Transform RacketOfDisgarge;
    public GameObject RocketPrefab;
    Rigidbody2D rigidbodyTurel;

    public static bool isShoot = false;

    public static float timeToStart = 1f;


    void Start()
    {
        rigidbodyTurel = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isShoot)
        {
            StartCoroutine(BulletSpawn());
            isShoot = false;
        }
        

        var turn = Quaternion.Lerp(Turell.rotation, Quaternion.LookRotation(Vector3.forward, Player.position - Turell.position), Time.deltaTime * 4f);
        rigidbodyTurel.MoveRotation(turn.eulerAngles.z);

    }

    IEnumerator BulletSpawn()
    {
        while (true)
        {

            Instantiate(RocketPrefab, RacketOfDisgarge.position, RacketOfDisgarge.rotation);

            yield return new WaitForSeconds(3f);

        }
    }

}
