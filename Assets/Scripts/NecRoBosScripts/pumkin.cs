using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pumkin : MonoBehaviour
{
    public UnityEvent confrontEvent;
    private bool isMove = true;

    private void OnTriggerEnter2D(Collider2D confront)
    {
        if (confront.gameObject.tag == "PlayerCar")
        {
            confrontEvent.Invoke();
            isMove = false;
            Invoke("DestroyPumkin", 0.075f);
        }
    }

    private void DestroyPumkin()
    {
        Destroy(gameObject);

    }

    void Update()
    {
        if (isMove)
        {
            if (transform.position.y <= -4f)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.speedOil));
            }
        }
    }
}
