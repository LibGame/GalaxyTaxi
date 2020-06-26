using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterTraectory : MonoBehaviour
{
    public GameObject TargetObject;

    private Rigidbody2D[] spores = new Rigidbody2D[9];
    private int angles = 0;
    private Vector2 _positionForce;
    public Rigidbody2D ShellPrefab;
    private int _random;
    private Camera myMain;
    public Animation anim;
    public AnimationClip clip;
    private Keyframe keyX1;
    private Keyframe keyX2;

    private void Start()
    {
        TargetObject = GameObject.Find("carPlayer");
        myMain = Camera.main;

        AnimationCurve curveY = AnimationCurve.Linear(0f, transform.position.y, 1F, TargetObject.transform.position.y);
        AnimationCurve curveX = AnimationCurve.Linear(0f, transform.position.x, 1F, TargetObject.transform.position.x);
        keyX1 = new Keyframe(0.5f, 2);
        keyX2 = new Keyframe(1f, transform.position.x);

        curveX.AddKey(keyX1);
        curveX.AddKey(keyX2);

        clip.SetCurve("", typeof(Transform), "localPosition.y", curveY);
        clip.SetCurve("", typeof(Transform), "localPosition.x", curveX);

        anim.AddClip(clip, "test");
        anim.Play("test");
    }




    private void Update()
    {

        // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
        Vector2 leftBot = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 rightTop = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 Top = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 Bottom = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
        float x_left = leftBot.x + 0.8f;
        float x_right = rightTop.x - 0.8f;
        float y_Top = Top.y + 0.8f;
        float y_Bottom = Bottom.y - 0.8f;



        // ограничиваем объект в плоскости XZ
        Vector2 clampedPos = transform.position;

        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
        clampedPos.y = Mathf.Clamp(clampedPos.y, y_Top, y_Bottom);
    }


    private void ShootShells()
    {

        for (int i = 0; i < spores.Length; i++)
        {
            spores[i] = Instantiate(ShellPrefab, transform.position, Quaternion.Euler(0, 0, angles));
            angles += 40;
        }

        for (int j = 0; j < spores.Length; j++)
        {
            spores[j].velocity = spores[j].transform.up * GameProperties.RocketSpeed;
        }

        Destroy(gameObject);

    }
}
