using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{

    public GameObject Tank;
    public GameObject AllElementsTank;
    public float DestroyTime; 
    public bool MoveTank = true;
    public bool isStart = false;
    public static bool isDestroy = false;
    public float YHeight = 1;
    public float TimeToStart = 4f;
    public static bool isShoot = false;
    public bool increase = true;
    public bool CanStart = false;
    public Animator HpAnim;
    public TurelScript turelScript;

    void Start()
    {
        Invoke("MakeStartTank", TimeToStart);
        Invoke("DestroyTank", DestroyTime);
        HpAnim.SetFloat("speedA", 1f / DestroyTime);


    }

    void Update()
    {

        if (isDestroy)
        {
            isStart = false;

            Tank.transform.Translate(Vector3.up * (Time.deltaTime * GameProperties.TankMoveSpeed));

            if (Tank.transform.position.y >= 10)
            {
                Destroy(AllElementsTank);
            }
        }

        if (isStart == true) 
        {
            if (increase)
            {
                if (this.transform.position.x < 2)
                    transform.Translate(Vector3.right * (Time.deltaTime * GameProperties.speedHelio));
                else
                    increase = false;
            }
            else
            {
                if (this.transform.position.x > -2)
                    transform.Translate(Vector3.left * (Time.deltaTime * GameProperties.speedHelio));
                else
                    increase = true;
            }
        }


        if(CanStart)
        {
            if(this.transform.position.y < YHeight)
            {
                isStart = true;
                CanStart = false;
                turelScript.StartBulletShooting();
                HpAnim.SetBool("isStop", true);

            }
            else
            {
                transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.speedHelio));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D TankConfront)
    {

        if (TankConfront.gameObject.tag == "DestroyerMap")
        {
            Destroy(AllElementsTank);
        }
    }

    public void MakeStartTank()
    {
        CanStart = true;
    }

    public void DestroyTank()
    {
        turelScript.StopShoot();
        isDestroy = true;

    }

}
