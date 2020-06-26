using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class NeCroCarScript : MonoBehaviour
{
    private bool _isMoveDown = true;
    private Rigidbody2D rb;
    private int _isAtack = 0; // будет ли атаковать 0 не будет , 1 будет
    private bool _hitAtack; // Начинает атаковать 
    private bool _upOrDown; // вверх или в них true в верх , false в низ
    private int _lvlAtack; // уровень атак чем выше тем сложнее
    private bool _moveDown; // Начинает атаковать 
    private Animator Anim;

    System.Random rnd = new System.Random();


    private void OnTriggerEnter2D(Collider2D bulletConfront)
    {


        if (bulletConfront.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage == true)
            {

            }
            else if (CarController.isRage != true)
            {
                CarController.GetDamage(10);

            }
        }

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (transform.position.y < 3 && _isMoveDown)
        {
            StartAtack();
            _isMoveDown = false;
        }
        else if (_isMoveDown)
        {
            transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.SpeedEnemyCar));
        }

        if (_hitAtack)
        {
            MoveAtack();
        }
        else if(_moveDown)
        {

            MoveDownToDestroy();
        }

    }


    private void StartAtack()
    {
        Anim.SetBool("isIdle", true);
        int period = 5; // предел атаки
        _isAtack = UnityEngine.Random.Range(0, 10);
        _lvlAtack++;

        if (_lvlAtack > 10)
        {
            period = 8;
        }

        if (_isAtack < period)
        {
            _hitAtack = true;
            _upOrDown = false;
            Anim.SetBool("isBack", false);
            Anim.SetBool("isIdle", false);
        }
        else
        {

            _hitAtack = false;
            Invoke("ReturnAtack", 2f);
        }
    }

    private void MoveDownToDestroy()
    {
        if(transform.position.y > -10)
        {
            transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.SpeedEnemyCar));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ReturnAtack()
    {


        Anim.SetBool("isBack", false);
        Anim.SetBool("isIdle", false);

        _hitAtack = true;
        _upOrDown = true;
    }

    private void MoveAtack()
    {

        if (_upOrDown)
        {
            if (this.transform.position.y < 2)
            {
                transform.Translate(Vector3.up * (Time.deltaTime * GameProperties.SpeedEnemyCar));

            }
            else
            {               
                if (NeCroBos.isStopedAtack)
                {
                    _hitAtack = false;


                    _moveDown = true;
                }
                else
                {
                    StartAtack();

                }
            }
        }
        else
        {
            if (this.transform.position.y > -3.4)
            {
                transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.SpeedEnemyCar));
            }
            else
            {
                Anim.SetBool("isBack", true);
                Anim.SetBool("isIdle", false);
                _upOrDown = true;
            }
        }

    }

}
