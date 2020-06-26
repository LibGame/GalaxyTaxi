using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Profiling;
using UnityEngine.Events;

public class NeCroBos : MonoBehaviour
{      

public Rigidbody2D Familiars; // фамилиары которые защищяют босса
    private enum NameOfAtacks // список всех атак
    {
        DefendsAtack = 0,
        CircleAtack = 1,
        DeadHandAtack = 2,
        WallWaveAtack = 3,
        FinalAtack = 4,
        Check = 5,

    };
    private NameOfAtacks _nameOfAtacks; // экземпляр перечесления атак
    private int _numberOfAtack = 0; // Какя атака по счету
    public float angle = 0; // угол 
    private float radius = 2.5f; // радиус
    public static float timeToChangeAtack = 30f;
    public static int _countOfHandAtack; // Какя атака по счету
    private int _numberOfCharge = 0;
    private int _amountOfCharge = 0;
    private Rigidbody2D[] hands = new Rigidbody2D[10];

    private GameObject familiarCircle;

    private GameObject _coliderCircle;
    public GameObject TeleportChargePrefab;
    public GameObject PlaguetChargePrefab;
    public GameObject FireChargePrefab;
    public GameObject ContractChargePrefab;
    public GameObject CloneChargePrefab;

    private Vector2 cachedCenter;
    public GameObject FamiliarCirclePref;
    public GameObject WallOfPlague;

    public GameObject ColiderCirclePref; // колайдер ограничивающий движение
    public Rigidbody2D FamiliarCirclingPref;
    public GameObject DeadHandPref;
    public Rigidbody2D DeadHandPhysicsPref;
    public GameObject BookPrefab;

    public Transform spawnPos;
    public Transform PlayerCar; // Машина игрока

    private bool _isDeadHandAtack = false; // начинаеться атака мертвыми руками
    private bool _isCircleFamiliar = false; // условие движения по кругу
    private bool _playerMoveCentre = false;
    private bool isLastAtack = false;
    private bool _isSpawned = true;

    public static bool _isAnimated = false;

    public static bool _isCanDestroy = false;

    public static bool isStopedAtack;

    private Coroutine _circlefamiliarCoroutine; // карутина которая спавнит круговых фамилиаров
    private Coroutine _circlePushCoroutine; // коротина которая толкает фамилиаров
    private Coroutine _StartPushingAtackCoroutine; // карутина создающяя рандомными атаками
    private Coroutine _RandmFamiliarCoroutine; // карутина атакующяя рандомными атаками
    private Coroutine _spawnWalsCoroutine; // карутина спавнящяя стены
    private Coroutine _metioriteAtackCoroutine; // карутина спавнящяя стены
    private Coroutine _finalAtackCoroutine; //финальная атака

    private List<Rigidbody2D> _cyrclingFamiliars = new List<Rigidbody2D>();
    public static List<float> _xPosPlayerCar = new List<float>();
    public static List<float> _yPosPlayerCar = new List<float>();
    private float angleBos = 0; // угол 
    private float radiusBos = 0.2f; // радиус
    private float speedBos = 2f;
    private Animator Anim;
    public UnityEvent onSpawnScythe;
    public NecroScytheCript scythe;
    NeCroCircling NeCroScript;
    public GameObject WinTable;

    public void Start()
    {
        Anim = GetComponent<Animator>();

        Invoke("StartSpawnAnimation", 3f);
    }

    private void StartSpawnAnimation()
    {
        Anim.Play("spawnNecroBos");

    }

    public void StartBosAtack()
    {
        cachedCenter = transform.position;
        _isSpawned = false;
        onSpawnScythe.Invoke();
        ChangeAtack();
        Anim.Play("NecromantIdle");
    }

    void Update()
    {


        if(_isAnimated != true && _isSpawned != true)
        {
            CirclingBosAround();
        }

        if (_playerMoveCentre)
        {
            PlayerCenterPosition();
        }
        else if (_isCircleFamiliar)
        {
            CircleAtackStart();

        }
        else if (_isDeadHandAtack)
        {
            angle += Time.deltaTime; // меняется плавно значение угла
            var x = Mathf.Cos(angle * 100f) * 6;
            var y = Mathf.Sin(angle * 100f) * 6;
            familiarCircle.transform.position = new Vector2(x, y) + new Vector2(0, 0);


        }
        else if (_nameOfAtacks == NameOfAtacks.FinalAtack)
        {
            // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
            Vector2 leftBot = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 rightTop = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 Top = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 Bottom = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
            float x_left = leftBot.x + 0.8f;
            float x_right = rightTop.x - 0.8f;
            float y_Top = Top.y + 0.8f;
            float y_Bottom = Bottom.y - 0.8f;



            // ограничиваем объект в плоскости XZ
            Vector2 clampedPos = transform.position;

            clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
            clampedPos.y = Mathf.Clamp(clampedPos.y, y_Top, y_Bottom);
            transform.position = clampedPos;


            if (_isCanDestroy)
            {
                BosCenterPosition();
            }
        }
    }

