using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFrom : MonoBehaviour
{
    public GameObject table;

    public void ExitFromElement()
    {
        Destroy(table);
    }
}
