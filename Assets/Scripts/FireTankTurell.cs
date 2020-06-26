using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTankTurell : MonoBehaviour
{

    public Rigidbody2D bulletPrefabs;
    public Transform BulletOfDisgarge;
    public Transform Player;
    public Transform Turell;
    public float rndMines;
    public float rotationPos;
    Rigidbody2D rigidbodyTurel;

    void Start()
    {
        rigidbodyTurel = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FireTank.isCanShoot)
        {
            var turn = Quaternion.Lerp(Turell.rotation,
                 Quaternion.LookRotation(Vector3.forward, Player.position - Turell.position), Time.deltaTime * 4f);
            rigidbodyTurel.MoveRotation(turn.eulerAngles.z);

            rndMines = Random.Range(-20f, 20f);

            var bullet = Instantiate(bulletPrefabs, BulletOfDisgarge.position, BulletOfDisgarge.rotation);
            bullet.transform.Rotate(BulletOfDisgarge.rotation.x, BulletOfDisgarge.rotation.y, BulletOfDisgarge.rotation.z - rndMines);
            bullet.velocity = bullet.transform.up * GameProperties.FireBulletSpeed;
        }
    }
}
