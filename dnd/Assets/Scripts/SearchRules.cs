using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class SearchRules : MonoBehaviour
{
    //This should be the json text
    public Rule[] rules;
    public InputField searchBox;
    //This should be user input
    //This is the score based on where the string is found
    public int score;
    public bool chapterTitle = false;
    public bool sectionTitle = false;
    public bool bodyText = false;
    public string str1;
    public string str2;
    void Start(){
        LoadRules();
    }
    // Start is called before the first frame update
    public void Search()
    {
        //need to get the type of text being searched from unity object stuff, like chapter title or body text
        string str2 = searchBox.text.ToUpper(new CultureInfo("en-US", false));
        foreach (Rule rule in rules)
        {
            rule.score = 0;
        }
        foreach (Rule rule in rules){
            str1 = rule.CTitle.ToUpper(new CultureInfo("en-US", false));
            bool containsSearchResult = str1.Contains(str2);
            if (containsSearchResult == true){
                rule.score += 10;
            }
            str1 = rule.title.ToUpper(new CultureInfo("en-US", false));
            containsSearchResult = str1.Contains(str2);
            if (containsSearchResult == true){
                rule.score += 6;
            }
            str1 = rule.description.ToUpper(new CultureInfo("en-US", false));
            containsSearchResult = str1.Contains(str2);
            if (containsSearchResult == true){
                rule.score += 4;
            }
        }
        //string str1 = stringtobesearched.ToUpper(new CultureInfo("en-US", false));
    }
    private void LoadRules()
    {
        rules = Resources.LoadAll<Rule>("rules");
    }
}
