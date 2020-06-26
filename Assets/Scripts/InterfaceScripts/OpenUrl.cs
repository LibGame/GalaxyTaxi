using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    public string link;

    public void OpneUrl()
    {
        Application.OpenURL(link);
    }
}
