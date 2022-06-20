using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHover : MonoBehaviour
{
    public EditMode editMode;
    //Dictionary<GameObject, Material> materials = new Dictionary<GameObject, Material>();
    List<Material> materials = new List<Material>();
    List<GameObject> children = new List<GameObject>();

    void OnMouseOver()
    {
        if(!editMode.editing)
        {
            foreach(Transform child in transform.parent)
            {

                materials.Add(child.gameObject.GetComponent<Renderer>().sharedMaterial);
                //Debug.Log(child.gameObject.GetComponent<Renderer>().material);
                children.Add(child.gameObject);
                child.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            } 
        }
         
    }

    void OnMouseExit()
    {
        if(!editMode.editing)
        {
            foreach(Transform child in transform.parent)
            {
                child.gameObject.GetComponent<Renderer>().material = materials[children.IndexOf(child.gameObject)];
                //materials[children.IndexOf(child.gameObject)];
            }
        }   
    }
}
