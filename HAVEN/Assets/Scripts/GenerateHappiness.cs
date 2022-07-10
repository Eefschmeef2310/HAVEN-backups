using UnityEngine;

public class GenerateHappiness : MonoBehaviour
{
    public float size;
    public bool moved;

    public void Start()
    {
        moved = false;
        Collider[] cells = Physics.OverlapSphere(transform.position, size);
        UpdateHappiness(cells);
    }

    public void UpdateHappiness(Collider[] cells) //Should probably be a called method later. This works FOR NOW
    {
        if(moved)
        {
            moved = false;
            Collider[] newCells = Physics.OverlapSphere(transform.position, size);
            if(newCells != cells)
            {
                for(int i = 0; i <= cells.Length - 1; i++)
                {
                    if(cells[i].gameObject.transform.parent.name != "Tilemap" && cells[i].gameObject.transform.parent.parent.parent.tag == "Tile")
                    {
                        if(cells[i].gameObject.transform.parent.parent.parent.GetComponent<HappinessTracker>() != null)
                        {
                            cells[i].gameObject.transform.parent.parent.parent.GetComponent<HappinessTracker>().NotHappy();
                        }
                    }
                }
                cells = newCells;
            }
        }

        for(int i = 0; i <= cells.Length - 1; i++)
        {
            //Debug.Log(cells[i].gameObject);
            if(cells[i].gameObject.transform.parent.name != "Tilemap" && cells[i].gameObject.transform.parent.parent.parent.tag == "Tile")
            {
                if(cells[i].gameObject.transform.parent.parent.parent.GetComponent<HappinessTracker>() != null)
                {
                    cells[i].gameObject.transform.parent.parent.parent.GetComponent<HappinessTracker>().IsHappy();
                }
            }
        }
    }
}
