using UnityEngine;
using UnityEngine.Tilemaps;

public class BridgeSwivel : MonoBehaviour
{
    //This program needs to get surrounding cells, check which is the FIRST that has a tile, then swivel the bridge that way
    public void SwivelBridge()
    {
        Tilemap tilemap = transform.parent.GetComponent<Tilemap>();
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

        bool swiveledToTile = false;

        for (int i = 0; i <= surroundingCells.Length - 1; i++)
        {
            Vector3 pos = tilemap.GetCellCenterWorld(surroundingCells[i]);   

            if (Physics.CheckSphere(pos,0.1f))
            {
                foreach(Collider collider in Physics.OverlapSphere(pos,0.1f))
                {
                    if(collider.tag != "Boundary" && collider.transform.parent.parent.parent.tag == "Tile")
                    {
                        if(i == 2 || i == 5)
                        {
                            //Debug.Log("i is 2 or 5");
                            swiveledToTile = true;
                            transform.rotation = Quaternion.Euler(0, 60*(i+1), 0);
                            break;
                        }
                        else if (i == 3 || i == 0)
                        {
                            //Debug.Log("i is 3 or 0");
                            swiveledToTile = true;
                            transform.rotation = Quaternion.Euler(0, 60*(i-1), 0);
                            break;
                        }
                        else
                        {
                            //Debug.Log("i is 1 or 4");
                            swiveledToTile = true;
                            transform.rotation = Quaternion.Euler(0, 60*(i), 0);
                            break;
                        }
                    }
                }
            }            
        }

        if(!swiveledToTile) //Since there are no tiles, move onto amenities, so a chain of bridges is possible
        {
            //Debug.Log("testing bridges");
            for(int j = 0; j <= surroundingCells.Length - 1; j++)
            {
                Vector3 pos = tilemap.GetCellCenterWorld(surroundingCells[j]);  
                //Debug.Log(sphere);

                if (Physics.CheckSphere(pos,0.1f))
                {
                    //Debug.Log(pos);
                    foreach(Collider collider in Physics.OverlapSphere(pos,0.1f))
                    {
                        //Debug.Log(j);
                        //Debug.Log(collider.name + ", " + collider.tag + ", " + collider.transform.parent.parent.parent.tag);
                        if(collider.tag != "Boundary" && collider.transform.parent.parent.parent.tag == "Amenity")
                        {
                            if(cellPosition.y%2 == 0)
                            {
                                Debug.Log("test");
                                swiveledToTile = true;
                                transform.rotation = Quaternion.Euler(0, 60*(j), 0);
                                break;
                            }
                            else
                            {
                                Debug.Log("test2");
                                swiveledToTile = true;
                                transform.rotation = Quaternion.Euler(0, 60*(j-1), 0);
                                break;
                            }
                            //Debug.Log(collider.name);
                            /*
                            if(j == 2 || j == 5)
                            {
                                //Debug.Log("j is 2 or 5");
                                swiveledToTile = true;
                                transform.rotation = Quaternion.Euler(0, 60*(j), 0);
                                break;
                            }
                            else if (j == 3 || j == 0)
                            {
                                Debug.Log("j is 3 or 0");
                                swiveledToTile = true;
                                transform.rotation = Quaternion.Euler(0, 60*(j), 0);
                                break;
                            }
                            else
                            {
                                //Debug.Log("j is 1 or 4");
                                swiveledToTile = true;
                                transform.rotation = Quaternion.Euler(0, 60*(j), 0);
                                break;
                            }
                            */
                        }
                    }
                }
            }
        }
    }
}