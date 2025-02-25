using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class setName : MonoBehaviour
{
    public Character[] character = new Character[5];
    public InputField NewName;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        i=PlayerPrefs.GetInt("CharacterIndex");
        
    }

    public void MakeCharacter()
    {
        //change the scene
        character[i].hp[1] = 0;
        character[i].hp[0] = 0;
        character[i].ac = 0;
        character[i].initiative = 0;
        character[i].level = "level 0";
        character[i].race = "orc";
        character[i].inventory = "";
        character[i].proficiency = 2;
        character[i].passive = 0;
        for(int j = 0; j< 18; j++){
            character[i].skills[j].prof = false;
            character[i].skills[j].value = 0;
        }
        for(int j = 0; j< 6; j++){
            character[i].stats[j].prof = false;
            character[i].stats[j].value = 8;
        }
        character[i].Name = NewName.text;
        SceneManager.LoadScene("CharacterSheet");
    }
    public void GoBack()
    {
        SceneManager.LoadScene("Character Selection");

    }
}
