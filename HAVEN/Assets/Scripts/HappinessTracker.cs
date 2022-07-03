using UnityEngine;

public class HappinessTracker : MonoBehaviour
{
    public bool happy;
    bool testHappiness = true;
    // Update is called once per frame
    void Update() //Should probably be changed to a called void later (this doesn't really need to be checked every frame)
    {
        //Debug.Log(happy);
        if(happy && testHappiness)
        {
            testHappiness = false;
            Happiness.happyCount++;
        }
    }
}