    private void CirclingBosAround()
    {

        angleBos += Time.deltaTime; // меняется плавно значение угла

        var x = Mathf.Cos(angleBos * speedBos) * radiusBos;
        var y = Mathf.Sin(angleBos * speedBos) * radiusBos;
        transform.position = new Vector2(x, y) +
                        cachedCenter - new Vector2(radiusBos, 0);
    }

    private void ChangeAtack()
    {
        isStopedAtack = false;

        _nameOfAtacks = (NameOfAtacks)Enum.GetValues(typeof(NameOfAtacks)).GetValue(_numberOfAtack);
        if (_nameOfAtacks == NameOfAtacks.DefendsAtack)
        {
            StartAnimationCast();
            Invoke("DefendsAtackStart",4f);
            Invoke("StopedAtack", timeToChangeAtack);
        }
        else if (_nameOfAtacks == NameOfAtacks.CircleAtack)
        {
            _playerMoveCentre = true;
            CarController.isCantMove = true;
            Invoke("StopedAtack", timeToChangeAtack);

        }
        else if (_nameOfAtacks == NameOfAtacks.DeadHandAtack)
        {
            familiarCircle = Instantiate(FamiliarCirclePref, new Vector3(0,0, 0), Quaternion.identity);
            StartCoroutine(DeadHandCentreAtackSpawn());
            _isDeadHandAtack = true;
            Invoke("StopedAtack", timeToChangeAtack);

        }
        else if (_nameOfAtacks == NameOfAtacks.WallWaveAtack)
        {
            StartWallsAtack();
            Invoke("StopedAtack", timeToChangeAtack);

        }else if(_nameOfAtacks == NameOfAtacks.FinalAtack)
        {
            isLastAtack = true;
            _isSpawned = true;
            _finalAtackCoroutine = StartCoroutine(ChargeAtackSpawn());
            Invoke("StopedAtack", timeToChangeAtack);
            
        }
        _numberOfAtack++;

    }

    private void StartWallsAtack()
    {
        _spawnWalsCoroutine = StartCoroutine(SpawnWalls());
    }

    private void StartAnimationCast()
    {
        var Book = Instantiate(BookPrefab, spawnPos.position, Quaternion.identity);
        Book.transform.SetParent(gameObject.transform);
        _isAnimated = true;
    }

