using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBomb : MonoBehaviour
{
    public GameObject ExplosionPref;
    public GameObject BombPref;
    Vector3 postion;

    void Start()
    {
        postion = this.transform.position;
        Invoke("Explosion", 2f);
    }

    void Explosion()
    {
        Instantiate(ExplosionPref, postion, Quaternion.identity);
        Destroy(BombPref);
    }


    private void OnTriggerEnter2D(Collider2D confront)
    {
        if (confront.gameObject.tag == "DestroyerMap")
        {
            Destroy(gameObject);
        }
    }
}
