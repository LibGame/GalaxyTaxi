using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTablets : MonoBehaviour
{
    public GameObject[] TabletPrefabs;


    private int TimeSpawnTablet;

    private void Start()
    {
        StartCoroutine(TabletSpawn());
    }

    IEnumerator TabletSpawn()
    {
        int time = 2;
        int x = 0;
        int num = 0;
        while (true)
        {
            time = Random.Range(10, 30);
            x = Random.Range(-3, 3);
            num = Random.Range(0, 3);
            Instantiate(TabletPrefabs[num], new Vector3(x,this.transform.position.y,0), Quaternion.identity);
            yield return new WaitForSeconds(time);

        }
    }
}