    private void SpawnCharges()
    {
        if(_amountOfCharge <= 3)
        {
            _numberOfCharge = UnityEngine.Random.Range(1, 65);
        }

        _amountOfCharge++;

        if (_numberOfCharge <= 20)
        {
            Instantiate(PlaguetChargePrefab, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            _numberOfCharge = 100;
        }
        else if (_numberOfCharge <= 40)
        {
            Instantiate(FireChargePrefab, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            _numberOfCharge = 100;

        }
        else if (_numberOfCharge <= 50)
        {
            Instantiate(TeleportChargePrefab, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            _numberOfCharge = 100;

        }
        else if (_numberOfCharge <= 62)
        {
            Instantiate(ContractChargePrefab, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            _numberOfCharge = 100;

        }
        else if (_numberOfCharge <= 65)
        {
            Instantiate(CloneChargePrefab, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            _numberOfCharge = 100;

        }
    }



    private void DefendsAtackStart() // Атака которая будет защищять 
    {
        float xPos = 2.5f;
        for (int i = 0; i < 6; i++)
        {
            var _familiar = Instantiate(Familiars, new Vector3(xPos, 10f, 0), Quaternion.identity);
            xPos -= 1f;

        }
    }

 

    private void CircleAtackStart()
    {
        angle += Time.deltaTime; // меняется плавно значение угла
        var x = Mathf.Cos(angle * GameProperties.SpeedEnemy) * radius;
        var y = Mathf.Sin(angle * GameProperties.SpeedEnemy) * radius;
        familiarCircle.transform.position = new Vector2(x, y) + new Vector2(PlayerCar.position.x, PlayerCar.position.y);

        if (angle > 1.26)
        {
            _isCircleFamiliar = false;
            StopCoroutine(_circlefamiliarCoroutine);
            CarController.isCantMove = false;
            Destroy(familiarCircle);

            Invoke("CirclingAtackPushStart", 1f);
        }
    }

    private void CirclingAtackPushStart()
    {
        _StartPushingAtackCoroutine = StartCoroutine(ChoosePushAtack());
    }

    private void PlayerCenterPosition() // введем машину игрока в центр
    {
        if (PlayerCar.position.x == 0 && PlayerCar.position.y == 0)
        {
            _playerMoveCentre = false;
            _isCircleFamiliar = true;
            familiarCircle = Instantiate(FamiliarCirclePref, new Vector3(0, PlayerCar.position.y + 0.5f, 0), Quaternion.identity);
            CircleAtackStart();
            _circlefamiliarCoroutine = StartCoroutine(FamiliarCiclingSpawn());

        }
        else
        {
            PlayerCar.position = Vector3.MoveTowards(PlayerCar.position, new Vector3(0, 0, 0), Time.deltaTime * 5f);

        }
    }

    public void StartDestroyBos()
    {
        PlayerPrefs.SetInt("CementeryCompleate", 1);
        Instantiate(WinTable, WinTable.transform.position, WinTable.transform.rotation);
        PlayerPrefs.Save();

  
        if ((PlayerPrefs.HasKey("CementeryCompleate")))
        {
            Destroy(gameObject);
        }
        else
        {
            Invoke("EndLvl", 2f);
        }
       
    }

    private void EndLvl()
    {
        PlayerPrefs.SetInt("CementeryCompleate", 1);
        PlayerPrefs.Save();
        Destroy(gameObject);

    }

    private void BosCenterPosition() // введем машину игрока в центр
    {
        if (transform.position.x == 0 && transform.position.y == 0)
        {
            Anim.StopPlayback();
            scythe.StartFade();
            Anim.Play("NecroDeath");
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(0, 0), Time.deltaTime * 5f);

        }
    }

    private void StopedAtack() // останавлюваю атаку
    {
        StopAllCoroutines();
        isStopedAtack = true;
        _isDeadHandAtack = false;
        if(isLastAtack != true)
        {
            StartAnimationCast();

        }

        Invoke("ChangeAtack", 6f);

        if (familiarCircle != null)
        {
            Destroy(familiarCircle);
        }

        if (_nameOfAtacks == NameOfAtacks.DeadHandAtack)
        {
            _xPosPlayerCar.Clear();
            _yPosPlayerCar.Clear();
            _isDeadHandAtack = false;

        }
        else if (_nameOfAtacks == NameOfAtacks.CircleAtack)
        {
            Destroy(_coliderCircle);
        }else if(_nameOfAtacks == NameOfAtacks.FinalAtack)
        {
            _isCanDestroy = true;
            BosCenterPosition();
        }
    }

    IEnumerator DeadHandCentreAtackSpawn()
    {

        int isSpawnAtack = 0;
        int typeOfAtack = 0;
        int amountOfAtack = 0;


        while (true)
        {
            
            if(amountOfAtack >= 10)
            {
                typeOfAtack = UnityEngine.Random.Range(0, 2);
                amountOfAtack = 0;
            }

            isSpawnAtack = UnityEngine.Random.Range(0, 4);

            if (isSpawnAtack != 0)
            {
                Instantiate(DeadHandPref, familiarCircle.transform.position, Quaternion.identity);
                amountOfAtack++;
            }
         

            yield return new WaitForSeconds(0.1f);

        }
    }

    IEnumerator ChargeAtackSpawn()
    {

        int timeToReturnAtack = 0;

        while (true)
        {
            if(_amountOfCharge <= 3)
            {
                SpawnCharges();

            }
            timeToReturnAtack++;

            if(timeToReturnAtack >= 5)
            {
                _amountOfCharge = 0;
            }

            yield return new WaitForSeconds(1f);

        }


    }

    IEnumerator SpawnWalls()
    {


        int WallsOrintation = 0;
        int wasOrintation = 0;
        int lvlAtack = 0;

        while (true)
        {

            WallsOrintation = UnityEngine.Random.Range(1, 5);

            if (wasOrintation == WallsOrintation)
            {
                WallsOrintation = UnityEngine.Random.Range(1, 5);

                if (wasOrintation == WallsOrintation)
                {
                    WallsOrintation = UnityEngine.Random.Range(1, 5);

                    if (wasOrintation == WallsOrintation)
                    {
                        WallsOrintation = UnityEngine.Random.Range(1, 5);

                    }
                }
            }
            else
            {
                wasOrintation = WallsOrintation;
            }

            if (WallsOrintation == 1)
            {
                Instantiate(WallOfPlague, new Vector2(0, -10f), new Quaternion(0,0,90,0));
                if (lvlAtack >= 16)
                {
                    Instantiate(WallOfPlague, new Vector2(-6f, 0f), Quaternion.identity);
                }
            }
            else if(WallsOrintation == 2)
            {
                Instantiate(WallOfPlague, new Vector2(0, 10f), new Quaternion(0, 0, 90, 0));
                if (lvlAtack >= 16)
                {
                    Instantiate(WallOfPlague, new Vector2(6f, 0f), Quaternion.identity);
                }
            }
            else if (WallsOrintation == 3)
            {
                Instantiate(WallOfPlague, new Vector2(-6f, 0f), Quaternion.identity);
                if (lvlAtack >= 16)
                {
                    Instantiate(WallOfPlague, new Vector2(0, 10f), new Quaternion(0, 0, 90, 0));
                }
            }
            else if (WallsOrintation == 4)
            {
                Instantiate(WallOfPlague, new Vector2(6f, 0f), Quaternion.identity);
                if (lvlAtack >= 16)
                {
                    Instantiate(WallOfPlague, new Vector2(0, -10f), new Quaternion(0, 0, 90, 0));
                }
            }

            lvlAtack++;

            if(lvlAtack >= 10)
            {
                GameProperties.PlagueWallSpeed = 8f;
            }

            yield return new WaitForSeconds(1f);

        }
    }

    IEnumerator FamiliarCiclingSpawn()
    {

        _coliderCircle = Instantiate(ColiderCirclePref, new Vector3(0, 0, 0), Quaternion.identity);

        while (true)
        {
            if (familiarCircle != null)
            {
                var circlingFamiliar = Instantiate(FamiliarCirclingPref, familiarCircle.transform.position, Quaternion.identity);
                _cyrclingFamiliars.Add(circlingFamiliar);

            }

            yield return new WaitForSeconds(0.05f);

        }
    }

    IEnumerator ChoosePushAtack()
    {


        int Atack = 0;
        float timeToChange = 5f;

        while (true)
        {
            Atack = UnityEngine.Random.Range(1, 3);

            if(Atack == 1)
            {
                _circlePushCoroutine = StartCoroutine(CirclingAtackPush());
                timeToChange = 3f;
                if (_RandmFamiliarCoroutine != null)
                {

                    StopCoroutine(_RandmFamiliarCoroutine);
                }
            }
            else if(Atack == 2)
            {
                timeToChange = 5f;
                _RandmFamiliarCoroutine = StartCoroutine(RandomAtackPush());
                if(_circlePushCoroutine != null)
                {

                    StopCoroutine(_circlePushCoroutine);
                }
            }


            yield return new WaitForSeconds(timeToChange);

        }
    }

    IEnumerator CirclingAtackPush()
    {

        int numberOfAtack = 0;

        while (true)
        {
            if(_cyrclingFamiliars.Count > 0)
            {
                _cyrclingFamiliars[numberOfAtack].velocity = _cyrclingFamiliars[numberOfAtack].transform.up * 5f;
                numberOfAtack++;

            }

            if (numberOfAtack >= _cyrclingFamiliars.Count)
            {
                numberOfAtack = 0;
                if (_circlePushCoroutine != null)
                {
                    StopCoroutine(_circlePushCoroutine);
                }
            }

            yield return new WaitForSeconds(0.1f);

        }
    }

    IEnumerator RandomAtackPush()
    {

        int numberOfAtack = 0;

        while (true)
        {

            numberOfAtack = UnityEngine.Random.Range(0, _cyrclingFamiliars.Count);

            _cyrclingFamiliars[numberOfAtack].velocity = _cyrclingFamiliars[numberOfAtack].transform.up * 4f;

            yield return new WaitForSeconds(0.5f);

        }
    }
}