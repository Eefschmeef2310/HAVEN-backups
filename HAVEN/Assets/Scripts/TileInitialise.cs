using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class TileInitialise : MonoBehaviour
{
    public int experience;
    public Leveling leveling;

    void Start()
    {
        Tilemap tilemap = transform.parent.GetComponent<Tilemap>();
        Transform red = gameObject.transform.Find("Red");

        //Debug.Log(leveling.experience);
        leveling.experience += experience;
        //Debug.Log(leveling.experience);

        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);

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
            Vector3 sphere = new Vector3(surroundingCells[i].x, 0, surroundingCells[i].y);

            if (!Physics.CheckSphere(sphere, 0.1f))
            {
                //Debug.Log("No tile at " + surroundingCells[i]);
                Vector3 pos = tilemap.GetCellCenterWorld(surroundingCells[i]);
                Instantiate(red, pos, Quaternion.Euler(0,30,0), transform); //BUG CAUSES CLONES TO NOT INSTANTIATE IN MILL OR MINE. MUST BE FIXED
            }
        }
    }
}