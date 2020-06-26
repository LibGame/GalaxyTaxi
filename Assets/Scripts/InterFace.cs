using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterFace : MonoBehaviour
{

    public Text PointTime;
    public static int PointAmountTime ;

    void Update()
    {
        PointTime.text = PointAmountTime.ToString();
    }
}
