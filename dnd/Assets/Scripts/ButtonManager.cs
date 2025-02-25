using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq; // Add this using directive

public class ButtonManager : MonoBehaviour
{
    public Rule[] rules; 
    public ButtonScript[] buttonScripts = new ButtonScript[10];
    void Start()
    {
        LoadRules();
        ChangeButtons();
    }

    public void Search(){
        ChangeButtons();
    }
    /// <summary>
    /// AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH KILL MEEEEEEEE
    /// </summary>
    private void LoadRules()
    {

        rules = Resources.LoadAll<Rule>("rules");


        Debug.Log("Number of Rule objects loaded: " + rules.Length);

        foreach (Rule rule in rules)
        {
            Debug.Log("Rule object loaded: " + rule.name);
        }
    }

    private void ChangeButtons()
    {
        int[] topIndices = GetTop10Indices(rules);
        int i = 0;
        foreach (ButtonScript buttonScript in buttonScripts)
        {
            // Ensure we don't exceed the bounds of the rules array
            if (i < rules.Length)
            {
                buttonScript.rule = rules[topIndices[i]];
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
        int[] GetTop10Indices(Rule[] rules)
        {
            // If rules is null or empty, return an empty array
            if (rules == null || rules.Length == 0)
                return new int[0];

            // Get indices of top 10 scores
            var topIndices = Enumerable.Range(0, rules.Length)
                                        .OrderByDescending(i => rules[i].score)
                                        .Take(10)
                                        .ToArray();

            return topIndices;
        }
}
