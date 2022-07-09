using UnityEngine;

public class LumberMill : MonoBehaviour
{
    public float incrementDelay; //time before another dirt is added (in seconds)
    protected float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        incrementDelay = incrementDelay*Happiness.happiness;

        if(timer >= incrementDelay)
        {
            timer = 0;
            Resources.resources["Wood"]++;
        }
    }
}
