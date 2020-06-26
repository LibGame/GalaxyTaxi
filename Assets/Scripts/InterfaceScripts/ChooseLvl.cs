using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLvl : MonoBehaviour
{
    public GameObject chooseTable;

    public void ChooseLVL()
    {
        Instantiate(chooseTable, chooseTable.transform.position, Quaternion.identity);
    }
}
