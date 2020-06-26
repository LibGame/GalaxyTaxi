using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarII : MonoBehaviour
{

    private bool _isConfront = true;
    public static bool _isMoveRight;
    public static int Speed = 3;


    private void Update()
    {
        if (_isConfront)
        {
            if (_isMoveRight)
            {
                transform.Translate(Vector3.right * (Time.deltaTime * Speed));
            }else if (_isMoveRight != true)
            {
                transform.Translate(Vector3.left * (Time.deltaTime * Speed));
            }
        }

        // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
        Vector3 leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));

        // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
        float x_left = leftBot.x + 0.4f;
        float x_right = rightTop.x - 0.4f;


        // ограничиваем объект в плоскости XZ
        Vector2 clampedPos = transform.position;

        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);

        if (transform.position.x < x_left)
        {
            _isMoveRight = true;
        }

        if (transform.position.x > x_right)
        {
            _isMoveRight = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D Confront)
    {
        if (Confront.gameObject.tag == "Enemy")
        {
            _isConfront = true;

            if(transform.position.x > 0)
            {
                _isMoveRight = true;
            }
            else if (transform.position.x < 0)
            {
                _isMoveRight = false;

            }

        }
    }
}
