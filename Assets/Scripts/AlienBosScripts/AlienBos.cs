using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AlienBos : MonoBehaviour
{
    private enum NameOfAtacks // список всех атак
    {
        RandomSizeBullet = 0,
        GravityAtack = 1,
        AlienRise = 2,
        EyesAtack = 3,
        ForthBullt = 4,
    };
    private NameOfAtacks _nameOfAtacks; // экземпляр перечесления атак

    private Coroutine _randomSizeBullCoroutine;
    private Coroutine _arkBullCoroutine;
    private Coroutine _arkEyesCoroutine;
    private Coroutine _forthBullCoroutine;

    public Rigidbody2D RndSizeBulletPref;
    private GameObject Player;
    public GameObject ArkBullet;
    [SerializeField]
    private GameObject AlienRise;
    [SerializeField]
    private GameObject ForthBullt;
    public Transform BUlletPosition;
    public Transform ArkBulletPosition1;
    public Transform ArkBulletPosition2;
    [SerializeField]
    private Rigidbody2D ArkEyesBullet;
    [SerializeField]
    private Transform ArkEyesPosition;
    [SerializeField]
    private Transform[] ForthBulletPosition;
    private bool _isStart;
    private bool _isTimeIsUp;
    [SerializeField]
    private float _timeToStart = 1;
    [SerializeField]
    private float _timeToDestroy = 1;
    [SerializeField]
    private float _heightToStart = 1;
    [SerializeField]
    private float _timeToChangeAtack = 5f;
    private Rigidbody2D _playerRigidBody;
    private int _wasAtack;
    private int _RandomAtack = 1;
    public GameObject WinTable;
    private bool isNearGravityAtack;
    public GameObject HealthBar;
    private Vector3 _deathToScale;
    private bool _isHealthBarStart;


    public float angle = 0; // угол 
    public float radius = 0.2f; // радиус
    public float speed = 2f;
    public Vector2 cachedCenter;
    void Start()
    {
        Player = GameObject.FindWithTag("PlayerCar");
        _playerRigidBody = Player.GetComponent<Rigidbody2D>();
        Invoke("StartAtack", _timeToStart);
        _deathToScale = new Vector3(0, HealthBar.transform.localScale.y, 0);

    }

    void Update()
    {
        IsStart();
        TimeIsUp();
        HealthBarMovment();
        GravityAtack();
    }

    private void StartAtack()
    {
        _isStart = true;
    }

    private void GravityAtack()
    {
        if (_nameOfAtacks == NameOfAtacks.GravityAtack)
        {
            if (Player.transform.position.y <= -3f && isNearGravityAtack)
            {
                _playerRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
                isNearGravityAtack = false;
                _arkBullCoroutine = StartCoroutine(BulletSpawn());
                CarController._yPosLimitUp = 8f;
                CarController._yPosLimitDown = 2f;
            }
            else
            {
                Player.transform.Translate(Vector3.down * (Time.deltaTime * 3f));
            }
        }
    }

    private void IsStart()
    {

        if (_isStart)
        {
            if (transform.position.y >= _heightToStart)
            {
                transform.Translate(Vector3.down * (Time.deltaTime * 3f));
            }
            else
            {
                Invoke("ChangeAtack", 2f);
                _isHealthBarStart = true;
                cachedCenter = transform.position;
                _isStart = false;
            }
        }
    }

    private void HealthBarMovment()
    {

        if (_isHealthBarStart)
        {
            if (HealthBar.transform.localScale.x == 0)
            {
                _isTimeIsUp = true;
            }
            else
            {
                HealthBar.transform.localScale = Vector3.MoveTowards(HealthBar.transform.localScale, _deathToScale, (Time.fixedDeltaTime / _timeToDestroy) * 1.3f);

                angle += Time.deltaTime; // меняется плавно значение угла

                var x = Mathf.Cos(angle * speed) * radius;
                var y = Mathf.Sin(angle * speed) * radius;
                transform.position = new Vector2(x, y) +
                                cachedCenter - new Vector2(radius, 0);
            }
        }
    }

    private void TimeIsUp()
    {

        if (_isTimeIsUp)
        {
            if (transform.position.y >= 9)
            {
                PlayerPrefs.SetInt("GalacticCompleate", 1);
                Instantiate(WinTable, WinTable.transform.position, WinTable.transform.rotation);
                PlayerPrefs.Save();

                if ((PlayerPrefs.HasKey("GalacticCompleate")))
                {
                    Destroy(gameObject);
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
    }

    private void EndLvl()
    {
        PlayerPrefs.SetInt("GalacticCompleate", 1);
        PlayerPrefs.Save();
        Destroy(gameObject);

    }

    private void ChangeAtack()
    {

        _RandomAtack = UnityEngine.Random.Range(0, 5);

        if (_RandomAtack == _wasAtack)
        {
            while (_RandomAtack != _wasAtack)
            {
                _RandomAtack = UnityEngine.Random.Range(0, 5);
            }
        }

        _wasAtack = _RandomAtack;

        _nameOfAtacks = (NameOfAtacks)Enum.GetValues(typeof(NameOfAtacks)).GetValue(_RandomAtack);


        if (_nameOfAtacks == NameOfAtacks.RandomSizeBullet)
        {
            _randomSizeBullCoroutine = StartCoroutine(RandomSizeBulletSpawn());
            Invoke("StopedAtack", _timeToChangeAtack);

        }
        else if (_nameOfAtacks == NameOfAtacks.GravityAtack)
        {
            isNearGravityAtack = true;
            Invoke("StopedAtack", _timeToChangeAtack);

        }
        else if (_nameOfAtacks == NameOfAtacks.AlienRise)
        {
            Instantiate(AlienRise, transform.position, Quaternion.identity);
            Invoke("StopedAtack", 5f);

        }
        else if (_nameOfAtacks == NameOfAtacks.EyesAtack)
        {
            _arkEyesCoroutine = StartCoroutine(EyesBulletSpawn());
            Invoke("StopedAtack", _timeToChangeAtack);

        }
        else if (_nameOfAtacks == NameOfAtacks.ForthBullt)
        {
            _forthBullCoroutine = StartCoroutine(ForthBulletSpawn());
            Invoke("StopedAtack", _timeToChangeAtack);

        }
    }

    private void StopedAtack()
    {
        if (_nameOfAtacks == NameOfAtacks.AlienRise)
        {
            Destroy(GameObject.Find("LightRise(Clone)"));
        }

        CarController._yPosLimitUp = 0.5f;
        CarController._yPosLimitDown = 0.5f;

        StopAllCoroutines();

        Invoke("ChangeAtack", 2f);
    }


    private IEnumerator RandomSizeBulletSpawn()
    {

        while (true)
        {
            var turn = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, Player.transform.position - transform.position), 1000f);
            var bullet = Instantiate(RndSizeBulletPref, BUlletPosition.position, turn);

            bullet.velocity = bullet.transform.up * GameProperties.RocketSpeed;

            yield return new WaitForSeconds(0.3f);

        }
    }


    private IEnumerator BulletSpawn()
    {

        while (true)
        {
            Instantiate(ArkBullet, ArkBulletPosition1.position, ArkBullet.transform.rotation);
            Instantiate(ArkBullet, ArkBulletPosition2.position, ArkBullet.transform.rotation);

            yield return new WaitForSeconds(0.7f);

        }
    }


    private IEnumerator ForthBulletSpawn()
    {

        while (true)
        {
            Instantiate(ForthBullt, ForthBulletPosition[0].position, ForthBulletPosition[0].rotation);
            Instantiate(ForthBullt, ForthBulletPosition[1].position, ForthBulletPosition[1].rotation);
            Instantiate(ForthBullt, ForthBulletPosition[2].position, ForthBulletPosition[2].rotation);
            Instantiate(ForthBullt, ForthBulletPosition[3].position, ForthBulletPosition[3].rotation);

            yield return new WaitForSeconds(0.7f);

        }
    }

    private IEnumerator EyesBulletSpawn()
    {

        while (true)
        {
            var turn = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, Player.transform.position - transform.position), 1000f);
            var bullet = Instantiate(ArkEyesBullet, ArkEyesPosition.position, turn);
            bullet.velocity = bullet.transform.up * GameProperties.RocketSpeed;

            yield return new WaitForSeconds(0.5f);

        }
    }
}
