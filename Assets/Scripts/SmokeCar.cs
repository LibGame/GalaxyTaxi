using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeCar : MonoBehaviour
{

    public float timeToStart = 1f;
    public GameObject SmokePrefab;
    public Transform SmokeOfDisgarge;
    public bool HardTrajectoryMove = false;

    private bool isStart = false;

    public float MoveSpeed = 0.5f;

    public float frequency = 3.0f; // Скорость виляния по синусоиде
    public float magnitude = 0.5f; // Размер синусоиды (радиус, по сути..можно заменить на "R")

    private Vector3 axis;
    private Vector3 pos;

    void Start()
    {
        Invoke("ToStart", timeToStart);
        pos = transform.position;
        axis = transform.right;
    }

    // Update is called once per frame
    void Update()
    {

        if (isStart)
        {
            if(this.transform.position.y+ this.transform.position.y >= 20)
            {
                Destroy(gameObject);
            }
            {
                if(HardTrajectoryMove != true)
                { 
                    this.transform.Translate(Vector3.up * (Time.deltaTime * GameProperties.HardSpeed));
                }else if (HardTrajectoryMove)
                {
                    pos += transform.up * Time.deltaTime * GameProperties.MoveSpeed;
                    transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D Confront)
    {


        if (Confront.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage == true)
            {
                Destroy(gameObject);
            }
            else if (CarController.isRage != true)
            {
                CarController.GetDamage(10);

                Destroy(gameObject);

            }
        }
        if (Confront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }

    }

    void ToStart()
    {
        StartCoroutine(SmokeSpawn());
        isStart = true;
    }


    IEnumerator SmokeSpawn()
    {
        while (true)
        {

            Instantiate(SmokePrefab, SmokeOfDisgarge.position, SmokeOfDisgarge.rotation);
            yield return new WaitForSeconds(0.3f);

        }
    }
}
