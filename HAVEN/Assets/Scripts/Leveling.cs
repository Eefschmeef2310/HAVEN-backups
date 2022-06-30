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
    public Resources resourceManager;

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
                resourceManager.resources.Add("Seeds", 1);
                resourceManager.resources.Add("Wood", 1);
                break;
            case 10:
                resourceManager.resources.Add("Stone", 0);
                break;
            case 20:
                resourceManager.resources.Add("Steel", 0);
                break;
            case 30:
                resourceManager.resources.Add("Tech", 0);
                break;
            case 40:
                resourceManager.resources.Add("Runes", 0);
                break;
            case 50:
                resourceManager.resources.Add("Havenite", 0);
                break;
            default:
                break;
        }
    }
}
