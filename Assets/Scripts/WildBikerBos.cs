using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WildBikerBos : MonoBehaviour
{
    System.Random rnd = new System.Random();

    private int NumberOfAtack;
    private int WasNumberOfAtack;
    public static int randomBikePosition;
    public static float timeToChangeAtack = 2f;
    public GameObject BosBike;
    /// confront bike


    public GameObject[] FirstBike;
    public GameObject SecondBike;
    public GameObject ThirdBike;

    public Transform PositionOfRandomCarSpawn;
    public bool isCanSpawn = true;
    public float spawnBikeSpeed = 3f;
    /// End 


    /// For wooble traectory

    public GameObject WoobleBike1;
    public GameObject WoobleBike2;
    public float spawnBikeWoobleSpeed = 3f;
    public int randomWoobleBike = 1;
    public float speed = 0.5f;
    /// EndFormBikes


    /// For Cyrcle traectory bike 

    public Transform PlayerCar;
    public Transform[] PositionPoint;
    public float angle = 0; // угол 
    public float radius = 0.5f; // радиус
    public bool isCircle = false; // условие движения по кругу
    private bool isCanReboot = true;
    public float speeds = 0.5f;
    public GameObject Points1;
    public GameObject Points2;
    public GameObject Points3;

    public GameObject BikeCyrcle1;
    public GameObject BikeCyrcle2;
    public GameObject BikeCyrcle3;

    public static bool isCanStartBikes = false;

    /// End for Cyrcle traectory

    /// For bikes that move by random traectory 

    public GameObject RandomBike1;
    public GameObject RandomBike2;
    public GameObject RandomBike3;

    private bool isCanRebootRandomTraectory = true;

    /// 


    /// Avalanche of bikes

    private int xAvalanche;
    private float yAvalanche;
    private int rndNewAtack;
    private int rndYPos;
    private int rndYPosDown;

    private float avalaneChangeTime;
    public float TimeDes;
    private int randomAvalancheBike;
    public Rigidbody2D[] AvalancheBikePhy;
    private bool isCanRebootAvalanche = true;
    ///

    void Start()
    {

        AtackOfBos();
        Invoke("EndLevel", TimeDes);
    }


    void Update()
    {

        if (isCircle)
        {
            angle += Time.deltaTime; // меняется плавно значение угла

            var x = Mathf.Cos(angle * speeds) * radius;
            var y = Mathf.Sin(angle * speeds) * radius;


            Points1.transform.position = new Vector2(x, y) + new Vector2(PlayerCar.position.x, PlayerCar.position.y);
            Points2.transform.position = new Vector2(x+ 1.5f, y-0.6f) + new Vector2(PlayerCar.position.x, PlayerCar.position.y);
            Points3.transform.position = new Vector2(x - 2f, y - 2f) + new Vector2(PlayerCar.position.x, PlayerCar.position.y);

        }



        if (randomBikePosition == 1)
        {
            PositionOfRandomCarSpawn.position = new Vector3(-7, 0, 0);
        }
        else if(randomBikePosition == 2)
        {
            PositionOfRandomCarSpawn.position = new Vector3(0, -8, 0);

        }

        if (randomBikePosition == 3)
        {
            PositionOfRandomCarSpawn.position = new Vector3(0, 8, 0);
        }
        else if (randomBikePosition == 4)
        {
            PositionOfRandomCarSpawn.position = new Vector3(7, 0, 0);
        }

    }


    private void AtackOfBos()
    {
        NumberOfAtack = rnd.Next(1, 6);
        if (WasNumberOfAtack == NumberOfAtack)
        {
            NumberOfAtack = rnd.Next(1, 6);
        }
        else
        {
            WasNumberOfAtack = NumberOfAtack;
        }


        if(NumberOfAtack == 1)
        {
            timeToChangeAtack += rnd.Next(3, 7);
            StartCoroutine(BikeSpawn());
        }


        if (NumberOfAtack == 2)
        {
            timeToChangeAtack += rnd.Next(3, 7);
            StartCoroutine(BikeWoobleSpawn());
        }


        if (NumberOfAtack == 3 && isCanReboot)
        {

            Points1.transform.position = new Vector3(PlayerCar.position.x, PlayerCar.position.y + 0.5f, 0);
            Points2.transform.position = new Vector3(PlayerCar.position.x, PlayerCar.position.y - 0.5f, 0);
            Points3.transform.position = new Vector3(PlayerCar.position.x - 0.5f, PlayerCar.position.y, 0);

            randomBikePosition = rnd.Next(1, 5);
            timeToChangeAtack += rnd.Next(3, 7);

            Instantiate(BikeCyrcle1, PositionOfRandomCarSpawn.position, Quaternion.identity);
            Instantiate(BikeCyrcle2, PositionOfRandomCarSpawn.position, Quaternion.identity);
            Instantiate(BikeCyrcle3, PositionOfRandomCarSpawn.position, Quaternion.identity);

            isCircle = true;
            isCanStartBikes = true;
            isCanReboot = false;

        }


        if (NumberOfAtack == 4 && isCanRebootRandomTraectory)
        {
            randomBikePosition = rnd.Next(1, 5);
            timeToChangeAtack += rnd.Next(3, 7);
            Instantiate(RandomBike1, PositionOfRandomCarSpawn.position, Quaternion.identity);
            Instantiate(RandomBike2, PositionOfRandomCarSpawn.position, Quaternion.identity);
            Instantiate(RandomBike3, PositionOfRandomCarSpawn.position, Quaternion.identity);

            isCanRebootRandomTraectory = false;
            Invoke("TimeChangeAtack", 10f);

        }

        if (NumberOfAtack == 5 && isCanRebootAvalanche)
        {
            timeToChangeAtack = 30f;
            rndNewAtack = rnd.Next(2, 2);

            rndYPos = rnd.Next(-3, 3);
            print(rndNewAtack);
            if (rndNewAtack == 2)
            {
                Invoke("FuckingHardTraectory", 4f);

            }
            StartCoroutine("BikeAvalencheSpawn");
            isCanRebootAvalanche = false;
        }
        Invoke("TimeChangeAtack", timeToChangeAtack);
    }

    private void TimeChangeAtack()
    {
        isCanStartBikes = true;
        isCanRebootRandomTraectory = true;
        isCanRebootAvalanche = true;
        isCanReboot = true;
        StopAllCoroutines();
        AtackOfBos();

    }

    IEnumerator BikeSpawn()
    {
        int num = 0;

        while (true)
        {
            num = rnd.Next(0, 1);
            
            Instantiate(FirstBike[num], PositionOfRandomCarSpawn.position, Quaternion.identity);
            randomBikePosition = rnd.Next(1, 5);
            yield return new WaitForSeconds(spawnBikeSpeed);

        }
    }

    IEnumerator BikeWoobleSpawn()
    {

        while (true)
        {


            if (randomWoobleBike % 2 == 0)
            {
                Instantiate(WoobleBike2, PositionOfRandomCarSpawn.position, Quaternion.identity);

            }
            else
            {
                Instantiate(WoobleBike1, PositionOfRandomCarSpawn.position, Quaternion.identity);

            }

            randomWoobleBike++;
            randomBikePosition = rnd.Next(2, 4);

            yield return new WaitForSeconds(spawnBikeSpeed);

        }
    }

    IEnumerator BikeAvalencheSpawn()
    {
        var xb = 0f;
        var yb = 0f;
        
        while (true)
        {

            xAvalanche = rnd.Next(-2, 3);
            yAvalanche = rnd.Next(6, 13);
            
            if(xAvalanche == xb || yAvalanche == yb)
            {
                xAvalanche = rnd.Next(-2, 3);
                yAvalanche = rnd.Next(7, 14);
            }

            xb = xAvalanche;
            yb = yAvalanche;

            randomAvalancheBike = rnd.Next(0, 6);
            var bikes = Instantiate(AvalancheBikePhy[randomAvalancheBike], new Vector3(xAvalanche, yAvalanche, 0), Quaternion.Euler(0, 0, 180));
            bikes.velocity = bikes.transform.up * 5f;

            yield return new WaitForSeconds(0.5f);

        }
    }

    IEnumerator newLeftBikeAvalenche()
    {
        var yAvalancheDown = 7f;
        var xAvalancheDown = 6f;

        while (true)
        {


            randomAvalancheBike = rnd.Next(1, 3);
            var bikeLeft = Instantiate(AvalancheBikePhy[randomAvalancheBike], new Vector3(xAvalancheDown, yAvalancheDown, 0), Quaternion.Euler(0, 0, 90));
            bikeLeft.velocity = bikeLeft.transform.up * 5f;

            if (yAvalancheDown != rndYPos)
            {
                yAvalancheDown -= 0.5f;
            }

            yield return new WaitForSeconds(0.5f);

        }
    }


    IEnumerator newRightBikeAvalenche()
    {
        var yAvalancheUp = -7f;
        var xAvalancheUp = -6f;
        Invoke("StartUpDownBikeAvalanche", 2f);

        while (true)
        {

            randomAvalancheBike = rnd.Next(1, 3);
            var bikeRight = Instantiate(AvalancheBikePhy[randomAvalancheBike], new Vector3(xAvalancheUp, yAvalancheUp, 0), Quaternion.Euler(0, 0, -90));
            bikeRight.velocity = bikeRight.transform.up * 5f;

            if (yAvalancheUp != rndYPos-3f)
            {
                yAvalancheUp += 0.5f;
            }

            yield return new WaitForSeconds(0.5f);

        }
    }

    IEnumerator newUpBikeAvalenche()
    {
        var yAvalancheUp = 7f;
        var xAvalancheUp = -3f;
        bool increase = true;

        while (true)
        {

            randomAvalancheBike = rnd.Next(1, 3);
            var bikeRight = Instantiate(AvalancheBikePhy[randomAvalancheBike], new Vector3(xAvalancheUp, yAvalancheUp, 0), Quaternion.Euler(0, 0, 180));
            bikeRight.velocity = bikeRight.transform.up * 5f;


            if (increase)
            {
                if (xAvalancheUp < 3)
                    xAvalancheUp += 0.5f;
                else
                    increase = false;
            }
            else
            {
                if (xAvalancheUp > -3)
                    xAvalancheUp -= 0.5f;
                else
                    increase = true;
            }

            yield return new WaitForSeconds(1f);

        }
    }

    private void FuckingHardTraectory()
    {
        StopCoroutine("BikeAvalencheSpawn");
        StartCoroutine("newRightBikeAvalenche");
        StartCoroutine("newLeftBikeAvalenche");
        float timeS;
        timeS = rnd.Next(10, 15);
        Invoke("stopFuckingHardTraectory", timeS);
    }

    private void stopFuckingHardTraectory()
    {
        StartCoroutine("BikeAvalencheSpawn");
        StopCoroutine("newRightBikeAvalenche");
        StopCoroutine("newLeftBikeAvalenche");

    }

    private void StartUpDownBikeAvalanche()
    {
        StartCoroutine("newUpBikeAvalenche");
    }

    private void EndLevel()
    {
        Instantiate(BosBike, new Vector3(0, 10, 0), Quaternion.identity);
        StopAllCoroutines();
    }

}
