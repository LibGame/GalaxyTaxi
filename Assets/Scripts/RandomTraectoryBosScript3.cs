using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTraectoryBosScript3 : MonoBehaviour
{
    private int x1;
    private int y1;

    private int x1b;
    private int y1b;

    public int Traectory = 2;
    public float wasX;
    public float wasY;

    public bool isWas = true;
    public Transform startMarker;
    public Transform endMarker;
    public GameObject AllCoupter;

    public float TimeToDestroy = 1000f;

    public float speed = 1.0F;
    public bool isRandom = false;
    public bool isStop = false;


    void OnTriggerEnter2D(Collider2D confrontCopter)
    {
        if (confrontCopter.gameObject.tag == "r3")
        {
            isRandom = true;
        }

        if (confrontCopter.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage == true)
            {
                Destroy(gameObject);
            }
            else if (CarController.isRage != true)
            {
                CarController.GetDamage(5);

                Destroy(gameObject);

            }
        }
    }

    void Start()
    {
        Invoke("DestroyDron", WildBikerBos.timeToChangeAtack);
        x1 = Random.Range(-2, 2);
        y1 = Random.Range(-4, 4);
        x1b = x1;
        y1b = y1;

        endMarker.position = new Vector3(x1, y1, 0);
    }


    void Update()
    {
        if (isStop != true)
        {

            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Time.deltaTime * speed);

            wasX = transform.position.x;
            wasY = transform.position.y;

            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Time.deltaTime * speed);


            if (wasX == transform.position.x || wasY == transform.position.y)
            {
                isRandom = true;
            }

            if (isRandom)
            {
                x1 = Random.Range(-2, 2);
                y1 = Random.Range(-4, 4);
                if (x1b == x1 || y1b == y1)
                {
                    x1 = Random.Range(-2, 2);
                    y1 = Random.Range(-4, 4);
                }
                endMarker.position = new Vector3(x1, y1, 0);
                x1b = x1;
                y1b = y1;
                isRandom = false;
            }
        }
        else
        {
            transform.Translate(Vector3.up * (Time.deltaTime * 6f));

            if (this.transform.position.y + this.transform.position.y <= -20 || this.transform.position.y + this.transform.position.y >= 20
                    || this.transform.position.x + this.transform.position.x <= -20 || this.transform.position.x + this.transform.position.x >= 20)
            {

                Destroy(gameObject);

            }
        }

    }

    void FixedUpdate()
    {
        if (wasX == transform.position.x || wasY == transform.position.y)
        {
            isRandom = true;
        }
    }

    private void DestroyDron()
    {
        isStop = true;
    }
}
