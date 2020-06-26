using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToUnNumb : MonoBehaviour
{
    public Text spRenderer;
    public Color color1;
    public Color color2;
    private int _colorId = 1;


    private void Start()
    {
        StartCoroutine(BulletSpawn());
    }

    private IEnumerator BulletSpawn()
    {

        while (true)
        {
            _colorId++;

            if (_colorId % 2 == 0)
            {
                spRenderer.color = color1;
            }
            else
            {
                spRenderer.color = color2;
            }
            


            yield return new WaitForSeconds(0.1f);

        }
    }

}
