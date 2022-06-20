using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Leveling : MonoBehaviour
{
    float experience;
    int level;
    float experienceNeeded;
    public Slider slider;
    public TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Start()
    {
        experience = 0;
        level = 1;
        experienceNeeded = 100;
    }

    // Update is called once per frame
    void Update()
    {
        experience++;
        slider.value = experience/experienceNeeded;
        if(experience >= experienceNeeded)
        {
            level++;
            levelText.text = level.ToString();
            experience = 0;
            experienceNeeded++;
        }
    }
}
