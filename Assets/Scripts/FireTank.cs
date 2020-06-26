using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTank : MonoBehaviour
{

    private float PosCarEnemyX;
    private float PosCarEnemyY;
    public GameObject PlyayerCar;
    public bool isStartMove = false;
    private bool isCanStart = false;
    private bool isCanDestroy = false;
    public float YHeight;
    public float radius = 0.5f; // радиус
    public float speed = 0.5f;
    public float TimeToDestroy; 
    public float timeToStart;
    public bool isCircle = false; // условие движения по кругу
    public static bool isCanShoot = false;
    public Transform PointOfTransport;

    public Animator HpAnim;

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
                isStartMove = true;
                HpAnim.SetBool("isStop", true);
                HpAnim.SetFloat("speedA", 1.2f / TimeToDestroy);
                isCanShoot = true;
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

        if (isStartMove)
        {
            PosCarEnemyX = PointOfTransport.position.x;
            PosCarEnemyY = PointOfTransport.position.y;

            if ((PosCarEnemyX - PlyayerCar.transform.position.y + 0.2f) >= 4f)
            {
                PointOfTransport.Translate(Vector3.down * (Time.deltaTime * GameProperties.SpeedEnemyCar));
            }
            else if ((PosCarEnemyY - PlyayerCar.transform.position.y + 0.2f) <= 3f)
            {
                PointOfTransport.Translate(Vector3.up * (Time.deltaTime * GameProperties.SpeedEnemyCar));
            }

            if (PlyayerCar.transform.position.x >= PosCarEnemyX + 0.2f)
            {
                PointOfTransport.Translate(Vector3.right * (Time.deltaTime * GameProperties.SpeedEnemyCar));
            }
            else if (PlyayerCar.transform.position.x <= PosCarEnemyX - 0.3f)
            {
                PointOfTransport.Translate(Vector3.left * (Time.deltaTime * GameProperties.SpeedEnemyCar));
            }

            transform.position = Vector3.Lerp(this.transform.position, PointOfTransport.position, Time.deltaTime * 1f);



            // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
            Vector2 leftBot = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 rightTop = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 Top = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 Bottom = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
            float x_left = leftBot.x + 0.3f;
            float x_right = rightTop.x - 0.3f;
            float y_Top = Top.y + 0.5f;
            float y_Bottom = Bottom.y - 0.5f;



            // ограничиваем объект в плоскости XZ
            Vector2 clampedPos = PointOfTransport.position;

            clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
            clampedPos.y = Mathf.Clamp(clampedPos.y, y_Top, y_Bottom);
            PointOfTransport.position = clampedPos;
        }
    }

    void isStart()
    {
        isCanStart = true;
        Invoke("isDestroy", TimeToDestroy);
    }

    void isDestroy()
    {
        isCanShoot = false;
        isCanStart = false;
        isStartMove = false;
        isCanDestroy = true;
    }
}

