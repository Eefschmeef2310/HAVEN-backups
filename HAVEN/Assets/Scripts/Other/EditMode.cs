using UnityEngine;
using UnityEngine.UI;

public class EditMode : MonoBehaviour
{
    public Transform tilemap;
    public bool editing = false;
    public TileEditor tileEditor;
    public Image buildings;

    public void toggle()
    {
        if(editing == false)
        {
            enterEdit();
            tileEditor.gameObject.SetActive(true);
            buildings.gameObject.SetActive(true);
        }
        else
        {
            exitEdit();
            tileEditor.gameObject.SetActive(false);
            buildings.gameObject.SetActive(false);
        }
    }

    public void enterEdit()
    {
        editing = true;

        foreach (Transform child in tilemap)
        {
            if(child.gameObject.layer == 6 || child.gameObject.layer == 7)
            {
                foreach (Transform grandChild in child)
                {
                    if(grandChild.tag == "Boundary")
                    {
                        grandChild.gameObject.SetActive(true); //Set base Red to Active
                    }
                }
            }
        }
    }

    public void exitEdit()
    {
        editing = false;

        foreach (Transform child in tilemap)
        {
            if(child.gameObject.layer == 6 || child.gameObject.layer == 7)
            {
                foreach (Transform grandChild in child)
                {
                    if(grandChild.tag == "Boundary")
                    {
                        grandChild.gameObject.SetActive(false); //Set base Red to Active
                    }
                }                
            }
        }
    }
}
