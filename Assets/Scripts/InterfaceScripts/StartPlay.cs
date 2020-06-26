using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlay : MonoBehaviour
{
    public enum GameLVL { CityRoad = 0, Cementery = 1 , Galactic = 2};
    public GameLVL gameLvl = GameLVL.CityRoad;
    public bool _isCityRoadCompleate;
    public bool _isCementeryCompleate;
    public bool _isGalacticCompleate;
    public GameObject LoadScreen;

    private void Start()
    {
        if (PlayerPrefs.HasKey("CityRoadCompleate"))
        {
            _isCityRoadCompleate = true;
        }
        if (PlayerPrefs.HasKey("CementeryCompleate"))
        {
            _isCementeryCompleate = true;
        }
        if (PlayerPrefs.HasKey("GalacticCompleate"))
        {
            _isGalacticCompleate = true;
        }
    }

    public void StartPlaying()
    {
        if (gameLvl == GameLVL.CityRoad)
        {
            Instantiate(LoadScreen, LoadScreen.transform.position, LoadScreen.transform.rotation);
            SceneManager.LoadScene("CityRoad"); 
        }
        else if (gameLvl == GameLVL.Cementery)
        {
            if (_isCityRoadCompleate)
            {
                Instantiate(LoadScreen, LoadScreen.transform.position, LoadScreen.transform.rotation);
                SceneManager.LoadScene("Cementery");
            }
        }
        else if (gameLvl == GameLVL.Galactic)
        {
            if (_isGalacticCompleate)
            {
                Instantiate(LoadScreen, LoadScreen.transform.position, LoadScreen.transform.rotation);
                print("is wordk");
                SceneManager.LoadScene("Galactic");
            }
        }
    }
}
