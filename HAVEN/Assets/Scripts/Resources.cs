using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    public static Dictionary<string, int> resources = new Dictionary<string, int>();
    //public TextMeshProUGUI test;
    public int dirtAmount;

    // Start is called before the first frame update
    void Start()
    {
        //resources["Dirt"] = dirtAmount;
        
        if(resources.Count == 0)
        {
            resources.Add("Dirt", dirtAmount);
            resources.Add("Supply Kit", 1);
        }
        
    }

    // Update is called once per frame
    void Update()
    { 
        //Debug.Log(resources["Supply Kit"]);
        //resources["Dirt"]++;
        //Debug.Log(resources["Dirt"]);
        //test.text = "Dirt: " + resources["Dirt"];
    }
}
