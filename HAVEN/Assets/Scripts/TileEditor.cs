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
    public int tileCount;
    public AnimationCurve dirtNeeded;
    public Resources resourceManager;

    public float maxPosX = 1;
    public float minPosX = 0;
    public float maxPosY = 1;
    public float minPosY = 0;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {         
            if(hit.collider.gameObject.name == "Red(Clone)")
            {  
                hover.transform.position = hit.collider.gameObject.transform.position;
                hover.transform.rotation = Quaternion.Euler(0, 30, 0);
                
                if(Input.GetMouseButtonDown(0) && hit.collider.gameObject.layer != 7 && resourceManager.resources["Dirt"] >= dirtNeeded.Evaluate(tileCount))
                {
                    Destroy(hit.collider.gameObject);

                    Vector3Int cell = tilemap.WorldToCell(hit.point);
                    Vector3 pos = tilemap.GetCellCenterWorld(cell);
                    dirt.gameObject.SetActive(true);
                    Instantiate(dirt, pos, Quaternion.identity, transform.parent);
                    dirt.gameObject.SetActive(false);

                    Debug.Log(dirtNeeded.Evaluate(tileCount));

                    resourceManager.dirtAmount -= ((int)dirtNeeded.Evaluate(tileCount));
                    
                    //Debug.Log("Cell placed at " + cell.y);
                    tileCount++;
                    tileAmount.text = tileCount.ToString();

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
                    Vector3Int cell = tilemap.WorldToCell(hit.point);
                    Vector3 pos = tilemap.GetCellCenterWorld(cell);
                    Destroy(hit.collider.gameObject);
                    Instantiate(building, pos, Quaternion.identity, transform.parent);
                }
            }  
        }
    }
}
