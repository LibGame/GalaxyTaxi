using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPrevios : MonoBehaviour
{
    public enum ProjectMode { Next = 0, Pervios = 1 };
    public ProjectMode projectMode = ProjectMode.Next;
    
    public Sprite location1;
    public Sprite location2;
    public Sprite location3;

    public Image img;

    private int lvlNumber = 1;

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
                break;
            case 2:
                img.sprite = location2;
                print(lvlNumber);
                break;
            case 3:
                img.sprite = location3;
                print(lvlNumber);
                break;
        }
        
    }
}
