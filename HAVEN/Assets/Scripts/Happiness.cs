using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class Happiness : MonoBehaviour
{
    public static float happiness;
    public static float happyCount;
    public TextMeshProUGUI happinessText;
    public TileEditor tileEditor;

    void Start()
    {
        happiness = 0;
        happyCount = 0;
    }

    void Update() //Should probably be changed to a function that is updated only when amenities are added
    {
        happiness = happyCount/tileEditor.tileCount;
        //Debug.Log(happiness);
        happinessText.text = (happiness*100).ToString();
    }
}
