using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class Happiness : MonoBehaviour
{
    public static float happiness;
    public static int happyCount;
    public TextMeshProUGUI happinessText;
    public TileEditor tileEditor;

    void Update() //Should probably be changed to a function that is updated only when amenities are added
    {
        happiness = happyCount/tileEditor.tileCount;
        happinessText.text = happiness.ToString();
    }
}
