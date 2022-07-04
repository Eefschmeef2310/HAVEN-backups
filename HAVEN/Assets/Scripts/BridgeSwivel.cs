using UnityEngine;
using UnityEngine.Tilemaps;

public class BridgeSwivel : MonoBehaviour
{
    //This program needs to get surrounding cells, check which is the FIRST that has a tile, then swivel the bridge that way
    void Start()
    {
        Tilemap tilemap = transform.parent.GetComponent<Tilemap>();
        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);

        //Debug.Log(cellPosition.y);
        
        Vector3Int[] surroundingCells = {cellPosition + Vector3Int.up, 
            cellPosition + Vector3Int.right, 
            cellPosition + Vector3Int.down, 
            cellPosition + Vector3Int.down + Vector3Int.left, 
            cellPosition + Vector3Int.left, 
            cellPosition + Vector3Int.left + Vector3Int.up};

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
            Vector3 sphere = new Vector3(surroundingCells[i].x, 0, surroundingCells[i].y*0.75f);
            //Debug.Log(Physics.OverlapSphere(sphere,0.1f)[0]);
            if (Physics.OverlapSphere(sphere,0.1f)[0].gameObject.transform.parent.parent.tag == "Tile" && Physics.OverlapSphere(sphere,0.1f)[0].gameObject.tag != "Amenity")
            {
                Debug.Log(i);
                if(cellPosition.y % 2 == 0)
                {
                    transform.rotation = Quaternion.Euler(0, 60*(i), 0);
                    return;
                }
                else
                {
                    //Debug.Log("test");
                    if(cellPosition.y > 0)
                    {
                        Debug.Log("bruh");
                        transform.rotation = Quaternion.Euler(0, 60*(i-1), 0);
                        return;
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 60*(i-1), 0);
                        return;
                    }
                }
            }
        }
    }
}
