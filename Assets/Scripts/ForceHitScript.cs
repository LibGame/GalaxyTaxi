using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ForceHitScript : MonoBehaviour
{

    public bool isMove = true;
    public GameObject[] point;
    public static bool isCanConfront = true;
    Rigidbody2D rigidbodyCar;
    public static bool isForce = false;
    public Transform Player;
    public Transform Turell;
    public float thrust = 1f;
    public Vector2 cachedCenter;
    public float angle = 0; // угол 
    private float radius = 10f; // радиус
    public bool isCircle = false; // условие движения по кругу
    public float speed;
    public bool isForceMove = false;
    public bool isJumpForce = false;
    public int NumberOfForcePoint = 0;
    public int TankPlacePoint = 0;
    public int isWillAtack = 0;
    public bool CircleMove = false;
    private float xPos;
    private float yPos;
    private bool ReturnMove = true;
    private float TimeToCheck;
    System.Random rnd = new System.Random();

    public bool isCanStart = false;
    public bool isCanDestroy = false;
    public float timeToDestroy;
    public float timeToStart;
    public Animator HpAnim;
    public float YHeight;

    void Start()
    {
        rigidbodyCar = GetComponent<Rigidbody2D>();
        NumberOfForcePoint = rnd.Next(1, 5);
        Invoke("isStart", timeToStart);

    }

    // Update is called once per frame

    double RoundToIncrement(float x, float m)
    {
        return Math.Round(x / m) * m;
    }

    void Update()
    {

        if (isCanStart)
        {
            if (transform.position.y < YHeight)
            {
                isMove = true;
                isForceMove = true;
                isCanStart = false;
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

        if (isMove)
        {


            if (ReturnMove)
            {
                TimeToCheck += Time.deltaTime * 2f;

                if (TimeToCheck >= 1.5f)
                {
                    xPos = transform.position.x;
                    yPos = transform.position.y;
                }

                if (xPos == transform.position.x && yPos == transform.position.y)
                {
                    TimeToCheck = 0;
                    rigidbodyCar.constraints = RigidbodyConstraints2D.FreezePosition;
                    isForce = false;
                    isJumpForce = false;
                    isForceMove = true;
                    Invoke("BackFrezzePosition", 0.3f);
                    NumberOfForcePoint = rnd.Next(1, 5);
                    TankPlacePoint = 2;
                    if (NumberOfForcePoint == TankPlacePoint)
                    {
                        NumberOfForcePoint = rnd.Next(1, 5);
                        if (NumberOfForcePoint == TankPlacePoint)
                        {
                            NumberOfForcePoint = rnd.Next(1, 5);
                            if (NumberOfForcePoint == TankPlacePoint)
                            {
                                NumberOfForcePoint = rnd.Next(1, 5);

                            }
                        }
                    }
                }
            }

            if(CircleMove != true)
            {
                // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
                Vector2 leftBot = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
                Vector2 rightTop = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
                Vector2 Top = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
                Vector2 Bottom = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

                // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
                float x_left = leftBot.x + 0.1f;
                float x_right = rightTop.x - 0.1f;
                float y_Top = Top.y + 0.1f;
                float y_Bottom = Bottom.y - 0.1f;

                // ограничиваем объект в плоскости XZ
                Vector2 clampedPos = transform.position;

                clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
                clampedPos.y = Mathf.Clamp(clampedPos.y, y_Top, y_Bottom);
                transform.position = clampedPos;
            }

            if (isForceMove && CircleMove != true)
            {

                if (NumberOfForcePoint == 1)
                {
                    transform.position = Vector3.Lerp(transform.position, point[0].transform.position, Time.deltaTime * 1f);
                }
                else if (NumberOfForcePoint == 2)
                {
                    transform.position = Vector3.Lerp(transform.position, point[1].transform.position, Time.deltaTime * 1f);
                }
                else if (NumberOfForcePoint == 3)
                {
                    transform.position = Vector3.Lerp(transform.position, point[2].transform.position, Time.deltaTime * 1f);
                }
                else if (NumberOfForcePoint == 4)
                {
                    transform.position = Vector3.Lerp(transform.position, point[3].transform.position, Time.deltaTime * 1f);
                }
            }

            if (CircleMove)
            {
                if (angle <= 3f)
                {
                    angle += Time.deltaTime; // меняется плавно значение угла
                }
                else
                {
                    isForceMove = true;
                    isForce = false;
                    CircleMove = false;
                    isJumpForce = false;
                    NumberOfForcePoint = rnd.Next(1, 5);
       
                }

                var x = Mathf.Sin(angle * speed) * radius;
                var y = Mathf.Cos(angle * speed) * radius;

                transform.position = new Vector2(x, y) + cachedCenter - new Vector2(0, radius);
            }

            if (isForce && CircleMove != true)
            {
                if (isJumpForce)
                {
                    rigidbodyCar.AddForce(transform.up * GameProperties.SpeedEnemy, ForceMode2D.Impulse);

                }
                else
                {
                    var turn = Quaternion.Lerp(Turell.rotation,
                     Quaternion.LookRotation(Vector3.forward, Player.position - Turell.position), Time.deltaTime * 4f);
                    rigidbodyCar.MoveRotation(turn.eulerAngles.z);
                }
 
            }

        }
    }

    void JumpForce()
    {
        isJumpForce = true;

    }
    void isStart()
    {
        isCanStart = true;
        Invoke("isDestroy", timeToDestroy);
    }

    void isDestroy()
    {
        isMove = false;
        isCanDestroy = true;
    }

    void BackFrezzePosition()
    {
        rigidbodyCar.constraints = RigidbodyConstraints2D.None;

    }

    private void OnTriggerEnter2D(Collider2D confront)
    {

        if (confront.gameObject.tag == "UpDown" && CarController.RightLeft != true)
        {
            CarController.UpDown = true;
            CarController.RightLeft = false;
            CarController.isCanMove = false;
            if (Player.position.y < transform.position.y)
            {
                CarController.Direction = 2;
            }
            else
            {
                CarController.Direction = 1;

            }

        }
        if (confront.gameObject.tag == "RightLeft" && CarController.UpDown != true)
        {
            CarController.RightLeft = true;
            CarController.UpDown = false;
            CarController.isCanMove = false;

            if (Player.position.x < transform.position.x)
            {
                CarController.Direction = 4;
                

            }
            else
            {
                CarController.Direction = 3;
                

            }
        }

        if (confront.gameObject.tag == "FirePoint")
        {
            if (CircleMove != true)
            {
                rigidbodyCar.constraints = RigidbodyConstraints2D.FreezePosition;
                isForce = false;
                isJumpForce = false;

                isForceMove = true;
                Invoke("BackFrezzePosition", 0.3f);
                NumberOfForcePoint = rnd.Next(1, 5);
     
            }

        }

        if (confront.gameObject.tag == "PlayerCar")
        {
            isForceMove = true;
            isForce = false;
            angle = 0;
            CircleMove = false;

            NumberOfForcePoint = rnd.Next(1, 5);

        }


        if (confront.gameObject.tag == "ForcePoint1")
        {
            isWillAtack = rnd.Next(1, 5);
            if(isWillAtack == 1)
            {
                isForceMove = true;
                isForce = false;
                NumberOfForcePoint = rnd.Next(1, 5);
                TankPlacePoint = 1;
                if (NumberOfForcePoint == TankPlacePoint)
                {
                    NumberOfForcePoint = rnd.Next(1, 5);
                    if (NumberOfForcePoint == TankPlacePoint)
                    {
                        NumberOfForcePoint = rnd.Next(1, 5);
                        if (NumberOfForcePoint == TankPlacePoint)
                        {
                            NumberOfForcePoint = rnd.Next(1, 5);

                        }
                    }
                }
            }
            else if(isWillAtack == 2)
            {
                isForce = true;
                isForceMove = false;
                Invoke("JumpForce", 0.5f);
            }else if(isWillAtack == 3)
            {
                radius = Vector3.Distance(transform.position, Player.position);
                radius = radius / 2;
                cachedCenter = transform.position;
                isForceMove = false;
                isForce = false;
                CircleMove = true;
            }

        }
        if (confront.gameObject.tag == "ForcePoint2")
        {
            isWillAtack = rnd.Next(1, 3);
            if (isWillAtack == 1)
            {
                isForceMove = true;
                isForce = false;
                NumberOfForcePoint = rnd.Next(1, 5);
                TankPlacePoint = 2;
                if (NumberOfForcePoint == TankPlacePoint)
                {
                    NumberOfForcePoint = rnd.Next(1, 5);
                    if (NumberOfForcePoint == TankPlacePoint)
                    {
                        NumberOfForcePoint = rnd.Next(1, 5);
                        if (NumberOfForcePoint == TankPlacePoint)
                        {
                            NumberOfForcePoint = rnd.Next(1, 5);

                        }
                    }
                }
            }
            else
            {
                isForce = true;
                isForceMove = false;
                Invoke("JumpForce", 0.5f);
            }

        }
        if (confront.gameObject.tag == "ForcePoint3")
        {
            isWillAtack = rnd.Next(1, 3);
            if (isWillAtack == 1)
            {
                isForceMove = true;
                isForce = false;
                NumberOfForcePoint = rnd.Next(1, 5);
                TankPlacePoint = 3;
                if (NumberOfForcePoint == TankPlacePoint)
                {
                    NumberOfForcePoint = rnd.Next(1, 5);
                    if (NumberOfForcePoint == TankPlacePoint)
                    {
                        NumberOfForcePoint = rnd.Next(1, 5);
                        if (NumberOfForcePoint == TankPlacePoint)
                        {
                            NumberOfForcePoint = rnd.Next(1, 5);

                        }
                    }
                }
            }
            else
            {
                isForce = true;
                isForceMove = false;
                Invoke("JumpForce", 0.5f);
            }

        }
        if (confront.gameObject.tag == "ForcePoint4")
        {
            isWillAtack = rnd.Next(1, 3);
            if (isWillAtack == 1)
            {
                isForceMove = true;
                isForce = false;
                NumberOfForcePoint = rnd.Next(1, 5);
                TankPlacePoint = 4;
                if (NumberOfForcePoint == TankPlacePoint)
                {
                    NumberOfForcePoint = rnd.Next(1, 5);
                    if (NumberOfForcePoint == TankPlacePoint)
                    {
                        NumberOfForcePoint = rnd.Next(1, 5);
                        if (NumberOfForcePoint == TankPlacePoint)
                        {
                            NumberOfForcePoint = rnd.Next(1, 5);

                        }
                    }
                }
            }
            else
            {
                isForce = true;
                isForceMove = false;
                Invoke("JumpForce", 0.5f);
            }

        }
    }
}