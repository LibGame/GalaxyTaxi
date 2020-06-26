using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTablet : MonoBehaviour
{

    public GameObject TabletRagePrefabs;

    private int TimeSpawnTablet;

    void Start()
    {
        print("is work");

        TimeSpawnTablet = Random.Range(6, 10);
        print(TimeSpawnTablet);
        Invoke("TabletDischarge", TimeSpawnTablet);
    }

    void TabletDischarge()
    {
        print("is work");
        Instantiate(TabletRagePrefabs, this.transform.position, this.transform.rotation);
    }
}
