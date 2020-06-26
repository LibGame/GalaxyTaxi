using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public static int Life = 100;
    public float SpeedFollow = 100f;
    public float MoveSpeed = 50.0f;
    public static bool isRage = false;
    public float RotationCar = 1;
    public int isAmountOfFireHit;
    private bool isFireing = false;
    public GameObject BurningPrefab;
    public GameObject Car;
    Rigidbody2D bodyOfCar;
    public static bool isPaint = false;

    public Transform parent;
    public static bool RightLeft = false;
    public static bool UpDown = false;
    public static bool isCanMove = true;
    public static bool isMoveCar = true;
    public static bool isUnderGravity;
    private static GameObject[] hitPoint = new GameObject[10];
    public GameObject[] hitPointNonStatic = new GameObject[10];
    public static bool LoseGame = false;
    public static bool isCantMove;
    public static int Direction = 0; // 1 в верх , 2 в низ , 3 в право , 4 в лево
    private Camera myMain;
    private bool moveToCenter;
    public static float _yPosLimitUp = 0.5f;
    public static float _yPosLimitDown = 0.5f;
    private float xPosBefore;
    [SerializeField]
    private Sprite leftSprite;
    [SerializeField]
    private Sprite rightSprite;
    [SerializeField]
    private Sprite defaultSprite;
    private SpriteRenderer _spRendrer;
    private static GameObject LoseTablePref;
    public GameObject LoseTable;
    public static int IDName;
    public int NameLvl;
    private static bool _secondLife = false;
    private static int _secondLifeAmount;
    [SerializeField]
    private GameObject RoadEffects;
    public Transform pointOfEffects;
    void Start()
    {
        bodyOfCar = GetComponent<Rigidbody2D>();
        _spRendrer = GetComponent<SpriteRenderer>();
        myMain = Camera.main;
        LoseTablePref = LoseTable;
        IDName = NameLvl;

        Life = 100;

        if (PlayerPrefs.HasKey("SecondLife"))
        {
            _secondLifeAmount = PlayerPrefs.GetInt("SecondLife");
            _secondLife = true;         
        }

        if (PlayerPrefs.HasKey("UseEffects"))
        {
            if (PlayerPrefs.GetInt("UseEffects") == 1)
            {
                var effect = Instantiate(RoadEffects, pointOfEffects.position, RoadEffects.transform.rotation);
                effect.transform.SetParent(gameObject.transform);
            }
        }
        else
        {
            PlayerPrefs.SetInt("UseEffects", 1);
            PlayerPrefs.Save();
        }


        hitPoint[0] = hitPointNonStatic[0];
        hitPoint[1] = hitPointNonStatic[1];
        hitPoint[2] = hitPointNonStatic[2];
        hitPoint[3] = hitPointNonStatic[3];
        hitPoint[4] = hitPointNonStatic[4];
        hitPoint[5] = hitPointNonStatic[5];
        hitPoint[6] = hitPointNonStatic[6];
        hitPoint[7] = hitPointNonStatic[7];
        hitPoint[8] = hitPointNonStatic[8];
        hitPoint[9] = hitPointNonStatic[9];

        hitPoint[0].SetActive(true);
        hitPoint[1].SetActive(true);
        hitPoint[2].SetActive(true);
        hitPoint[3].SetActive(true);
        hitPoint[4].SetActive(true);
        hitPoint[5].SetActive(true);
        hitPoint[6].SetActive(true);
        hitPoint[7].SetActive(true);
        hitPoint[8].SetActive(true);
        hitPoint[9].SetActive(true);

    }

    private Vector3 offset;

    void OnMouseDown()
    {

        offset = gameObject.transform.position -
        myMain.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        

    }

    void OnMouseDrag()
    {

        xPosBefore = transform.position.x;

        if (isCantMove != true)
        {



            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
            InclineCar();

        }
    }

    public void OnMouseUp()
    {
        _spRendrer.sprite = defaultSprite;

    }

    public static void GetDamage(int damage)
    {
        Life -= damage;
        AmountOfHP();
    }

    void Update()
    {

        if (moveToCenter)
        {
            PlayerCenterPosition();
        }



        // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
        Vector2 leftBot = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 rightTop = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 Top = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 Bottom = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
        float x_left = leftBot.x + 0.3f;
        float x_right = rightTop.x - 0.3f;
        float y_Top = Top.y + _yPosLimitDown;
        float y_Bottom = Bottom.y - _yPosLimitUp;



        // ограничиваем объект в плоскости XZ
        Vector2 clampedPos = transform.position;

        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
        clampedPos.y = Mathf.Clamp(clampedPos.y, y_Top, y_Bottom);
        transform.position = clampedPos;
    }

    public void InclineCar()
    {

        if (transform.position.x > xPosBefore)
        {
            _spRendrer.sprite = rightSprite;
        }
        else if (transform.position.x < xPosBefore)
        {
            _spRendrer.sprite = leftSprite;
        }
    }

    public static void AmountOfHP()
    {
        if (Life < 100)
        {
            hitPoint[9].SetActive(false);
        }
        if (Life < 90)
        {
            hitPoint[8].SetActive(false);

        }
        if (Life < 80)
        {
            hitPoint[7].SetActive(false);

        }
        if (Life < 70)
        {
            hitPoint[6].SetActive(false);

        }
        if (Life < 60)
        {
            hitPoint[5].SetActive(false);

        }
        if (Life < 50)
        {
            hitPoint[4].SetActive(false);

        }
        if (Life < 40)
        {
            hitPoint[3].SetActive(false);

        }
        if (Life < 30)
        {
            hitPoint[2].SetActive(false);

        }
        if (Life < 20)
        {
            hitPoint[1].SetActive(false);

        }
        if (Life < 10)
        {
            hitPoint[0].SetActive(false);

        }
        if (Life <= 0)
        {
            if (_secondLife)
            {
                _secondLife = false;
                _secondLifeAmount--;
                PlayerPrefs.SetInt("SecondLife", _secondLifeAmount);
                PlayerPrefs.Save();
            }
            else
            {
                Instantiate(LoseTablePref, LoseTablePref.transform.position, Quaternion.identity);
                LoseGame = true;
            }
        }
    }


    private void PlayerCenterPosition() // введем машину игрока в центр
    {
        if (transform.position.x == 0 && transform.position.y == 0)
        {
            moveToCenter = false;
            isCantMove = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), Time.deltaTime * 5f);

        }
    }

    public void payContrackt()
    {
        Invoke("MinusHP", 5f);
    }

    private void MinusHP()
    {
        Life -= 40;
    }

    private void OnTriggerEnter2D(Collider2D confront)
    {


        if(confront.gameObject.tag == "CirclingCollider")
        {
            moveToCenter = true;
            isCantMove = true;
        }

        if (confront.gameObject.tag == "StickyBul")
        {
            bodyOfCar.constraints = RigidbodyConstraints2D.FreezePosition;
            isMoveCar = false;
            Invoke("CanMove", 2f);
        }

    }



    void CanMove()
    {
        isMoveCar = true;
    }


}