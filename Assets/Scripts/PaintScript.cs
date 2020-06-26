using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintScript : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyOBJ", 1.5f);
    }

    private void DestroyOBJ()
    {
        Destroy(gameObject);
    }
}
