using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilScript : MonoBehaviour
{

    void FixedUpdate()
    {
        if(this.transform.position.y + this.transform.position.y <= -20)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.transform.Translate(Vector3.down * (Time.deltaTime * 3));
        }
    }
}
