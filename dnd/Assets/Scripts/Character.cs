using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class stats
{
    public bool prof;
    public int value;

    public stats(bool prof, int value)
    {
        this.prof = prof;
        this.value = value;
    }
}
[System.Serializable]
public class skills
{
    public bool prof;
    public int value;

    public skills(bool prof, int value)
    {
        this.prof = prof;
        this.value = value;
    }
}

[CreateAssetMenu(fileName = "New Character", menuName = "Characters")]
[System.Serializable]
public class Character : ScriptableObject
{
    public string Name;
    public int[] hp = new int[2];
    public int ac;
    public int initiative;
    public string level;
    public string race;
    public string inventory;
    public int proficiency;
    public int passive;
    public skills[] skills = new skills[18];
    public stats[] stats = new stats[6];
    public Character()
    {
        Name = "";
        hp = new int[] { 0, 0 };
        ac = 0;
        initiative = 0;
        level = "level 0";
        race = "";
        inventory = "";
        proficiency = 2;
        passive = 0;
        skills = new skills[18]; // Assuming 18 skills based on your JSON structure
        stats = new stats[6];    // Assuming 6 stats based on your JSON structure

        // Initialize skills with default values
        for (int i = 0; i < skills.Length; i++)
        {
            skills[i] = new skills(false, 0);
        }

        // Initialize stats with default values
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = new stats(false, 8);
        }
    }
}
