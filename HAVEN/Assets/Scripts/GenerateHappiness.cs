using UnityEngine;

public class GenerateHappiness : MonoBehaviour
{
    public float size;

    void Start() //Should probably be a called method later. This works FOR NOW
    {
        Collider[] cells = Physics.OverlapSphere(transform.position, size);

        for(int i = 0; i <= cells.Length - 1; i++)
        {
            Debug.Log(cells[i].gameObject);
            if(cells[i].gameObject.transform.parent.name != "Tilemap" && cells[i].gameObject.transform.parent.parent.parent.tag == "Tile")
            {
                if(cells[i].gameObject.transform.parent.parent.parent.GetComponent<HappinessTracker>() != null)
                {
                    cells[i].gameObject.transform.parent.parent.parent.GetComponent<HappinessTracker>().happy = true;
                }
            }
        }
    }
}
