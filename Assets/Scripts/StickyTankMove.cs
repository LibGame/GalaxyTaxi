using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyTankMove : MonoBehaviour
{
    private bool _isCanMove = false;
    private bool _isCanStart = false;
    private bool _isCanDestroy = false;
    public float _timeToDestroy;
    public float _timeToStart;
    public Animator HpAnim;
    public float YHeight;
    private bool increase;
    public StickyCannon gun;
    
    void Start()
    {
        Invoke("isStart", _timeToStart);

    }
    
    void Update()
    {
        if (_isCanStart)
        {
            if (transform.position.y < YHeight)
            {
                _isCanMove = true;
                gun.StartShoot();
                HpAnim.SetBool("isStop", true);
                HpAnim.SetFloat("speedA", 1f / _timeToDestroy);
                _isCanStart = false;
            }
            else
            {
                this.transform.Translate(Vector3.down * (Time.deltaTime * 4f));
            }
        }

        if (_isCanDestroy)
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


        if (_isCanMove)
        {
            MoveTank(); // двигем танк
        }
    }

    void MoveTank() // отвечает за движение танка влево , вправо
    {
        if (increase)
        {
            if (this.transform.position.x < 1)
                transform.Translate(Vector3.right * (Time.deltaTime * GameProperties.SpeedBarnel));
            else
                increase = false;
        }
        else
        {
            if (this.transform.position.x > -1)
                transform.Translate(Vector3.left * (Time.deltaTime * GameProperties.SpeedBarnel));
            else
                increase = true;
        }
        
    }

    void isStart() // если пришло твое время
    {
        _isCanStart = true;
        Invoke("isDestroy", _timeToDestroy);
    }

    void isDestroy() // танк ликвидируеться
    {
        _isCanMove = false;
        _isCanDestroy = true;
    }
}
