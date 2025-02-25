using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RulesDisplay : MonoBehaviour
{

    public string ruleName;
    public Rule[] rules; 
    int index;
    public Text title;
    public Text description;

    void Start()
    {
        ruleName = PlayerPrefs.GetString("RuleName");
        LoadRules();
        int i = 0;
        foreach(Rule rule in rules){
            if (rule.title == ruleName){
                index = i;
            }
            i++;
        }
    }

    private void LoadRules()
    {
        string folderPath = Application.dataPath + "/Spells";
        Debug.Log("Folder path: " + folderPath); 

        rules = Resources.LoadAll<Rule>("rules");


        Debug.Log("Number of Rule objects loaded: " + rules.Length);

        foreach (Rule rule in rules)
        {
            Debug.Log("Rule object loaded: " + rule.name);
        }
    }
    void Update()
    {
        title.text = rules[index].title;
        description.text = rules[index].description;
    }
}
