using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpLineOfEnemy : MonoBehaviour
{

    private int index = 0;
    private float DestroyTime;
    private float StartTime;

    private static float ySize;

    void Start()
    {
        ySize = transform.localScale.y; 
    }


    public void HpLifeLineMethod(float destroyTime, float startTime)
    {
        StartTime = startTime;
        DestroyTime = destroyTime;
        Invoke("StartCoroutines", startTime);
    }

    IEnumerator c_Scale()
    {

        Vector3[] scales = new Vector3[2]
 {
        new Vector3(0.003f, ySize, 1.0f),
        new Vector3(1.0f, 0.09223899f, 1.0f)
 };


        while (true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, scales[index], (Time.fixedDeltaTime / DestroyTime) * 4);

            if (Vector3.Distance(transform.localScale, scales[index]) < 0.003f)
            {
                Destroy(gameObject);

                if (++index > 1)
                {
                    index = 0;
                }
            }

            yield return null;
        }
    }

    void StartCoroutines()
    {
        StartCoroutine(c_Scale());
    }
}
