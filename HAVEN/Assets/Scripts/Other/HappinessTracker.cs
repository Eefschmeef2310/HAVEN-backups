using UnityEngine;

public class HappinessTracker : MonoBehaviour
{
    public bool happy;

    void Start() //Should probably be changed to a called void later (this doesn't really need to be checked every frame)
    {
        //Debug.Log("test");
        if(happy)
        {
            Happiness.happyList.Clear(); //Possibly may be a placeholder
            Happiness.happyList.Add(this.gameObject);
        }
        else{
            NotHappy();
        }
    }

    public void IsHappy()
    {
        happy = true;
        Happiness.happyList.Add(this.gameObject);
        //Debug.Log(Happiness.happyList.Count);
    }

    public void NotHappy()
    {
        happy = false;
        Happiness.happyList.Remove(this.gameObject);
    }
}