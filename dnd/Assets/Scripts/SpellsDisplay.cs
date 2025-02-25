using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpellsDisplay : MonoBehaviour
{

    public Camera mainCamera;
    public string spellType;
    public Spell[] spells; 
    public int index = -1;
    public Text Name;
    public Text description;
    public Text Level;
    public Text School;
    public Text Classes;

    void Start()
    {
        spellType = PlayerPrefs.GetString("Spell");
        LoadSpells();
        int i = 0;
        foreach(Spell spell in spells){
            if (spell.Name == spellType){
                index = i;
            }
            i++;
        }
        if (index == -1){
            index = 0;
        }
    }

    private void LoadSpells()
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

    //change to Start once everything works
    void Update ()
    {
        Name.text = spells[index].Name;
        description.text = string.Join("\n", spells[index].Description);
        Level.text = spells[index].Level;
        School.text = spells[index].School;
        Classes.text = string.Join(",", spells[index].Classes);
        ChangeColor(spells[index].School);
    }

    void ChangeColor(string Schl)
    {
        Color backgroundc;
        Color textc;
        switch(Schl)
        {
            case "Abjuration":
                backgroundc = new Color(192 / 255.0f, 192 / 255.0f, 192 / 255.0f, 1); //silver
                textc = new Color(0, 0, 0, 1);           //black
                Debug.Log("Ab");
                break;
            case "Conjuration":
                backgroundc = new Color(0, 0, 1, 1); //blue
                textc = new Color(255 / 255.0f, 215 / 255.0f, 0, 1);   //gold
                Debug.Log("Con");

                break;
            case "Divination":
                backgroundc = new Color(255 / 255.0f, 215 / 255.0f, 0, 1); //gold
                textc = new Color(0, 0, 128 / 255.0f, 1);        //navy
                Debug.Log("Div");

                break;
            case "Enchantment":
                backgroundc = new Color(255 / 255.0f, 192 / 255.0f, 203 / 255.0f, 1);  //pink
                textc = new Color(128 / 255.0f, 0, 128 / 255.0f, 1);          //purple
                Debug.Log("Ench");

                break;
            case "Evocation":
                backgroundc = new Color(255 / 255.0f, 192 / 255.0f, 192 / 255.0f, 1);    //orange
                textc = new Color(139 / 255.0f, 0, 0, 1);             //red
                Debug.Log("Ev");

                break;
            case "Illusion":
                backgroundc = new Color(176/255.0f, 196 / 255.0f, 222 / 255.0f, 1);  //lavendar
                textc = new Color(255 / 255.0f, 255 / 255.0f, 0 / 255.0f, 1);     //lightblue
                Debug.Log("Ill");

                break;
            case "Necromancy":
                backgroundc = new Color(48 / 255.0f, 25 / 255.0f, 52 / 255.0f, 1);   //purple
                textc = new Color(1, 1, 1, 1);     //white
                Debug.Log("Necro");

                break;
            case "Transmutation":
                backgroundc = new Color(139 / 255.0f, 69 / 255.0f, 19 / 255.0f, 1);  //earthy
                textc = new Color(0 / 255.0f, 128 / 255.0f, 0 / 255.0f, 1);       //green
                Debug.Log("Trans");

                break;
            default:
                backgroundc = new Color(0, 0, 0, 1);
                textc = new Color(1, 1, 1, 1);
                Debug.Log("Default");

                break;
        }

        mainCamera.backgroundColor = backgroundc;
        Name.color = textc;
        description.color = textc;
        Level.color = textc;
        School.color = textc;
        Classes.color = textc;
    }
}
