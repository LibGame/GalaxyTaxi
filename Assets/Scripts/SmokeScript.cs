using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{

    public Transform SmokePosition;
    public GameObject SmokeOnAllScreenPrefab;
    public float TimeToOffSmokeScreen = 2f;
    
    void Update()
    {

        this.transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.BosRocket));

        if(this.transform.position.y + this.transform.position.y <= -20)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D SmokeConfront)
    {

        if (SmokeConfront.gameObject.tag == "PlayerCar")
        {

            Invoke("FinishSmoke", TimeToOffSmokeScreen);

            if (GameProperties.isCarPoutionSmoke != true)
            {
                Instantiate(SmokeOnAllScreenPrefab, SmokePosition.position, SmokePosition.rotation);
                GameProperties.isCarPoutionSmoke = true;
            }
            
        }

    }

    private void FinishSmoke()
    {
        GameProperties.isCarPoutionSmoke = false;
    }

}
