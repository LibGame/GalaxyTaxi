using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarFovard : MonoBehaviour
{

    public GameObject PlyayerCar;
    public GameObject BarrelPrefabs;
    public Transform pointOfdischarge;


    public float PosCarEnemyX;
    public float PosCarEnemyY;
    public float TimeDelete = 10f;
    private GameObject barrelClone;

    private bool IfIsCarDead = false;

    void Start()
    {
        if (IfIsCarDead == false)
        {
            StartCoroutine(BarrelSpawn());
        }
    }


    // Update is called once per frame
    void Update()
    {
        Invoke("DeleteEnemyCar", TimeDelete);
        if (IfIsCarDead == false)
        {

            PosCarEnemyX = this.transform.position.x;
            PosCarEnemyY = this.transform.position.y;

            if ((PosCarEnemyY - PlyayerCar.transform.position.y) >= 4f)
            {
                this.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.SpeedEnemyCar));
            }
            else if ((PosCarEnemyY - PlyayerCar.transform.position.y) <= 3f)
            {
                this.transform.Translate(Vector3.up * (Time.deltaTime * GameProperties.SpeedEnemyCar));
            }

            if (PlyayerCar.transform.position.x >= PosCarEnemyX + 0.2f)
            {
                this.transform.Translate(Vector3.right * (Time.deltaTime * GameProperties.SpeedEnemyCar));
            }
            else if (PlyayerCar.transform.position.x <= PosCarEnemyX - 0.3f)
            {
                this.transform.Translate(Vector3.left * (Time.deltaTime * GameProperties.SpeedEnemyCar));
            }

        }

    }


    IEnumerator BarrelSpawn()
    {
        while (true)
        {
            Instantiate(BarrelPrefabs, pointOfdischarge.position, pointOfdischarge.rotation);

            yield return new WaitForSeconds(1.5f);
        }
    }

    void DeleteEnemyCar()
    {
        IfIsCarDead = true;
        this.transform.Translate(Vector3.up * (Time.deltaTime* GameProperties.TimeDelteEnemyCar));

        if(this.transform.position.y > 6)
        {
            Destroy(gameObject);
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
                CarController.GetDamage(5);
                Destroy(gameObject);

            }


        }

        if (Confront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }

    }

}
