using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemyDestroyer : MonoBehaviour
{

    public float timeDestroy = 0.5f;

    void Start()
    {
        Invoke("DestroyObject", timeDestroy);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}
