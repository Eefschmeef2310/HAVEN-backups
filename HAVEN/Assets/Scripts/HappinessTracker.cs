using UnityEngine;

public class HappinessTracker : MonoBehaviour
{
    public bool happy;

    void Start() //Should probably be changed to a called void later (this doesn't really need to be checked every frame)
    {
        //Debug.Log("test");
        if(happy)
        {
            Happiness.happyCount++;
        }
    }

    public void IsHappy()
    {
        happy = true;
        Happiness.happyCount++;
    }
}