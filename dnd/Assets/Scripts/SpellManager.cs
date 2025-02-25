using UnityEngine;
using System.Collections.Generic;
using System.IO;
using TMPro;
using System.Linq;
public class SpellManager : MonoBehaviour
{
    public Spell[] spells; 
    public LevelButton[] LevelButtons = new LevelButton[10];
    void Start()
    {
        LoadRules();
        ChangeButtons();
    }


    /// <summary>
    /// AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH KILL MEEEEEEEE
    /// </summary>
    private void LoadRules()
    {
        string folderPath = Application.dataPath + "/Spells";
        Debug.Log("Folder path: " + folderPath); 

        spells = Resources.LoadAll<Spell>("Spells");


        Debug.Log("Number of Rule objects loaded: " + spells.Length);

        foreach (Spell spell in spells)
        {
            Debug.Log("Rule object loaded: " + spell.Name);
        }
    }

    public void ChangeButtons()
    {
        int[] topIndices = GetTop10Indices(spells);

        int i = 0;
        foreach (LevelButton button in LevelButtons)
        {
            // Ensure we don't exceed the bounds of the rules array
            if (i < spells.Length)
            {
                button.spell = spells[topIndices[i]];
            }
            else
            {
                // Handle if there are more buttons than rules
                Debug.LogWarning("More buttons than rules.");
            }
            i++;
        }
    }
            // Define a local function to get the top 10 indices        
        int[] GetTop10Indices(Spell[] spells)
        {
            // If rules is null or empty, return an empty array
            if (spells == null || spells.Length == 0)
                return new int[0];

            // Get indices of top 10 scores
            var topIndices = Enumerable.Range(0, spells.Length)
                                        .OrderByDescending(i => spells[i].score)
                                        .Take(10)
                                        .ToArray();

            return topIndices;
        }
}
