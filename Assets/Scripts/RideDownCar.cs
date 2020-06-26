using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideDownCar : MonoBehaviour
{
    private bool _isCanChangePos;

    private void Update()
    {
        this.transform.Translate(Vector3.down * (Time.deltaTime * 5));


        if (this.transform.position.y <= -10 && _isCanChangePos != true)
        {
            _isCanChangePos = true;
            ChangePosition(); 
        }
    }
   
    
    private void ChangePosition()
    {
        float xPos = Random.Range(-2f, 2f);
        float yPos = Random.Range(30f, 100f);
        transform.position = new Vector3(xPos, yPos,1);
        _isCanChangePos = false;
    }
}