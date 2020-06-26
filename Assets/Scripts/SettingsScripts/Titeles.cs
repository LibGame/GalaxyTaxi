using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titeles : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        canvas.worldCamera = Camera.main;
        canvas.sortingOrder = 30;
 
    }
}
