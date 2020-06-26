using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{

    public GameObject settingsPanel;

    public void OpenSettings()
    {
        Instantiate(settingsPanel, settingsPanel.transform.position, Quaternion.identity);
    }
}
