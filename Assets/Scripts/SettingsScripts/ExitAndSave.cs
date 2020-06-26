using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitAndSave : MonoBehaviour
{
    public Scrollbar scBar;
    public GameObject panel;
    private AudioSource audio1;
    private AudioSource audio2;
    private void Start()
    {
        scBar.value = PlayerPrefs.GetFloat("soundValue");
        audio1 = GameObject.Find("Audio").GetComponent<AudioSource>();
        audio2 = GameObject.Find("CarSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveAndClose();
        }
    }

    public void SaveAndClose()
    {
        PlayerPrefs.SetFloat("soundValue", scBar.value);
        PlayerPrefs.Save();
        audio1.volume = scBar.value;
        audio2.volume = scBar.value;

        Destroy(panel);
    }
}
