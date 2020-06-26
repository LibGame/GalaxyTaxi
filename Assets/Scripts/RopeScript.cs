using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{

    public GameObject Rope;
    public float YHeight = 1;
    public float TimeToDestroy = 5f;
    private bool toDestroy = false;

    void Start()
    {
        Invoke("DestroyRope", TimeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {


        if (toDestroy != true)
        {
            if (this.transform.position.y > YHeight)
            {
                this.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.BackGroundSpeed));
            }
            else
            {
                if (this.transform.position.x > 0)
                {
                    this.transform.Translate(Vector3.left * (Time.deltaTime * 3f));
                }
            }
        }

        if (toDestroy)
        {
            if (this.transform.position.x < 6)
            {
                this.transform.Translate(Vector3.right * (Time.deltaTime * 3f));
                
            }
            else
            {
                Destroy(Rope);

            }
        }
        
    }

    void DestroyRope()
    {
        toDestroy = true;
    } 
}
