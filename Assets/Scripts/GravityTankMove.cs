using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTankMove : MonoBehaviour
{

    public bool increase;
    private bool isCanMove = false;
    private bool isCanStart = false;
    private bool isCanDestroy = false;
    public float timeToDestroy;
    public float timeToStart;
    public Animator HpAnim;
    public float YHeight;
    public static bool isStarShoot = false;


    void Start()
    {
        Invoke("isStart", timeToStart);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCanStart)
        {
            if (transform.position.y < YHeight)
            {
                isCanMove = true;
                //HpAnim.SetBool("isStop", true);
                //HpAnim.SetFloat("speedA", 1.2f / timeToDestroy);
                isCanStart = false;
                isStarShoot = true;
            }
            else
            {
                this.transform.Translate(Vector3.down * (Time.deltaTime * 4f));
            }
        }

        if (isCanDestroy)
        {
            if (transform.position.y < -10f)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.Translate(Vector3.down * (Time.deltaTime * 6f));
            }
        }

        if (isCanMove)
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
    }

    void isStart()
    {
        isCanStart = true;
        Invoke("isDestroy", timeToDestroy);
    }

    void isDestroy()
    {
        isCanMove = false;
        isCanDestroy = true;
    }
}
