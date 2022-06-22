using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class TileEditor : MonoBehaviour
{
    public Tilemap tilemap;
    public Transform prefab;
    [SerializeField] private GameObject hover;
    public TextMeshProUGUI tileAmount;
    public int tileCount;

    public float maxPosX = 1;
    public float minPosX = 0;
    public float maxPosY = 1;
    public float minPosY = 0;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "Red(Clone)")
        {            
            hover.transform.position = hit.collider.gameObject.transform.position;
            hover.transform.rotation = Quaternion.Euler(0, 30, 0);
            
            if(Input.GetMouseButtonDown(0))
            {
                Destroy(hit.collider.gameObject);

                Vector3Int cell = tilemap.WorldToCell(hit.point);
                Vector3 pos = tilemap.GetCellCenterWorld(cell);
                Instantiate(prefab, pos, Quaternion.identity, transform.parent);
                
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

        /*
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "Red(Clone)")
            {
                Destroy(hit.collider.gameObject);

                Vector3Int cell = tilemap.WorldToCell(hit.point);
                Vector3 pos = tilemap.GetCellCenterWorld(cell);
                Instantiate(prefab, pos, Quaternion.identity, transform.parent);
                
                Debug.Log("Cell placed at " + cell);
            }
        }
        */
    }
}
