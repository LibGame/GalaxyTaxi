using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeCyrcleBos3 : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    private GameObject endMarker;
    private bool isStop = false;

    // Move to the target end position.

    void Start()
    {
        endMarker = GameObject.Find("CyrclePoint3");
        Invoke("ChangeAtack", WildBikerBos.timeToChangeAtack);
    }

    void Update()
    {

        if (isStop != true)
        {
            transform.position = Vector3.Lerp(this.transform.position, endMarker.transform.position, Time.deltaTime * 2f);


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

        if (isStop)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * 6f));

            if (this.transform.position.y + this.transform.position.y <= -20 || this.transform.position.y + this.transform.position.y >= 20
                    || this.transform.position.x + this.transform.position.x <= -20 || this.transform.position.x + this.transform.position.x >= 20)
            {

                Destroy(gameObject);

            }
        }


    }

    void ChangeAtack()
    {
        isStop = true;
    }
}
