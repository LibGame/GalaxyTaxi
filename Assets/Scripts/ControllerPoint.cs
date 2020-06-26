using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPoint : MonoBehaviour
{
    private Vector3 offset;
    public float RotationCar = 1;
    private Camera myMain;
    private bool isMove = false;

    void Start()
    {
        myMain = Camera.main;

    }



    void Update()
    {
        if (isMove)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }


        Vector2 cameraToObject = transform.position - Camera.main.transform.position;
        // отрицание потому что игровые объекты в данном случае находятся ниже камеры по оси y
        float distance = -Vector3.Project(cameraToObject, Camera.main.transform.forward).y;

        // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
        Vector2 leftBot = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 rightTop = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 Top = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 Bottom = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
        float x_left = leftBot.x + 0.3f;
        float x_right = rightTop.x - 0.3f;
        float y_Top = Top.y + 0.5f;
        float y_Bottom = Bottom.y - 0.5f;



        // ограничиваем объект в плоскости XZ
        Vector2 clampedPos = transform.position;

        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
        clampedPos.y = Mathf.Clamp(clampedPos.y, y_Top, y_Bottom);
        transform.position = clampedPos;
    }
}
