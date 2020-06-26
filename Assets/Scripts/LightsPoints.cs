using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightsPoints : MonoBehaviour
{

    public int NumberOfPoint;
    System.Random rnd = new System.Random();
    private int xPos;
    private int yPos;
    private float time = 0;
    public int amountAtack = 10;
    public int amountNowAtack = 0;

    void Update()
    {
        if (lightsBos.isCanDestoryPoint)
        {
            Destroy(gameObject);
        }


        time += Time.deltaTime * 2f;
        if(time >= 1.5f && lightsBos.typeOfAtack == 2)
        {
            time = 0;
            amountNowAtack++;
            xPos = rnd.Next(-2, 3);
            yPos = rnd.Next(-3, 4);
            transform.position = new Vector3(xPos, yPos, 0);
            CarController.GetDamage(20);

        }


        if (amountNowAtack >= amountAtack)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (NumberOfPoint == 1 && lightsBos.typeOfAtack == 2)
        {
           

        }
    }


        private void OnTriggerEnter2D(Collider2D confront)
        {

        if (NumberOfPoint == 1)
        {
            if (confront.gameObject.tag == "PlayerCar")
            {
                if (lightsBos.typeOfAtack == 1)
                {
                    lightsBos.isPointDestroy1 = true;
                    Destroy(gameObject);
                }else if (lightsBos.typeOfAtack == 2)
                {
                    time = 0;
                    amountNowAtack++;
                    xPos = rnd.Next(-2, 3);
                    yPos = rnd.Next(-3, 4);
                    transform.position = new Vector3(xPos,yPos,0);
                }
            }
        }
        if (NumberOfPoint == 2)
        {
            if (confront.gameObject.tag == "PlayerCar")
            {
                if (lightsBos.isPointDestroy1)
                {
                    lightsBos.isPointDestroy2 = true;
                    Destroy(gameObject);

                }
                else
                {
                    lightsBos.isWrongCombination = true;
                    print("is wrong");
                    Destroy(gameObject);
                }
            }
        }

        if (NumberOfPoint == 3)
        {
            if (confront.gameObject.tag == "PlayerCar")
            {
                if (lightsBos.isPointDestroy2)
                {
                    lightsBos.isPointDestroy3 = true;
                    Destroy(gameObject);

                }
                else
                {
                    lightsBos.isWrongCombination = true;
                    print("is wrong");

                    Destroy(gameObject);

                }
            }
        }

        if (NumberOfPoint == 4)
        {
            if (confront.gameObject.tag == "PlayerCar")
            {
                if (lightsBos.isPointDestroy3)
                {
                    lightsBos.isPointDestroy4 = true;
                    Destroy(gameObject);

                }
                else
                {
                    lightsBos.isWrongCombination = true;
                    print("is wrong");

                    Destroy(gameObject);

                }
            }
        }

        if (NumberOfPoint == 5)
        {
            if (confront.gameObject.tag == "PlayerCar")
            {
                if (lightsBos.isPointDestroy4)
                {
                    lightsBos.isPointDestroy5 = true;
                    Destroy(gameObject);

                }
                else
                {
                    lightsBos.isWrongCombination = true;
                    print("is wrong");

                    Destroy(gameObject);

                }
            }
        }

        if (NumberOfPoint == 6)
        {
            if (confront.gameObject.tag == "PlayerCar")
            {
                if (lightsBos.isPointDestroy5)
                {
                    lightsBos.isPointDestroy6 = true;
                    Destroy(gameObject);
                }
                else
                {
                    lightsBos.isWrongCombination = true;
                    print("is wrong");

                    Destroy(gameObject);

                }
            }
        }
    }
}
