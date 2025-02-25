using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{

    public Spell spell;
    public TMP_Text title;
    public TMP_Text level;
    public TMP_Text Class;



    // Update is called once per frame
    void Update()
    {
        title.text = spell.Name;
        level.text = spell.Level;
        if(spell.Classes.Length <= 2){
            Class.fontSize = 20;
        }else if(spell.Classes.Length == 3){
            Class.fontSize = 15;
        }
        
        Class.text = string.Join("\n", spell.Classes);
    }

    public void NewScene()
    {
        PlayerPrefs.SetString("Spell", spell.Name);
        SceneManager.LoadScene("Spell");


    }
}
