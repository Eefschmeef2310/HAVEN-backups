using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public Leveling levelManager;
    public int level;
    public float experience;

    public Dictionary<string, int> resources;
    public Dictionary<string, int> armaments;

    public GameObject tilemap;

    public PlayerData()
    {
        level = levelManager.level;
        experience = levelManager.experience;

        resources = Resources.resources;
        armaments = Armaments.armaments;
    }
}
