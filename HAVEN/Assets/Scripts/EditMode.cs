using UnityEngine;
using UnityEngine.Tilemaps;

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
            if(child.tag == "Tile")
            {
                foreach (Transform grandChild in child)
                {
                    grandChild.gameObject.SetActive(true); //Set base Red to Active
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
            if(child.tag == "Tile")
            {
                foreach (Transform grandChild in child)
                {
                    if(grandChild.name == "Red")
                    {
                        grandChild.gameObject.SetActive(false); //Set base Red to inactive
                    }
                }
            }

            if(child.name == "Red(Clone)")
            {
                child.gameObject.SetActive(false); //Turn off all surrounding tiles
            }
        }
    }
}
