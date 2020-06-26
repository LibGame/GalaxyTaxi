using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSmokeScript : MonoBehaviour
{

    public float EffectTimeIsUp = 3f;
    
    void Start()
    {
        Invoke("DestroyEffect", EffectTimeIsUp);
    }

    private void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
