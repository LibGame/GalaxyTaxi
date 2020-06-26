using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {

        if (transform.position.y+ transform.position.y <=-20)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.BackGroundSpeed));

    }
}
