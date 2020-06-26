using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLazerAtack : MonoBehaviour
{

    public GameObject LazerLauncher; // Префаб лазера который будет стрелять
    private int xPos; // позиция рандомного спавна по x
    private int yPos; // позиция рандомного спавна по y
    private float timeToSpawnLazer; // время спавна лазера
    System.Random rnd = new System.Random();
    public float timeToStart; // время когда начнеться атака
    public float timeToStop; // время когда закончиться атака

    void Start()
    {
        Invoke("isStart", timeToStart);
    }

    void isStart() // начинаем атаку и попутно вызываем время когда должна остановиться
    {
        Invoke("isStop", timeToStop);
        StartCoroutine(SpawnLazerAtack());

    }

    void isStop() // просто удаляем обьект когда заканчиваеться время
    {
        Destroy(gameObject);
    }

    IEnumerator SpawnLazerAtack() // атака где на тебя падают много поинтов и тебе нужно  их собирать , это карутина которая отвеает за появления этих потинтов
    {

        int isClearList = 0;
        int HardLvl = 0;

        List<int> XposList = new List<int>();
        List<int> YposList = new List<int>();

        while (true)
        {


            xPos = rnd.Next(-3, 3);
            yPos = rnd.Next(-4, 4);

            for (int j = 0; j < XposList.Count; j++)
            {
                if (XposList[j] == xPos)
                {
                    xPos = rnd.Next(-3, 3);
                    if (XposList[j] == xPos)
                    {
                        xPos = rnd.Next(-3, 3);
                        if (XposList[j] == xPos)
                        {
                            xPos = rnd.Next(-3, 3);
                            if (XposList[j] == xPos)
                            {
                                xPos = rnd.Next(-3, 3);
                            }
                        }
                    }

                }

            }

            for (int g = 0; g < YposList.Count; g++)
            {
                if (YposList[g] == yPos)
                {
                    yPos = rnd.Next(-4, 4);
                    if (YposList[g] == yPos)
                    {
                        yPos = rnd.Next(-4, 4);
                        if (YposList[g] == yPos)
                        {
                            yPos = rnd.Next(-4, 4);
                            if (YposList[g] == yPos)
                            {
                                yPos = rnd.Next(-4, 4);
                            }
                        }
                    }
                }

            }

            XposList.Add(xPos);
            YposList.Add(yPos);

            if (isClearList == 4)
            {
                XposList.Clear();
                YposList.Clear();
            }
            HardLvl++;
            isClearList++;

            Instantiate(LazerLauncher, new Vector3(xPos, yPos, 0), Quaternion.identity);

            if(HardLvl < 5)
            {
                timeToSpawnLazer = rnd.Next(1, 5);
            }
            else
            {
                timeToSpawnLazer = 1f;

            }

            yield return new WaitForSeconds(timeToSpawnLazer);
        }

    }
}
