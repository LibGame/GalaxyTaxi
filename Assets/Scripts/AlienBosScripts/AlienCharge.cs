using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienCharge : MonoBehaviour
{


    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector2(0.6f, 0.6f), Time.deltaTime/2);

        if (transform.position.y + transform.position.y <= -10 || transform.position.y + transform.position.y >= 10
            || transform.position.x + transform.position.x <= -10 || transform.position.x + transform.position.x >= 10)
        {
            Destroy(gameObject);
        }
    }
}
