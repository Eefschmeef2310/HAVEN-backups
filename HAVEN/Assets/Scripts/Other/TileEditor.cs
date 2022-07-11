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
            else if (hit.collider.gameObject.layer == 7)
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
                movingCell = hit.transform.parent.parent.parent.gameObject;
            }
        }
    }
}