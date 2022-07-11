using System.Collections.Generic;
using UnityEngine;
using UnityFx.Outline;

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
            transform.parent.GetComponentInParent<OutlineBehaviour>().enabled = true;
            /*
            foreach(Transform child in transform)
            {

                materials.Add(child.gameObject.GetComponent<Renderer>().sharedMaterial);
                //Debug.Log(child.gameObject.GetComponent<Renderer>().material);
                children.Add(child.gameObject);
                child.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                
            } 
            */
        }
         
    }

    void OnMouseExit()
    {
        if(!editMode.editing)
        {
            transform.parent.GetComponentInParent<OutlineBehaviour>().enabled=false;
            /*
            foreach(Transform child in transform)
            {
                child.gameObject.GetComponent<Renderer>().material = materials[children.IndexOf(child.gameObject)];
                //materials[children.IndexOf(child.gameObject)];
            }
            */
        }   
    }
}
