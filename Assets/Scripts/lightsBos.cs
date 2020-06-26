using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class lightsBos : MonoBehaviour
{

    private int NumberOfAtack;
    private int WasNumberOfAtack;
    public GameObject TrafickLightsXP;
    System.Random rnd = new System.Random();
    public static int TimeChange;
    public bool isDegresseXp = false;
    public float timeToStart;
    public GameObject AllBos;
    private bool isStart = false;
    public float TimeToDestroy = 6f;

    // All for points atack

    public GameObject[] point;
        public int LevelAtack = 1;
        public int amountOfPoint = 4;
        public static int typeOfAtack = 1;
        public float TimeToDestroyAllPoints = 6f;
        private Coroutine currentPoints;
        private int i = 0;
        public static bool isStartPointsAtack = false;
        public static bool isCanPaint = false;
        public static bool isPointDestroy1 = false;
        public static bool isPointDestroy2 = false;
        public static bool isPointDestroy3 = false;
        public static bool isPointDestroy4 = false;
        public static bool isPointDestroy5 = false;
        public static bool isPointDestroy6 = false;

        private float time = 0;
        private float timeToSpawnAvaleche = 0.5f;
        private float timeRe = 8f;

        public int amountAtack = 10;
        public int amountNowAtack = 0;

        public static bool isCanDestoryPoint = false;
        public static bool isWrongCombination = false;
        private bool isStopedAtack = false;

    // end all for points atack

    // Atack avalenche point

    public GameObject[] rightPoints;
    public GameObject[] wrongPoints;

    public static bool isWrongPoint = false;
    public static bool isRightPoint = false;


    // end avalenche atack

    // elements for CollectionAtack

    public Rigidbody2D[] CarDownsRigidBody;
    public static bool isCanStart = false;
    public static bool isCanDestroy = false;
    public GameObject IncasatorCar;
    // end elements for ColletionAtack


    void Start()
    {
        Invoke("StartBos", timeToStart);
    }

    void Update() {


        if (isStart)
        {
            if(AllBos.transform.position.y > 2.719473)
            {
                AllBos.transform.Translate(Vector3.down * (Time.deltaTime * 1f));
            }
            else 
            {
                isStart = false;
                ChangeAtack();
            }
        }

        if (isDegresseXp)
        {
            if (TrafickLightsXP.transform.position.x < -5.4)
            {
                StopAllCoroutines();
                isCanDestoryPoint = true;
                isCanStart = false;
                isCanDestroy = false;
                isPointDestroy1 = false;
                isPointDestroy2 = false;
                isPointDestroy3 = false;
                isPointDestroy4 = false;
                isPointDestroy5 = false;
                isPointDestroy6 = false;
                isStartPointsAtack = false;
                isCanPaint = false;

                if (AllBos.transform.position.y < 7f)
                {
                    AllBos.transform.Translate(Vector3.up * (Time.deltaTime * 1f));
                }
                else
                {
                    Destroy(AllBos);
                }
            }
            else
            {
                TrafickLightsXP.transform.Translate(Vector3.left * (Time.fixedDeltaTime * 0.1f));
            }
        }

        if (isWrongPoint)
        {
            if (TrafickLightsXP.transform.position.x < -0.099999)
            {
                TrafickLightsXP.transform.position = new Vector3(TrafickLightsXP.transform.position.x + 0.1f, TrafickLightsXP.transform.position.y, 0);
                isWrongPoint = false;
            }
        }


        if (isRightPoint)
        {
            TrafickLightsXP.transform.position = new Vector3(TrafickLightsXP.transform.position.x - 0.1f, TrafickLightsXP.transform.position.y, 0);
            isRightPoint = false;
        }

        if (isStartPointsAtack)
        {
            time += Time.deltaTime;
            if (time >= timeRe)
            {
                LevelAtack++;
                DestoryAllPoints();

                time = 0;
                CarController.GetDamage(10);

            }
        }

        if (isPointDestroy6 && amountOfPoint == 6)
        {
            time = 0;
            DestoryAllPoints();
            LevelAtack++;

            isPointDestroy1 = false;
            isPointDestroy2 = false;
            isPointDestroy3 = false;
            isPointDestroy4 = false;
            isPointDestroy5 = false;
            isPointDestroy6 = false;

            DestoryAllPoints();

        }
        if (isWrongCombination)
        {
            TimeToDestroyAllPoints = 8f;
            time = 0;
            DestoryAllPoints();

            isWrongCombination = false;
            isPointDestroy1 = false;
            isPointDestroy2 = false;
            isPointDestroy3 = false;
            isPointDestroy4 = false;
            isPointDestroy5 = false;
            isPointDestroy6 = false;
            CarController.GetDamage(20);


        }


        if (isPointDestroy5 && amountOfPoint == 5)
        {
            DestoryAllPoints();
            time = 0;
            LevelAtack++;

            isPointDestroy1 = false;
            isPointDestroy2 = false;
            isPointDestroy3 = false;
            isPointDestroy4 = false;
            isPointDestroy5 = false;
            isPointDestroy6 = false;
        }
        
        if (isPointDestroy4 && amountOfPoint == 4)
        {
            DestoryAllPoints();
            time = 0;
            LevelAtack++;
            isPointDestroy1 = false;
            isPointDestroy2 = false;
            isPointDestroy3 = false;
            isPointDestroy4 = false;
            isPointDestroy5 = false;
            isPointDestroy6 = false;
        }
        if (isPointDestroy3 && amountOfPoint == 3)
        {
            DestoryAllPoints();
            time = 0;
            LevelAtack++;
            isPointDestroy1 = false;
            isPointDestroy2 = false;
            isPointDestroy3 = false;
            isPointDestroy4 = false;
            isPointDestroy5 = false;
            isPointDestroy6 = false;
        }
    }

    void ChangeAtack()
    {
        StopAllCoroutines();
        isDegresseXp = false;
        isCanDestoryPoint = true;
        isCanStart = false;
        isCanDestroy = false ;
        isPointDestroy1 = false;
        isPointDestroy2 = false;
        isPointDestroy3 = false;
        isPointDestroy4 = false;
        isPointDestroy5 = false;
        isPointDestroy6 = false;
        isStartPointsAtack = false;
        isCanPaint = false;
        NumberOfAtack = rnd.Next(1, 4);
        if (WasNumberOfAtack == NumberOfAtack)
        {
            NumberOfAtack = rnd.Next(1, 4);
        }
        else
        {
            WasNumberOfAtack = NumberOfAtack;
        }

        if (NumberOfAtack == 1)
        {
            typeOfAtack = rnd.Next(1, 2);
            if (typeOfAtack == 1)
            {
                AtackTime();
                Invoke("SpawnPointsAtack", 1f);
                isStartPointsAtack = true;
                isDegresseXp = true;
                isCanPaint = true;
                print("1");
            }
            else if (typeOfAtack == 2)
            {
                AtackTime();
                isCanDestoryPoint = false;
                SpawnOnePointAtack();
                isDegresseXp = true;

                isCanPaint = true;
                print("2");

            }
        }

        if (NumberOfAtack == 2)
        {
            AtackTime();
            isDegresseXp = false;
            isCanPaint = false;
            StartPointsAvalencheAtack();
            print("3");

        }

        if (NumberOfAtack == 3)
        {
            Invoke("ChangeAtack", 29f);          
            Instantiate(IncasatorCar, new Vector3(0, -7, 0), Quaternion.identity);
            isCanPaint = false;
            isDegresseXp = true;
            print("4");

            CollectionAtack();

        }
    }

    void StartBos()
    {
        isStart = true;
        Invoke("isFinish", TimeToDestroy);
    }

    void CollectionAtack()
    {
        isCanStart = true;

        StartCoroutine(SpawnColectionAtack());
    }

    void AtackTime() // вызываем рандом атаки заного
    {
        TimeChange = rnd.Next(20, 30);
        Invoke("ChangeAtack", TimeChange);
    }
    
    void SpawnPointsAtack()
    {
        if (isStopedAtack != true)
        {
            isCanDestoryPoint = false;
            i = 0;
            StartCoroutine(SpawnPoints());
        }
    }

    void StartPointsAvalencheAtack()
    {
        StartCoroutine(SpawnAvalencheAtack());
        Invoke("newTimeToSpawnAvaleche", 30f);
    }

    void newTimeToSpawnAvaleche()
    {
        timeToSpawnAvaleche = 0.1f;
    }

    void SpawnOnePointAtack() 
    {
        int xPos;
        int yPos;

        xPos = rnd.Next(-2, 3);
        yPos = rnd.Next(-3, 4);

        Instantiate(point[0], new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    void DestoryAllPoints()
    {
        isCanDestoryPoint = true;
        time = 0;
        Invoke("SpawnPointsAtack", 1f);
    }



    IEnumerator SpawnColectionAtack()
    {
        int xPos;
        int yPos;
        int b;
        int isWhichAtack = 0;
        int isClearList = 0;
        List<int> XposList = new List<int>();
        List<int> YposList = new List<int>();

        while (true)
        {


            xPos = rnd.Next(-2, 3);
            yPos = rnd.Next(8, 16);

            for (int j = 0; j < XposList.Count; j++)
            {
                if (XposList[j] == xPos)
                {
                    xPos = rnd.Next(-2, 3);
                    if (XposList[j] == xPos)
                    {
                        xPos = rnd.Next(-2, 3);
                        if (XposList[j] == xPos)
                        {
                            xPos = rnd.Next(-2, 3);
                            if (XposList[j] == xPos)
                            {
                                xPos = rnd.Next(-2, 3);
                            }
                        }
                    }

                }

            }

            for (int g = 0; g < YposList.Count; g++)
            {
                if (YposList[g] == yPos)
                {
                    yPos = rnd.Next(8, 16);
                    if (YposList[g] == yPos)
                    {
                        yPos = rnd.Next(8, 16);
                        if (YposList[g] == yPos)
                        {
                            yPos = rnd.Next(8, 16);
                            if (YposList[g] == yPos)
                            {
                                yPos = rnd.Next(8, 16);
                            }
                        }
                    }
                }

            }

            XposList.Add(xPos);
            YposList.Add(yPos);

            if (isClearList == 8)
            {
                XposList.Clear();
                YposList.Clear();
            }

            isClearList++;

            isWhichAtack = rnd.Next(1, 4);
 
            b = rnd.Next(0, 11);

            Instantiate(CarDownsRigidBody[0], new Vector3(xPos, yPos, 0), Quaternion.identity);


            yield return new WaitForSeconds(0.1f);
        }

    }


    IEnumerator SpawnAvalencheAtack() // атака где на тебя падают много поинтов и тебе нужно  их собирать , это карутина которая отвеает за появления этих потинтов
    {
        int xPos;
        int yPos;
        int a;
        int b;
        int isWhichAtack = 0;
        int isClearList = 0;
        List<int> XposList = new List<int>();
        List<int> YposList = new List<int>();

        while (true)
        {


            xPos = rnd.Next(-2, 3);
            yPos = rnd.Next(8,16);

            for (int j = 0; j < XposList.Count; j++)
            {
                if (XposList[j] == xPos)
                {
                    xPos = rnd.Next(-2, 3);
                    if (XposList[j] == xPos)
                    {
                        xPos = rnd.Next(-2, 3);
                        if (XposList[j] == xPos)
                        {
                            xPos = rnd.Next(-2, 3);
                            if (XposList[j] == xPos)
                            {
                                xPos = rnd.Next(-2, 3);
                            }
                        }
                    }

                }

            }

            for (int g = 0; g < YposList.Count; g++)
            {
                if (YposList[g] == yPos)
                {
                    yPos = rnd.Next(8, 16);
                    if (YposList[g] == yPos)
                    {
                        yPos = rnd.Next(8, 16);
                        if (YposList[g] == yPos)
                        {
                            yPos = rnd.Next(8, 16);
                            if (YposList[g] == yPos)
                            {
                                yPos = rnd.Next(8, 16);
                            }
                        }
                    }
                }

            }

            XposList.Add(xPos);
            YposList.Add(yPos);

            if (isClearList == 8)
            {
                XposList.Clear();
                YposList.Clear();
            }

            isClearList++;

            isWhichAtack = rnd.Next(1, 4);
            if (isWhichAtack == 1 || isWhichAtack == 2)
            {
                a = rnd.Next(0, 12);
                Instantiate(wrongPoints[a], new Vector3(xPos, yPos, 0), Quaternion.identity);
            }
            else
            {
                b = rnd.Next(0, 11);
                Instantiate(rightPoints[b], new Vector3(xPos, yPos, 0), Quaternion.identity);
            }

            yield return new WaitForSeconds(timeToSpawnAvaleche);
        }

    }

    IEnumerator SpawnPoints()
    {
        int xPos;
        int yPos;
        List<int> XposList = new List<int>();
        List<int> YposList = new List<int>();



        while (true)
        {


            xPos = rnd.Next(-2, 3);
            yPos = rnd.Next(-3, 4);

            for (int j = 0; j < XposList.Count; j++)
            {
                if (XposList[j] == xPos)
                {
                    xPos = rnd.Next(-2, 3);
                    if (XposList[j] == xPos)
                    {
                        xPos = rnd.Next(-2, 3);
                        if (XposList[j] == xPos)
                        {
                            xPos = rnd.Next(-2, 3);
                            if (XposList[j] == xPos)
                            {
                                xPos = rnd.Next(-2, 3);
                            }
                        }
                    }

                }

            }

            for (int g = 0; g < YposList.Count; g++)
            {
                if (YposList[g] == yPos)
                {
                    yPos = rnd.Next(-2, 3);
                    if (YposList[g] == yPos)
                    {
                        yPos = rnd.Next(-2, 3);
                        if (YposList[g] == yPos)
                        {
                            yPos = rnd.Next(-2, 3);
                            if (YposList[g] == yPos)
                            {
                                yPos = rnd.Next(-2, 3);
                            }
                        }
                    }
                }

            }

            XposList.Add(xPos);
            YposList.Add(yPos);

            if (LevelAtack == 3)
            {
                amountOfPoint = 5;
                timeRe = 6;
            }
            else if (LevelAtack == 6)
            {
                amountOfPoint = 6;
                timeRe = 5;
                isStopedAtack = true;
            }
            else if (LevelAtack == 10)
            {

                isStopedAtack = true;
            }

            Instantiate(point[i], new Vector3(xPos, yPos, 0), Quaternion.identity);
            i++;

            if (i == amountOfPoint)
            {
                StopAllCoroutines();
                XposList.Clear();
                YposList.Clear();
            }


            yield return new WaitForSeconds(0.1f);

        }

    }
}
