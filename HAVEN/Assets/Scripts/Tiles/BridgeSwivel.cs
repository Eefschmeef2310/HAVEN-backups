using UnityEngine;
using UnityEngine.Tilemaps;

public class BridgeSwivel : MonoBehaviour
{
    //This program needs to get surrounding cells, check which is the FIRST that has a tile, then swivel the bridge that way. (23/7/22 completion)
    public void SwivelBridge()
    {
        Tilemap tilemap = transform.parent.GetComponent<Tilemap>();
        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);
        Transform red = gameObject.transform.Find("Red");
        
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
                            transform.rotation = Quaternion.Euler(0, 60*(i+1), 0); //Rotate the object

                            /*//Create Red(Clones)
                            Vector3 inPos = tilemap.GetCellCenterWorld(surroundingCells[5]);
                            if(!Physics.CheckSphere(inPos, 0.1f))
                            {
                                Instantiate(red, inPos, Quaternion.Euler(0,30,0), transform);
                            }

                            inPos = tilemap.GetCellCenterWorld(surroundingCells[2]);
                            if(!Physics.CheckSphere(inPos, 0.1f))
                            {
                                Instantiate(red, inPos, Quaternion.Euler(0,30,0), transform);
                            }
                            */

                            break;
                        }
                        else if (i == 3 || i == 0)
                        {
                            //Debug.Log("i is 3 or 0");
                            swiveledToTile = true;
                            transform.rotation = Quaternion.Euler(0, 60*(i-1), 0);

                            /*//Create Red(Clones)
                            Vector3 inPos = tilemap.GetCellCenterWorld(surroundingCells[3]);
                            if(!Physics.CheckSphere(inPos, 0.1f))
                            {
                                Instantiate(red, inPos, Quaternion.Euler(0,30,0), transform);
                            }

                            inPos = tilemap.GetCellCenterWorld(surroundingCells[0]);
                            if(!Physics.CheckSphere(inPos, 0.1f))
                            {
                                Instantiate(red, inPos, Quaternion.Euler(0,30,0), transform);
                            }
                            */

                            break;
                        }
                        else
                        {
                            //Debug.Log("i is 1 or 4");
                            swiveledToTile = true;
                            transform.rotation = Quaternion.Euler(0, 60*(i), 0);

                            /*//Create Red(Clones)
                            Vector3 inPos = tilemap.GetCellCenterWorld(surroundingCells[1]);
                            if(!Physics.CheckSphere(inPos, 0.1f))
                            {
                                Instantiate(red, inPos, Quaternion.Euler(0,30,0), transform);
                            }

                            inPos = tilemap.GetCellCenterWorld(surroundingCells[4]);
                            if(!Physics.CheckSphere(inPos, 0.1f))
                            {
                                Instantiate(red, inPos, Quaternion.Euler(0,30,0), transform);
                            }
                            */

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

                                /*//Create Red(Clones)
                                Vector3 inPos = tilemap.GetCellCenterWorld(surroundingCells[0]);
                                if(!Physics.CheckSphere(inPos, 0.1f))
                                {
                                    Instantiate(red, inPos, Quaternion.Euler(0,30,0), transform);
                                }

                                inPos = tilemap.GetCellCenterWorld(surroundingCells[3]);
                                if(!Physics.CheckSphere(inPos, 0.1f))
                                {
                                    Instantiate(red, inPos, Quaternion.Euler(0,30,0), transform);
                                }
                                */
                                
                                break;
                            }
                            else
                            {
                                if((cellPosition.x > 0 && cellPosition.y > 0) || (cellPosition.x < 0 && cellPosition.y < 0))
                                {
                                    Debug.Log("test2");
                                    swiveledToTile = true;
                                    transform.rotation = Quaternion.Euler(0, 60*(j+1), 0);

                                    /*//Create Red(Clones)
                                    Vector3 inPos = tilemap.GetCellCenterWorld(surroundingCells[5]);
                                    if(!Physics.CheckSphere(inPos, 0.1f))
                                    {
                                        Instantiate(red, inPos, Quaternion.Euler(0,30,0), transform);
                                    }

                                    inPos = tilemap.GetCellCenterWorld(surroundingCells[2]);
                                    if(!Physics.CheckSphere(inPos, 0.1f))
                                    {
                                        Instantiate(red, inPos, Quaternion.Euler(0,30,0), transform);
                                    }
                                    */

                                    break;
                                }
                                else
                                {
                                    Debug.Log("test3");
                                    swiveledToTile = true;
                                    transform.rotation = Quaternion.Euler(0, 60*(j-1), 0);

                                    /*//Create Red(Clones)
                                    Vector3 inPos = tilemap.GetCellCenterWorld(surroundingCells[5]);
                                    if(!Physics.CheckSphere(inPos, 0.1f))
                                    {
                                        Instantiate(red, inPos, Quaternion.Euler(0,30,0), transform);
                                    }

                                    inPos = tilemap.GetCellCenterWorld(surroundingCells[2]);
                                    if(!Physics.CheckSphere(inPos, 0.1f))
                                    {
                                        Instantiate(red, inPos, Quaternion.Euler(0,30,0), transform);
                                    }
                                    */

                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}