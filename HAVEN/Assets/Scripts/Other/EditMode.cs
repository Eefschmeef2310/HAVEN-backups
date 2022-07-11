using UnityEngine;

public class EditMode : MonoBehaviour
{
    public Transform tilemap;
    public bool editing = false;
    public TileEditor tileEditor;

    public void toggle()
    {
        if(editing == false)
        {
            enterEdit();
            tileEditor.gameObject.SetActive(true);
        }
        else
        {
            exitEdit();
            tileEditor.gameObject.SetActive(false);
        }
    }

    void enterEdit()
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

            if(child.name == "Red(Clone)")
            {
                child.gameObject.SetActive(true); //Turn on all surrounding tiles
            }
        }
    }

    void exitEdit()
    {
        editing = false;

        foreach (Transform child in tilemap)
        {
            if(child.gameObject.layer == 6 || child.gameObject.layer == 7)
            {
                    if(child.tag == "Boundary")
                    {
                        child.gameObject.SetActive(false); //Set base Red to inactive
                    }
                
            }
            else if(child.name == "Red(Clone)")
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
