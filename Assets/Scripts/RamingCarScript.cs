using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamingCarScript : MonoBehaviour
{

    Rigidbody2D rigidbodyCar;
    public Transform Player;
    public Transform Turell;
    public GameObject AllCar;
    public bool isForce = false;
    public float thrust = 1f;
    public bool isCanMove = false;
    public bool isCanStart= false;
    public bool isCanDestroy = false;
    public float timeToDestroy;
    public float timeToStart;
    public Animator HpAnim;
    public float YHeight;

    void Start()
    {
        rigidbodyCar = GetComponent<Rigidbody2D>();
        Invoke("isStart", timeToStart);
    }

    private void OnTriggerEnter2D(Collider2D Confront)
    {
        if (isCanMove)
        {

            if (Confront.gameObject.tag == "1point")
            {
                isForce = false;
                rigidbodyCar.constraints = RigidbodyConstraints2D.FreezePosition;

                Invoke("StartForce", 2f);

            }
            if (Confront.gameObject.tag == "2point")
            {
                isForce = false;
                rigidbodyCar.constraints = RigidbodyConstraints2D.FreezePosition;
                Invoke("StartForce", 2f);

            }
            if (Confront.gameObject.tag == "3point")
            {
                isForce = false;
                Invoke("StartForce", 2f);
                rigidbodyCar.constraints = RigidbodyConstraints2D.FreezePosition;

            }
            if (Confront.gameObject.tag == "4point")
            {
                isForce = false;
                Invoke("StartForce", 2f);
                rigidbodyCar.constraints = RigidbodyConstraints2D.FreezePosition;
            }

        }


        if (Confront.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage != true)
            {
                CarController.GetDamage(10);

            }
        }


        if (Confront.gameObject.tag == "DestroyerMap")
        {
            Destroy(AllCar);
        }

    }

    void Update()
    {
        if (isCanStart)
        {
            if (transform.position.y < YHeight)
            {
                isCanMove = true;
                Invoke("StartForce", 2f);
                HpAnim.SetBool("isStop", true);
                HpAnim.SetFloat("speedA", 1.2f / timeToDestroy);
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
                Destroy(AllCar);
            }
            else
            {
                transform.Translate(Vector3.down * (Time.deltaTime * 6f));
            }
        }

        if (isCanMove)
        {
            if (isForce)
            {
                rigidbodyCar.constraints = RigidbodyConstraints2D.None;
                rigidbodyCar.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            }
            else
            {
                var turn = Quaternion.Lerp(Turell.rotation, Quaternion.LookRotation(Vector3.forward, Player.position - Turell.position), Time.deltaTime * GameProperties.RotationTureSpeed);
                rigidbodyCar.MoveRotation(turn.eulerAngles.z);
            }

            // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
            Vector2 leftBot = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 rightTop = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 Top = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 Bottom = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
            float x_left = leftBot.x + 0.3f;
            float x_right = rightTop.x - 0.3f;
            float y_Top = Top.y + 0.3f;
            float y_Bottom = Bottom.y - 0.3f;

            // ограничиваем объект в плоскости XZ
            Vector2 clampedPos = transform.position;

            clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
            clampedPos.y = Mathf.Clamp(clampedPos.y, y_Top, y_Bottom);
            transform.position = clampedPos;
        }
    }

    void StartForce()
    {
        isForce = true;
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
