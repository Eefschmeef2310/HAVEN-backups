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

        leveling.experience += experience;

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
            Vector3 sphere = new Vector3(surroundingCells[i].x, 0, surroundingCells[i].y*0.75f);

            if (!Physics.CheckSphere(sphere, 0.1f)) //nothing there
            {
                //Debug.Log("No tile at " + surroundingCells[i]);
                Vector3 pos = tilemap.GetCellCenterWorld(surroundingCells[i]);
                Instantiate(red, pos, Quaternion.Euler(0,30,0), transform.parent);
            }
            else //Tile found
            {
                GameObject tester = Physics.OverlapSphere(sphere,0.1f)[0].gameObject;
                //Debug.Log(tester);
                if(tester.gameObject.GetComponentInParent<GenerateHappiness>() != null)
                {
                    tester.gameObject.GetComponentInParent<GenerateHappiness>().UpdateHappiness();
                }      
            }
        }
    }
}