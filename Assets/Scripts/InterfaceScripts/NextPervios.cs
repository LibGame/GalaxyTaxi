using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPervios : MonoBehaviour
{
    public enum ProjectMode { Next = 0, Pervios = 1 };
    public ProjectMode projectMode = ProjectMode.Next;

    public Sprite location1;
    public Sprite location2;
    public Sprite location3;
    public Color blockedColor;
    public Color unblockedColor;
    public Image blocked;
    public Image img;
    public Text difficulty;
    public StartPlay startPlay;

    private static int lvlNumber = 1;


    public void ChangeLvl()
    {

        if (projectMode == ProjectMode.Next)
        {
            lvlNumber++;
            Change();
        }
        else if (projectMode == ProjectMode.Pervios)
        {
            lvlNumber--;
            Change();

        }
    }

    private void Change()
    {


        switch (lvlNumber)
        {
            case 1:
                img.sprite = location1;
                startPlay.gameLvl = StartPlay.GameLVL.CityRoad;
                difficulty.text = "easy";
                blocked.enabled = false;
                img.color = unblockedColor;
                break;
            case 2:
                img.sprite = location2;
                startPlay.gameLvl = StartPlay.GameLVL.Cementery;
                if (startPlay._isCityRoadCompleate != true)
                {
                    img.color = blockedColor;
                    difficulty.text = "medium";
                    blocked.enabled = true;
                }
                else
                {
                    difficulty.text = "medium";
                    img.color = unblockedColor;
                }
                break;
            case 3:
                img.sprite = location3;
                startPlay.gameLvl = StartPlay.GameLVL.Galactic;
                if (startPlay._isCementeryCompleate != true)
                {
                    img.color = blockedColor;
                    difficulty.text = "hard";
                    blocked.enabled = true;
                }
                else
                {
                    difficulty.text = "hard";

                    img.color = unblockedColor;
                }
                break;
        }


        if (lvlNumber <= 0)
        {
            lvlNumber = 1;
        }

        if (lvlNumber >= 3)
        {
            lvlNumber = 3;
        }

    }
}