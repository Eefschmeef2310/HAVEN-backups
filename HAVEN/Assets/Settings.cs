using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject settings;
    public GameObject menus;
    public void ShowSettings()
    {
        foreach(Transform menu in menus.transform)
        {
            menu.gameObject.SetActive(false);
        }

        settings.SetActive(true);
    }
}
