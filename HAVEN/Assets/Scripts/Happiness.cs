using UnityEngine;
using TMPro;

public class Happiness : MonoBehaviour
{
    public static float happiness;
    public static float happyCount = 0; //Keep this as a float
    public TextMeshProUGUI happinessText;
    public TileEditor tileEditor;

    void Awake()
    {
        happyCount = 0;
        happiness = 0;
    }

    void Update() //Should probably be changed to a function that is updated only when amenities are added
    {
        //happyCount = tileEditor.tileCount;
        happiness = happyCount/tileEditor.tileCount;
        happinessText.text = (happiness*100).ToString();
    }
}
