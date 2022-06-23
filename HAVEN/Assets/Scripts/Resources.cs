using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    public Dictionary<string, int> resources = new Dictionary<string, int>();
    public TextMeshProUGUI test;
    [SerializeField] private Leveling playerLevel;

    // Start is called before the first frame update
    void Start()
    {
        resources.Add("Dirt", 0);
    }

    // Update is called once per frame
    void Update()
    { 
        //Debug.Log(resources.ToString());
        //resources["Dirt"]++;
        //test.text = resources["Dirt"].ToString();
    }
}
