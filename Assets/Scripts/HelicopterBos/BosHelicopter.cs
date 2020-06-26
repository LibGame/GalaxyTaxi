using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosHelicopter : MonoBehaviour 
{
    public float angle = 0; // угол 
    public float radius = 0.2f; // радиус
    public float speed = 2f;
    public Vector2 cachedCenter;
    public float TimeToDestroy;
    public float HeightToStart = 1f;
    public float speedColor = 3f;
    public static int state;
    public static int FirstState;

    Color colorStart = Color.white;
    Color colorEnd = Color.red;

    public Transform IconTurel;
    public Transform IconRocket;
    public Transform IconLazer;
    public Transform IconCopter;
    public Transform DronDischarge;

    public GameObject RedIcon;


    public Material MaterialBos;
    private GameObject iconAtack;
    public GameObject AllHelth;
    public BosRocketLauncher RocketLauncher1;
    public BosRocketLauncher RocketLauncher2;
    public BosLazerLauncher LazerLauncher1;
    public BosLazerLauncher LazerLauncher2;
    public BosTurel Turel;
    private BosCopter _bosCopterScript;

    public static int wasState = 0;
    private float _harderLimit;
    public static float SpeedTurel = 0.5f;
    public static float LazerTurel = 1f;
    public static float SpeedRocket = 3f;
    public static float SpeedBullet = 4f;
    public static float SpeedDron = 5f;


    public static int TurelAtack = 5;
    public static int RocketAtack = 30;
    public static int DronAtack = 40;
    public static int LazerAtack = 40;

    private float timeOfChangeInSeconds = 3f;
    public float TimeToStart;

    private bool _isStart = false;
    public bool isWas = false;
    private bool _isCanMove = false;
    public static bool isHard = false;
    public bool isFinish = false;
    public bool isCanChangeColor = false;
    public bool isWasChange = false;
    private Vector3 _deathToScale;

    private bool _isBonusTurel = false;
    private bool _isBonusCopter = false;
    private bool _isBonusRocket = false;
    private bool _isBonusLazer = false;


    private Rigidbody2D[] _drons = new Rigidbody2D[3];

    public GameObject DronPrefabRight;
    public GameObject DronPrefabLeft;

    public float timeToChange = 3f;

    private Coroutine copterCoroutine;
    public GameObject HelthLine;
    public GameObject WinTable;

    void Start()
    {
        _deathToScale = new Vector3 (0, HelthLine.transform.localScale.y, 0);
        _harderLimit = HelthLine.transform.localScale.x / 3;
        MaterialBos.color = Color.white;
        Invoke("StartBosAtack", TimeToStart);
    }

    void Update()
    {


        MoveHeliocopter();
        if (isFinish)
        {
            FinishTheBos();
        }



        if (_isStart)
        {
            if (this.transform.position.y <= HeightToStart)
            {
                cachedCenter = transform.position;
                NewState();
                _isCanMove = true;
                _isStart = false;
            }
            else
            {
                transform.Translate(Vector3.down * (Time.deltaTime * 3f));

            }

        }

    }

    private void FinishTheBos()
    {

        if (this.transform.position.y
                        + this.transform.position.y >= 20)
        {
            PlayerPrefs.SetInt("CityRoadCompleate",1);
            Instantiate(WinTable, WinTable.transform.position, WinTable.transform.rotation);
            PlayerPrefs.Save();


            if ((PlayerPrefs.HasKey("CityRoadCompleate")))
            {
                MaterialBos.color = Color.white;
                Destroy(AllHelth);
            }
            else
            {
                Invoke("EndLvl", 2f);
            }

        }
        else
        {
            transform.Translate(Vector3.up * (Time.deltaTime * 3f));
        }
    }

    private void EndLvl()
    {
        PlayerPrefs.SetInt("CityRoadCompleate", 1);
        PlayerPrefs.Save();
        Destroy(gameObject);

    }

    private void MoveHeliocopter()
    {

        if (_isCanMove)
        {
           
            if (HelthLine.transform.localScale.x <= _harderLimit)
            {
                SpeedTurel = 0.3f;
                LazerTurel = 0.6f;
                SpeedRocket = 4f;
                SpeedBullet = 7f;
                SpeedDron = 7f;
                TurelAtack = 10;
                RocketAtack = 50;
                DronAtack = 50;


                StartCoroutine(SmoothColor(MaterialBos, Color.white, Color.red, timeOfChangeInSeconds));
                isHard = true;
            }

            angle += Time.deltaTime; // меняется плавно значение угла

            var x = Mathf.Cos(angle * speed) * radius;
            var y = Mathf.Sin(angle * speed) * radius;
            transform.position = new Vector2(x, y) +
                            cachedCenter - new Vector2(radius, 0);

            if (HelthLine.transform.localScale.x == 0)
            {
                isFinish = true;
                _isCanMove = false;
            }
            else
            {
                HelthLine.transform.localScale = Vector3.MoveTowards(HelthLine.transform.localScale, _deathToScale, (Time.fixedDeltaTime / TimeToDestroy) * 1.2f);

            }

        }

    }


    private void StartBosAtack()
    {
        _isStart = true;

    }


    void NewState()
    {

        if (isHard)
        {
            HelthLine.GetComponent<SpriteRenderer>().color = Color.blue;
            timeToChange = Random.Range(6, 10);
        }

        //FirstState = Random.Range(1, 5);
        if(FirstState == 4)
        {
            FirstState = 0;
        }

        FirstState++;

        if (FirstState == wasState)
        {
            FirstState = Random.Range(1, 5);
        }
        else if (FirstState != wasState)
        {
            wasState = FirstState;
        }

        if (FirstState == 1)
        {
            LazerAtackM();
            BonusAtack(1);

        }
        else if (FirstState == 2)
        {
            RocketAtackM();
            BonusAtack(2);

        }
        else if (FirstState == 3)
        {
            TurelAtackM();
            BonusAtack(3);

        }
        else if (FirstState == 4)
        {
            CopterAtackM();
            BonusAtack(4);

        }
        Invoke("stopAtack", timeToChange);


    }

    private void LazerAtackM()
    {
        var Lazer = Instantiate(RedIcon, IconLazer.position, IconLazer.rotation);
        Lazer.transform.SetParent(AllHelth.transform);
        LazerLauncher1.StartBulletShooting();
        LazerLauncher2.StartBulletShooting();

        Invoke("BeforeAnimation", 1.5f);
    }

    private void TurelAtackM()
    {
        Turel.StartBulletShooting();
        if(FirstState != 4)
        {
            RocketLauncher1.StartArkBulletShooting();
            RocketLauncher2.StartArkBulletShooting();
        }

        var Lazer = Instantiate(RedIcon, IconTurel.position, IconTurel.rotation);
        Lazer.transform.SetParent(AllHelth.transform);
        Invoke("BeforeAnimation", 1.5f);
    }

    private void CopterAtackM()
    {
        copterCoroutine = StartCoroutine(ShootCopter());

        Invoke("BeforeAnimation", 1.5f);
    }

    private void RocketAtackM()
    {
        RocketLauncher1.StartBulletShooting();
        RocketLauncher2.StartBulletShooting();

        var Lazer = Instantiate(RedIcon, IconRocket.position, IconRocket.rotation);
        Lazer.transform.SetParent(AllHelth.transform);
        Invoke("BeforeAnimation", 1.5f);
    }

    void BeforeAnimation()
    {
        iconAtack = GameObject.FindWithTag("IconAtack");
        Destroy(iconAtack);
    }

    private void BonusAtack(int state)
    {
        int random = 0;

        if (FirstState == 1)
        {
            random = Random.Range(1, 3);

            switch (random)
            {
                case 1:
                    TurelAtackM();
                    _isBonusTurel = true;
                    break;
                case 2:
                    RocketAtackM();
                    _isBonusRocket = true;
                    break;

            }
        }
        else if (FirstState == 2)
        {
            random = Random.Range(1, 4);

            switch (random)
            {
                case 1:
                    TurelAtackM();
                    _isBonusTurel = true;

                    break;
                case 2:
                    LazerAtackM();
                    _isBonusLazer = true;

                    break;
                case 3:
                    CopterAtackM();
                    _isBonusCopter = true;

                    break;
            }
        }
        else if (FirstState == 3)
        {
            random = Random.Range(1, 3);

            switch (random)
            {
                case 1:
                    LazerAtackM();
                    _isBonusLazer = true;
                    break;
                case 2:
                    CopterAtackM();
                    RocketLauncher1.StopArkBulletSooting();
                    RocketLauncher2.StopArkBulletSooting();
                    _isBonusCopter = true;
                    break;
            }
        }
        else if (FirstState == 4)
        {
            random = Random.Range(1, 3);

            switch (random)
            {
                case 1:
                    RocketAtackM();
                    _isBonusRocket = true;

                    break;
                case 2:
                    Turel.StartBulletShooting();
                    _isBonusTurel = true;
                    break;
            }
        }

    }

    private void stopAtack()
    {
        if(FirstState == 1 || _isBonusLazer)
        {
            LazerLauncher1.StopBulletSooting();
            LazerLauncher2.StopBulletSooting();

            _isBonusLazer = false;
        }
        if(FirstState == 2 || _isBonusRocket)
        {
            RocketLauncher1.StopBulletSooting();
            RocketLauncher2.StopBulletSooting();
            _isBonusRocket = false;
        }
        if(FirstState == 3 || _isBonusTurel)
        {
            Turel.StopBulletSooting();
            RocketLauncher1.StopArkBulletSooting();
            RocketLauncher2.StopArkBulletSooting();     
            
            _isBonusTurel = false;
        }
        if(FirstState == 4 || _isBonusCopter)
        {
            StopCoroutine(copterCoroutine);
            _isBonusCopter = false;
        }

        Invoke("NewState", 1f);
    }

    IEnumerator ShootCopter()
    {
        while (true)
        {
            Instantiate(DronPrefabRight, DronDischarge.position, Quaternion.identity);
            Instantiate(DronPrefabLeft, DronDischarge.position, Quaternion.identity);
            
            yield return new WaitForSeconds(1f);

        }
    }

    IEnumerator SmoothColor(Material rend, Color startColor, Color endColor, float time)
    {
        float currTime = 0f;
        rend.color = startColor;
        do
        {
            rend.color = Color.Lerp(rend.color, endColor, currTime / time);
            currTime += Time.deltaTime;
            yield return null;
        } while (currTime <= time && isCanChangeColor != true);
    }

}