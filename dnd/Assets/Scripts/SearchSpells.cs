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
public class SearchLevels: MonoBehaviour
{
    //This should be the json text
    public Spell[] spells;
    public InputField searchBox;
    //This should be user input
    //This is the score based on where the string is found
    public int score;
    public bool chapterTitle = false;
    public bool sectionTitle = false;
    public bool bodyText = false;
    private string str1;
    private string str2;
    void Start(){
        LoadRules();
        foreach(Spell spell in spells){
            spell.score=0;
        }
    }
    // Start is called before the first frame update
    public void Search()
    {
        //need to get the type of text being searched from unity object stuff, like chapter title or body text
        string str2 = searchBox.text.ToUpper(new CultureInfo("en-US", false));
        foreach (Spell spell in spells)
        {
            spell.score = 0;
        }
        foreach (Spell spell in spells){
            str1 = spell.Name.ToUpper(new CultureInfo("en-US", false));
            bool containsSearchResult = str1.Contains(str2);
            if (containsSearchResult == true){
                spell.score += 10;
            }
            str1 = spell.School.ToUpper(new CultureInfo("en-US", false));
            containsSearchResult = str1.Contains(str2);
            if (containsSearchResult == true){
                spell.score += 3;
            }
            str1 = spell.Description[0].ToUpper(new CultureInfo("en-US", false));
            containsSearchResult = str1.Contains(str2);
            if (containsSearchResult == true){
                spell.score += 6;
            }
            for(int i=0; i<spell.Classes.Length;i++){
                str1 = spell.Classes[i].ToUpper(new CultureInfo("en-US", false));
                containsSearchResult = str1.Contains(str2);
                if (containsSearchResult == true){
                    spell.score += 4;
                }
            }
        }
        //string str1 = stringtobesearched.ToUpper(new CultureInfo("en-US", false));
    }

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
}
