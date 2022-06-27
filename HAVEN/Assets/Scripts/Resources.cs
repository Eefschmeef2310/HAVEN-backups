using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    public Dictionary<string, int> resources = new Dictionary<string, int>();
    public TextMeshProUGUI test;
    [SerializeField] private Leveling playerLevel;
    public int dirtAmount;

    // Start is called before the first frame update
    void Start()
    {
        resources.Add("Dirt", dirtAmount);
        resources.Add("Supply Kit", 1);
    }

    // Update is called once per frame
    void Update()
    { 
        //Debug.Log(resources["Dirt"]);
        //resources["Dirt"]++;
        //resources["Dirt"] = dirtAmount;
        test.text = "Dirt: " + resources["Dirt"];
    }
}
