using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRotationAtackChange : MonoBehaviour
{

    int xPos;
    int yPos;

    private void OnTriggerEnter2D(Collider2D Confront)
    {
        if (Confront.gameObject.tag == "RotationTank")
        {
            rotationTankSript.isCanShoot = true;
            Invoke("ChangePosition", 2f);

        }
    }

    void Start()
    {
        ChangePosition();
        StartCoroutine(StartCheckToStop());
    }

    void ChangePosition()
    {
        xPos = Random.Range(-2, 2);
        yPos = Random.Range(-4, 4);

        transform.position = new Vector3(xPos, yPos, 0);
    }



    IEnumerator StartCheckToStop()
    {

        float xPosCheck = 0;
        float yPosCheck = 0;

        while (true)
        {
            if(transform.position.x == xPosCheck && transform.position.y == yPosCheck)
            {
                ChangePosition();
            }
            xPosCheck = transform.position.x;
            yPosCheck = transform.position.y;

            yield return new WaitForSeconds(2f);
        }
    }
}
