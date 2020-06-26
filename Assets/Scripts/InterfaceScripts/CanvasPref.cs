using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPref : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        canvas.worldCamera = Camera.main;
    }
}
