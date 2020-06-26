using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterScript : MonoBehaviour
{

    public float angle = 0; // угол 
    public float radius = 1f; // радиус
    private bool isCircle = false; // условие движения по кругу
    public float speedHelio = 3f;
    // запоминать свое нахождение и делать его центром окружности
    public float DestroyTime = 7f;
    public float StartTime = 7f;
    public static bool isShoot = false;

    public float StartHeight = 2f;
    public TurelScript turelScript;
    public bool isStart = false;
    private bool isOnce = false;
    private bool Brake = false;
    public Animator HpAnim;
    private HpLineOfEnemy sm;
    public Vector2 cachedCenter;

    private void OnTriggerEnter2D(Collider2D confront)
    {
        if (confront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Invoke("StartHelio", StartTime);
        HpAnim.SetFloat("speedA", 1f/DestroyTime);
    }

    void Update()
    {

        if (isStart != false)
        {

            if (transform.position.y > StartHeight && isCircle != true)
            {

                transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.speedHelio));
                cachedCenter = transform.position;
            }
            else
            {
                isCircle = true;

            }

            if (isCircle)
            {

                if (isOnce != true)
                {
                    turelScript.StartRocketShooting();
                    isOnce = true;
                }

                angle += Time.deltaTime; // меняется плавно значение угла

                var x = Mathf.Cos(angle * GameProperties.speedHelio) * radius;
                var y = Mathf.Sin(angle * GameProperties.speedHelio) * radius;

                transform.position = new Vector2(x, y) + cachedCenter - new Vector2(radius, 0);
            }
        }

        if (Brake)
        {
            transform.Translate(Vector3.down * (Time.deltaTime * 5f));
            if (this.transform.position.y + this.transform.position.y >= 10)
            {
                Destroy(gameObject);

            }
        }
    }

    private void StartHelio()
    {
        isStart = true;
        Invoke("BreakLoop", DestroyTime);
        HpAnim.SetBool("isStop", true);

    }

    private void BreakLoop()
    {

        isCircle = false;
        isStart = false;
        turelScript.StopShoot();
        Brake = true;
    }
}
