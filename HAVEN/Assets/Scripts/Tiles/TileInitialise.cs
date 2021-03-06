using UnityEngine;
using UnityEngine.Tilemaps;

public class TileInitialise : MonoBehaviour
{
    public int experience;
    public Leveling leveling;
    [HideInInspector] public Vector3Int[] surroundingCells;

    void Start()
    {
        leveling.experience += experience;
        if(gameObject.name == "WoodBridge(Clone)")
        {
            gameObject.GetComponent<BridgeSwivel>().SwivelBridge();
        }
        InitialiseTile(); 
    }

    public void InitialiseTile()
    {
        Tilemap tilemap = transform.parent.GetComponent<Tilemap>();
        Transform red = gameObject.transform.Find("Red");        

        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);

        surroundingCells = new Vector3Int[6];

        surroundingCells[0] = cellPosition + Vector3Int.up; 
        surroundingCells[1] = cellPosition + Vector3Int.right; 
        surroundingCells[2] = cellPosition + Vector3Int.down;
        surroundingCells[3] = cellPosition + Vector3Int.down + Vector3Int.left;
        surroundingCells[4] = cellPosition + Vector3Int.left;
        surroundingCells[5] = cellPosition + Vector3Int.left + Vector3Int.up;

        if (cellPosition.x != surroundingCells[3].x && cellPosition.y % 2 != 0)
        {
            surroundingCells[3] = cellPosition + Vector3Int.right + Vector3Int.down;
        }

        if (cellPosition.x != surroundingCells[5].x && cellPosition.y % 2 != 0)
        {
            surroundingCells[5] = cellPosition + Vector3Int.right + Vector3Int.up;
        }

        for (int i = 0; i <= surroundingCells.Length - 1; i++)
        {
            Vector3 pos = tilemap.GetCellCenterWorld(surroundingCells[i]);
        
            if (!Physics.CheckSphere(pos, 0.1f)) //nothing there
            {
                Instantiate(red, pos, Quaternion.Euler(0,30,0), transform);
            }
        }

        foreach(Transform child in tilemap.transform)
        {
            if(child.tag == "Amenity" && child.gameObject.activeSelf)
            {
                child.gameObject.GetComponent<GenerateHappiness>().Start();
            }
        }
    }
}