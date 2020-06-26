using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckTurelMove : MonoBehaviour
{

    public Transform PointOfTransport;
    public GameObject PlyayerCar;
    public GameObject AllCar;

    public bool CameFrom = true;
    public bool isStart = false;
    public bool isWas1 = true;
    public bool isWas = true;
    public bool isDestroy = false;
    public bool isChangeAtack = false;

    public float timeToCame = 3f;
    public static float timeToChangeAtack = 3f;
    public float DestroyTime = 3f;
    public float HeightToStop = 2f;
    public Animator HpAnim;

    private float PosCarEnemyX;
    private float PosCarEnemyY;
    public TurelScript turelScript;

    private void OnTriggerEnter2D(Collider2D confront)
    {
        if (confront.gameObject.tag == "DestroyerMap")
        {
            Destroy(AllCar);
        }
    }

    void Start()
    {
        Invoke("isStartMove", timeToCame);

    }


    void Update()
    {

        if (isChangeAtack)
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
        }

        if (isStart)
        {
            if (CameFrom)
            {
                if (this.transform.position.y > HeightToStop)
                {
                    this.transform.Translate(Vector3.up * (Time.deltaTime * 2f));
                }
                else if(CameFrom != true && isWas)
                {
                    turelScript.StartBulletShooting();
                    isWas = false;

                }
            }
            else if(CameFrom != true)
            {
                if (this.transform.position.y > HeightToStop)
                { 
                    this.transform.Translate(Vector3.down * (Time.deltaTime * 2f));

                }
                else if(CameFrom != true && isWas)
                {
                    turelScript.StartBulletShooting();
                    isWas = false;
                }
            }     
        }


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

    private void isStartMove()
    {
        isStart = true;
        HpAnim.SetBool("isStop", true);
        HpAnim.SetFloat("speedA", 1f / DestroyTime);
        Invoke("ChangeAtack", timeToChangeAtack);
        Invoke("timeIsDestroy", DestroyTime);
    }

    private void ChangeAtack()
    {
        turelScript.StopShoot();
        isChangeAtack = true;
    }

    private void timeIsDestroy()
    {
        Destroy(AllCar);
    }
}