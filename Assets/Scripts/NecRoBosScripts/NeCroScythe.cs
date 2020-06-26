using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeCroScythe : MonoBehaviour
{
    private float _rotationScythe;
    private int amountMove = 1;
    private bool _isIncresase;
    public Transform necroAlive;

    void Start()
    {
        StartCoroutine(ScytheAtack());
    }

    void Update()
    {
        if(amountMove == 0)
            HitOfScythe();

    }

    IEnumerator ScytheAtack()
    {

        while (true)
        {
            amountMove = 0;
            yield return new WaitForSeconds(3f);

        }
    }

    private void HitOfScythe()
    {
        if (_isIncresase)
        {
            if (_rotationScythe < -22)
            {
                _rotationScythe += Time.deltaTime * 300f;
            }
            else
            {
                _isIncresase = false;
                amountMove = 1;

            }
        }
        else
        {
            if (_rotationScythe > -201)
            {
                _rotationScythe -= Time.deltaTime * 300f;
            }
            else
            {
                _isIncresase = true;

            }

        }

        if (amountMove != 1)
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, necroAlive.rotation.z + _rotationScythe);
    }
}
