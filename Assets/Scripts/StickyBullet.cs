using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickyBullet : MonoBehaviour
{
    private float _timeToStopBul;
    Rigidbody2D rb;
    private Vector3 _DegresseBullet = new Vector3(0.04f, 0.04f, 0f);
    private bool _isConfrontWithCar;
    public Text textClick;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void StopBul()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (_isConfrontWithCar)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.localScale -= _DegresseBullet;

            }

            if (transform.localScale.x < 0.08f)
            {
                CarController.isCantMove = false;
                Destroy(gameObject);
            }
        }


        if (this.transform.position.y + this.transform.position.y <= -10 || this.transform.position.y + this.transform.position.y >= 10
           || this.transform.position.x + this.transform.position.x <= -10 || this.transform.position.x + this.transform.position.x >= 10)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D confront)
    {
        if (confront.gameObject.tag == "PlayerCar")
        {
            textClick.enabled = true;
            _isConfrontWithCar = true;
            CarController.isCantMove = true;
            StopBul();
            Invoke("DestroyBullet", 4f);
        }
    }
}