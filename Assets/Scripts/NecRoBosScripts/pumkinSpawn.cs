using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumkinSpawn : MonoBehaviour
{

    public GameObject[] pumkins;
    private int TimeSpawnTablet;




    private void Start()
    {
        StartCoroutine(pumkinpawn());

    }

    IEnumerator pumkinpawn()
    {
        int time = 2;
        float x = 0;
        int num = 0;
        while (true)
        {
            time = Random.Range(5, 10);
            x = Random.Range(-2.5f, 2.5f);
            num = Random.Range(0, pumkins.Length);
            Instantiate(pumkins[num], new Vector3(x, this.transform.position.y, 0), Quaternion.identity);
            yield return new WaitForSeconds(time);

        }
    }
}
