using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Armaments : MonoBehaviour
{
    public static Dictionary<string, int> armaments = new Dictionary<string, int>();
    //public TextMeshProUGUI test;

    // Start is called before the first frame update
    void Start()
    {
        //resources["Dirt"] = dirtAmount;
        
        if(armaments.Count == 0)
        {
            armaments.Add("Sword", 1);
        }
        
    }
}