using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeCroPlagueWall : MonoBehaviour
{
    private int _orentationToMove;

    void Start()
    {
        switch (transform.position.y)
        {
            case -10f:
                _orentationToMove = 2;
                break;
            case 10f:
                _orentationToMove = 1;
                break;
        }
        switch (transform.position.x)
        {
            case -6f:
                _orentationToMove = 3;
                break;
            case 6f:
                _orentationToMove = 4;
                break;
        }

    }

    void Update()
    {
        MoveWall();
    }

    private void MoveWall()
    {
        switch (_orentationToMove)
        {
            case 1:
                transform.Translate(Vector3.up * (Time.deltaTime * GameProperties.PlagueWallSpeed));
                break;
            case 2:
                transform.Translate(Vector3.down * (Time.deltaTime * GameProperties.PlagueWallSpeed));
                break;
            case 3:
                transform.Translate(Vector3.right * (Time.deltaTime * GameProperties.PlagueWallSpeed));
                break;
            case 4:
                transform.Translate(Vector3.left * (Time.deltaTime * GameProperties.PlagueWallSpeed));
                break;
        }

    }

    private void DestroyWall()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D confront)
    {
        if (confront.gameObject.tag == "1point")
        {
            switch (_orentationToMove)
            {
                case 1:
                    _orentationToMove = 2;
                    break;
                case 2:
                    _orentationToMove = 1;
                    break;
                case 3:
                    _orentationToMove =4;
                    break;
                case 4:
                    _orentationToMove = 3;
                    break;
            }

        }

        if (confront.gameObject.tag == "PlayerCar")
        {
            CarController.GetDamage(20);

        }

        Invoke("DestroyWall", 2f);
    }
}