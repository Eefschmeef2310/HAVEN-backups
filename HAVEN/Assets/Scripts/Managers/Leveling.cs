using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Leveling : MonoBehaviour
{
    public float experience;
    public int level;
    public float experienceNeeded;
    public Slider slider;
    public TextMeshProUGUI levelText;

    // Update is called once per frame
    void Update()
    {
        //experience++;
        slider.value = experience/experienceNeeded;
        if(experience >= experienceNeeded)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        //Update level and reset experience to 0
        level++;
        levelText.text = level.ToString();
        experience -= experienceNeeded;
        experienceNeeded++;

        //check unlocked item
        switch(level)
        {
            case 2:
                //Resources.resources.Add("Seeds", 1);
                //Resources.resources.Add("Wood", 1);
                break;
            case 10:
                Resources.resources.Add("Stone", 0);
                break;
            case 20:
                Resources.resources.Add("Steel", 0);
                break;
            case 30:
                Resources.resources.Add("Tech", 0);
                break;
            case 40:
                Resources.resources.Add("Runes", 0);
                break;
            case 50:
                Resources.resources.Add("Havenite", 0);
                break;
            default:
                break;
        }
    }
}
