using UnityEngine;

public class BuildingChanger : MonoBehaviour
{
    public Transform tilemap;
    public TileEditor tileEditor;

    public void ChangeBuilding(string name)
    {
        foreach (Transform child in tilemap)
        {
            if(child.name == name)
            {
                tileEditor.building = child;
                break;
            }
        }
    }
}
