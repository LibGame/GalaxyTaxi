using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WRpoints : MonoBehaviour
{

    public enum PointMode { isWrong = 0, isRight = 1 };
    public PointMode pointMode = PointMode.isWrong;

    private void OnTriggerEnter2D(Collider2D confront)
    {

        if (pointMode == PointMode.isRight)
        {
            if (confront.gameObject.tag == "PlayerCar")
            {
                lightsBos.isRightPoint = true;
                Destroy(gameObject);

            }
        }

        if (pointMode == PointMode.isWrong)
        {
            if (confront.gameObject.tag == "PlayerCar")
            {
                lightsBos.isWrongPoint = true;
                CarController.GetDamage(15);
                Destroy(gameObject);

            }
        }
    }

    void Update()
    {
        this.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.PointsSpeed));


        if (this.transform.position.y + this.transform.position.y <= -20)
        {
            Destroy(gameObject);
        }
    }
}
