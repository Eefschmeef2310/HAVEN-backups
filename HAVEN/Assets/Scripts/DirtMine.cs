using UnityEngine;

public class DirtMine : MonoBehaviour
{
    public float inputtedDelay; //time before another dirt is added (in seconds)
    protected float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float incrementDelay = inputtedDelay/Happiness.happiness;
        Debug.Log(incrementDelay);

        if(timer >= incrementDelay)
        {
            timer = 0;
            
            Resources.resources["Dirt"]++;
        }
    }
}
