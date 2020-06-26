using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeCroCircling : MonoBehaviour
{
    Rigidbody2D rb;
    private bool _isAngel = true;
    private Vector3 _startPosition;
    private bool _isCanMoveBack;
    private float _distance;
    public GameObject familiar;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        Invoke("StopAngle", 1f);
    }

    private void OnTriggerEnter2D(Collider2D bulletConfront)
    {


        if (bulletConfront.gameObject.tag == "PlayerCar")
        {
            if (CarController.isRage != true)
            {
                InvokeRepeating("HitALlTheTime", 0f, 0.5f);
            }
        }

    }

    private void HitALlTheTime()
    {
        CarController.GetDamage(1);

    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isAngel)
        {
            var turn = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(Vector3.forward, new Vector3(0, 0, 0) - transform.position), Time.deltaTime * 4f);
            rb.MoveRotation(turn.eulerAngles.z);
        }
    }

    void Update()
    {
        _distance = Vector3.Distance(transform.position, new Vector3(0, 0, 0));


        if (_distance < 0.2f && _isCanMoveBack != true)
        {
            _isCanMoveBack = true;
            if (gameObject != null)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }
        if (_isCanMoveBack)
        {
            if (gameObject != null)
            {
                MoveBack();
            }
        }
    }

    public void FamiliarBack()
    {
        Destroy(gameObject);
    }


    private void MoveBack()
    {
        transform.position = Vector3.MoveTowards(transform.position, _startPosition, Time.deltaTime * GameProperties.SpeedEnemy);

        if (transform.position.Equals(_startPosition))
        {
            _isCanMoveBack = false;
            if (gameObject != null)
            {
                rb.constraints = RigidbodyConstraints2D.None;
            }

        }
    }

    private void StopAngle()
    {
        _isAngel = false;
        Invoke("DestroyObj", NeCroBos.timeToChangeAtack);

    }
}
