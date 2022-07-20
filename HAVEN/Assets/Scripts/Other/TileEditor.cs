using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class TileEditor : MonoBehaviour
{
    public Tilemap tilemap;
    public Transform dirt;
    public Transform building;
    [SerializeField] private GameObject hover;
    public TextMeshProUGUI tileAmount;
    public int tileCount = 1;
    public AnimationCurve dirtNeeded;
    public TextMeshProUGUI dirtNeededText;
    public Happiness happiness;
    GameObject movingCell = null;
    public bool isMoving;

    public float maxPosX = 1;
    public float minPosX = 0;
    public float maxPosY = 1;
    public float minPosY = 0;

    void Start()
    {
        hover.SetActive(true);
        hover.transform.rotation = Quaternion.Euler(0, 30, 0);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        dirtNeededText.text = "Dirt Needed: " + (int)dirtNeeded.Evaluate(tileCount);
        
        tileAmount.text = tileCount.ToString();

        if (Physics.Raycast(ray, out hit))
        {         
            if(hit.collider.gameObject.tag == "Boundary")
            {  
                if(isMoving)
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        isMoving = false;
                        Vector3 tempPos = movingCell.transform.position;

                        //Deactivates and destroys all boundary clones
                        foreach(Transform child in movingCell.transform)
                        {
                            if(child.name == "Red(Clone)" && child != hit.transform) //May have to change name later
                            {
                                child.gameObject.SetActive(false);
                                Destroy(child.gameObject);
                            }
                        }

                        //If the boundary is not a child of the moving tile, set it as the child of the first surrounding tile
                        if(hit.transform.parent != movingCell.transform)
                        {
                            foreach(Vector3Int cell in movingCell.GetComponent<TileInitialise>().surroundingCells)
                            {
                                Vector3 sphere = new Vector3(cell.x, 0, cell.y*0.75f);
                    
                                if(Physics.CheckSphere(sphere, 0.1f)) //nothing there
                                {
                                    Vector3 pos = tilemap.GetCellCenterWorld(cell);

                                    if(Physics.OverlapSphere(pos,0.1f)[0].tag != "Boundary")
                                    {
                                        hit.collider.transform.SetParent(Physics.OverlapSphere(pos,0.1f)[0].transform.parent.parent.parent);
                                        break;
                                    }
                                }
                            }

                            Debug.Log("Valid Swap");

                            movingCell.transform.position = hit.transform.position;
                            hit.transform.position = tempPos;

                            movingCell.GetComponent<TileInitialise>().InitialiseTile();
                        }
                        else
                        {
                            Debug.Log("Invalid Swap");
                            movingCell.GetComponent<TileInitialise>().InitialiseTile();
                            isMoving = true;
                        }
                    }
                }
                else
                {
                    hover.transform.position = hit.collider.gameObject.transform.position;
                
                    if(Input.GetMouseButtonDown(0) && Resources.resources["Dirt"] >= dirtNeeded.Evaluate(tileCount))
                    {
                        Destroy(hit.collider.gameObject); //Destroys the Boundary tile

                        Vector3Int cell = tilemap.WorldToCell(hit.point);
                        Vector3 pos = tilemap.GetCellCenterWorld(cell);

                        dirt.gameObject.SetActive(true);
                        Instantiate(dirt, pos, Quaternion.identity, transform.parent);
                        dirt.gameObject.SetActive(false);

                        Resources.resources["Dirt"] -= ((int)dirtNeeded.Evaluate(tileCount));
                        
                        //Debug.Log("Cell placed at " + cell.y);

                        if(cell.x >= 0 && cell.x > maxPosX)
                        {
                            maxPosX = cell.x;
                        }

                        if(cell.x < 0 && cell.x < minPosX)
                        {
                            minPosX = cell.x;
                        }

                        if(cell.y >= 0 && cell.y > maxPosY)
                        {
                            maxPosY = cell.y;
                        }

                        if(cell.y < 0 && cell.y < minPosY)
                        {
                            minPosY = cell.y;
                        }
                    }
                } 
            }   
            else if(hit.collider.gameObject.layer == 7)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    hit.transform.parent.parent.parent.gameObject.SetActive(false);
                    Destroy(hit.transform.parent.parent.parent.gameObject);

                    Vector3 pos = hit.collider.gameObject.transform.position;

                    building.gameObject.SetActive(true);

                    if(building.gameObject.name == "DirtMine" && Resources.resources["Supply Kit"] == 1)
                    {
                        Resources.resources["Supply Kit"]--;
                        Instantiate(building, pos, Quaternion.identity, transform.parent);
                        tileCount++;
                    }
                    else if(building.gameObject.name == "LumberMill" && Resources.resources["Seeds"] >= 1 && Resources.resources["Wood"] >= 1)
                    {
                        Resources.resources["Seeds"]--;
                        Resources.resources["Wood"]--;
                        Instantiate(building, pos, Quaternion.identity, transform.parent);
                        tileCount++;
                    }
                    else if(building.gameObject.name == "WoodBridge")
                    {
                        Instantiate(building, pos, Quaternion.identity, transform.parent);
                    }
                    else
                    {
                        //Debug.Log(hit.transform.parent.parent.parent.gameObject);
                        Instantiate(building, pos, Quaternion.identity, transform.parent);
                        if(building.gameObject.tag == "Tile")
                        {
                            tileCount++;
                        }
                    }
                    building.gameObject.SetActive(false);
                }
            }  
            else if(hit.collider.gameObject.layer == 6)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    if(!isMoving)
                    {
                        isMoving = true;
                        movingCell = hit.transform.parent.parent.parent.gameObject;
                    }
                    else
                    {
                        isMoving = false;
                        GameObject hitCell = hit.transform.parent.parent.parent.gameObject;
                        Vector3 tempPos = movingCell.transform.position;

                        foreach(Transform child in movingCell.transform)
                        {
                            if(child.name == "Red(Clone)") //May have to change name later
                            {
                                child.gameObject.SetActive(false);
                                Destroy(child.gameObject);
                            }
                        }

                        foreach(Transform child in hitCell.transform)
                        {
                            if(child.name == "Red(Clone)") //May have to change name later
                            {
                                child.gameObject.SetActive(false);
                                Destroy(child.gameObject);
                            }
                        }
                        
                        movingCell.transform.position = hitCell.transform.position;
                        hitCell.transform.position = tempPos;

                        movingCell.GetComponent<TileInitialise>().InitialiseTile();
                        hitCell.GetComponent<TileInitialise>().InitialiseTile();

                        movingCell = null;
                    }
                }  
            }
        }
    }
}