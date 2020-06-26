
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScence : MonoBehaviour
{
    public string nameLvL;

    public void LoadLVL()
    {
        SceneManager.LoadScene(nameLvL); ;
        
    }

}
