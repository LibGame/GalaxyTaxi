using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTankTurel : MonoBehaviour
{
    public GameObject Player;
    public Transform Turell;
    public Transform BUlletPosition;
    public Rigidbody2D PrefabOfBullets;
    Rigidbody2D rigidbodyTurell;


    void Start()
    {
        rigidbodyTurell = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GravityTankMove.isStarShoot)
        {
            StartCoroutine(BulletSpawn());
            GravityTankMove.isStarShoot = false;
        }

        var turn = Quaternion.Lerp(Turell.rotation, Quaternion.LookRotation(Vector3.forward, Player.transform.position - Turell.position), Time.deltaTime * GameProperties.RotationTureSpeed1);
        rigidbodyTurell.MoveRotation(turn.eulerAngles.z);

    }

    IEnumerator BulletSpawn()
    {

        while (true)
        {
            if (CarController.isUnderGravity != true)
            {
                var bullet = Instantiate(PrefabOfBullets, BUlletPosition.position, Turell.rotation);
                bullet.velocity = bullet.transform.up * GameProperties.RocketSpeed;
            }

            yield return new WaitForSeconds(4f);

        }
    }

}
