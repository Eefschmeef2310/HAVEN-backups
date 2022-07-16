using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsClose : MonoBehaviour
{
    public GameObject settings;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            settings.SetActive(false);
        }
    }
}
