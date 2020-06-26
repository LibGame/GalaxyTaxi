using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour
{
    public GameObject Captions;
    public GameObject WinPanel;

    public void LvlNext()
    {
        if (CarController.IDName == 1)
        {
            SceneManager.LoadScene("Cementery"); 

        }
        else if(CarController.IDName == 2)
        {
            SceneManager.LoadScene("Galactic");

        }
        else if (CarController.IDName == 3)
        {
            Instantiate(Captions, Captions.transform.position, Captions.transform.rotation);
            Destroy(WinPanel);
        }
    }
}
