using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Happiness : MonoBehaviour
{
    public static float happiness;
    public static List<GameObject> happyList = new List<GameObject>();
    public static float happyCount = 0; //Keep this as a float
    public TextMeshProUGUI happinessText;
    public TileEditor tileEditor;

    void Start()
    {
        happyCount = 0;
        happiness = 0;
    }

    public void Update() //Should probably be changed to a function that is updated only when amenities are added
    {
        //happyCount = tileEditor.tileCount;
        //Debug.Log(happyList.Count);
        happiness = (float)happyList.Count/tileEditor.tileCount;
        //Debug.Log(happiness);
        happinessText.text = (happiness*100).ToString();
    }
}
