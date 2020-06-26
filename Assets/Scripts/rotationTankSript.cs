using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationTankSript : MonoBehaviour
{
    public GameObject[] BUlletPosition;

    public Rigidbody2D PrefabOfBullets;
    public static bool isCanShoot = false;
    public GameObject AllEnemy;
    public Transform startMarker;
    public Transform endMarker;
    public bool isCanStart = false;
    public bool isMove = false;
    private bool isCanDestroy = false;
    public float speed = 1.0F;
    public float timeToStart = 5f;
    public float timeToDestroy;
    public float YHeight;
    public Animator HpAnim;


    void Start()
    {
        Invoke("TimeToStart", timeToStart);

    }


    void StartAtack()
    {
        var bullet1 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[0].transform.position.x, BUlletPosition[0].transform.position.y, 0), BUlletPosition[0].transform.rotation);
        var bullet2 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[1].transform.position.x, BUlletPosition[1].transform.position.y, 0), BUlletPosition[1].transform.rotation);
        var bullet3 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[2].transform.position.x, BUlletPosition[2].transform.position.y, 0), BUlletPosition[2].transform.rotation);
        var bullet4 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[4].transform.position.x, BUlletPosition[4].transform.position.y, 0), BUlletPosition[4].transform.rotation);
        var bullet5 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[5].transform.position.x, BUlletPosition[5].transform.position.y, 0), BUlletPosition[5].transform.rotation);
        var bullet6 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[6].transform.position.x, BUlletPosition[6].transform.position.y, 0), BUlletPosition[6].transform.rotation);
        var bullet7 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[7].transform.position.x, BUlletPosition[7].transform.position.y, 0), BUlletPosition[7].transform.rotation);
        var bullet8 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[8].transform.position.x, BUlletPosition[8].transform.position.y, 0), BUlletPosition[8].transform.rotation);
        var bullet9 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[9].transform.position.x, BUlletPosition[9].transform.position.y, 0), BUlletPosition[9].transform.rotation);
        var bullet10 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[10].transform.position.x, BUlletPosition[10].transform.position.y, 0), BUlletPosition[10].transform.rotation);
        var bullet11 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[11].transform.position.x, BUlletPosition[11].transform.position.y, 0), BUlletPosition[11].transform.rotation);
        var bullet12 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[12].transform.position.x, BUlletPosition[12].transform.position.y, 0), BUlletPosition[12].transform.rotation);
        var bullet13 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[13].transform.position.x, BUlletPosition[13].transform.position.y, 0), BUlletPosition[13].transform.rotation);
        var bullet14 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[14].transform.position.x, BUlletPosition[14].transform.position.y, 0), BUlletPosition[14].transform.rotation);
        var bullet15 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[15].transform.position.x, BUlletPosition[15].transform.position.y, 0), BUlletPosition[15].transform.rotation);
        var bullet16 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[16].transform.position.x, BUlletPosition[16].transform.position.y, 0), BUlletPosition[16].transform.rotation);
        var bullet17 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[17].transform.position.x, BUlletPosition[17].transform.position.y, 0), BUlletPosition[17].transform.rotation);
        var bullet18 = Instantiate(PrefabOfBullets, new Vector3(BUlletPosition[18].transform.position.x, BUlletPosition[18].transform.position.y, 0), BUlletPosition[18].transform.rotation);



        bullet1.velocity = bullet1.transform.up * GameProperties.HardSpeed;
        bullet2.velocity = bullet2.transform.up * GameProperties.HardSpeed;
        bullet3.velocity = bullet3.transform.up * GameProperties.HardSpeed;
        bullet4.velocity = bullet4.transform.up * GameProperties.HardSpeed;
        bullet5.velocity = bullet5.transform.up * GameProperties.HardSpeed;
        bullet6.velocity = bullet6.transform.up * GameProperties.HardSpeed;
        bullet7.velocity = bullet7.transform.up * GameProperties.HardSpeed;
        bullet8.velocity = bullet8.transform.up * GameProperties.HardSpeed;
        bullet9.velocity = bullet9.transform.up * GameProperties.HardSpeed;
        bullet10.velocity = bullet10.transform.up * GameProperties.HardSpeed;
        bullet11.velocity = bullet11.transform.up * GameProperties.HardSpeed;
        bullet12.velocity = bullet12.transform.up * GameProperties.HardSpeed;
        bullet13.velocity = bullet13.transform.up * GameProperties.HardSpeed;
        bullet14.velocity = bullet14.transform.up * GameProperties.HardSpeed;
        bullet15.velocity = bullet15.transform.up * GameProperties.HardSpeed;
        bullet16.velocity = bullet16.transform.up * GameProperties.HardSpeed;
        bullet17.velocity = bullet17.transform.up * GameProperties.HardSpeed;
        bullet18.velocity = bullet18.transform.up * GameProperties.HardSpeed;
    }

    void Update()
    {

        // Distance moved equals elapsed time times speed..
        if (isCanStart)
        {
            if(transform.position.y < YHeight)
            {
                isMove = true;
                HpAnim.SetBool("isStop", true);
                HpAnim.SetFloat("speedA", 1.3f / timeToDestroy);
                isCanStart = false;
            }
            else
            {
                this.transform.Translate(Vector3.down * (Time.deltaTime * 4f));
            }
        }

        if(isMove)
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Time.deltaTime * GameProperties.RotationSpeedTank);



        if (isCanShoot)
        {
            StartAtack();
            isCanShoot = false;
        }

        if (isCanDestroy)
        {
            if (transform.position.y < -10f)
            {
                Destroy(AllEnemy);
            }
            else
            {
                transform.Translate(Vector3.down * (Time.deltaTime * 6f));
            }
        }

    }

    void TimeToStart()
    {
        isCanStart = true;
        Invoke("ChangeSpeed", 5f);
        Invoke("ItCanDestory", timeToDestroy);
    }

    void ChangeSpeed()
    {
        GameProperties.RotationSpeedTank = 3f;
    }

    void ItCanDestory()
    {
        isMove = false;
        isCanDestroy = true;
    }
}
