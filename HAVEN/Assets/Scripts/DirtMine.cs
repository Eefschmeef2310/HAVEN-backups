using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtMine : MonoBehaviour
{
    public Resources resourceManager;
    public int incrementDelay; //time before another dirt is added (in seconds)
    protected float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= incrementDelay)
        {
            timer = 0;
            resourceManager.resources["Dirt"]++;
        }
    }
}
