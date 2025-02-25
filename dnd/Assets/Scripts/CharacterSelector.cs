using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.IO;
using System.Threading.Tasks;
public class CharacterSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public Character[] character = new Character[5];
    public TMP_Text[] Cname = new TMP_Text[5];
    public TMP_Text[] level = new TMP_Text[5];
     public CumList cums = new CumList();
    public Character tmp;

    [System.Serializable]
    public class Cum
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
    }

    [System.Serializable]
    public class CumList
    {
        public Cum character;
    }
   void Start()
    {
        //character[0] = LoadSave();
        character=LoadCharacters();
        for(int i = 0; i<5; i++){
            if(character[i].Name == null || character[i].Name == ""){
                Cname[i].text = "New Chararcter";
            }else{
                Cname[i].text = character[i].Name;
            }
            if(character[i].level == null || character[i].level == ""){
                level[i].text = "Level 0";
            }else{
                level[i].text = character[i].level;

            }

        }
    // Load character data from a JSON file
    string saveDirectory = Application.persistentDataPath + "/CharacterSaves";
    string filePath = Path.Combine(saveDirectory, $"character_{0}.json");

    }

    public void ToCharacterSheet(int i){
        if(character[i].Name == null || character[i].Name == ""){
            MakeSheet(i);
        }else{
            PlayerPrefs.SetInt("CharacterIndex", i);
            SceneManager.LoadScene("CharacterSheet");

        }
    }
    public void MakeSheet(int i){
        
        PlayerPrefs.SetInt("CharacterIndex", i);
        SceneManager.LoadScene("NewCharacter");

    }
    public Character[] LoadCharacters(){


        string saveDirectory = Application.persistentDataPath + "/CharacterSaves";
        for(int z=0; z<5;z++){
            string filePath = Path.Combine(saveDirectory, $"character_{z}.json");
            character[z]=pog(filePath,character[z]);
        }
        return character;
    }
    public Character pog(string filePath, Character tmp){
        string jsonData = File.ReadAllText(filePath);
        cums = JsonUtility.FromJson<CumList>(jsonData);
        Debug.Log(cums.character.Name);
        tmp.Name = cums.character.Name;
        tmp.hp[0]=cums.character.hp[0];
        tmp.hp[1]=cums.character.hp[1];
        tmp.ac=cums.character.ac;
        tmp.initiative=cums.character.initiative;
        tmp.level=cums.character.level;
        tmp.race=cums.character.race;
        tmp.inventory=cums.character.inventory;
        tmp.proficiency=cums.character.proficiency;
        tmp.passive=cums.character.passive;
        for(int z=0; z<16;z++){
            tmp.skills[z].prof=cums.character.skills[z].prof;
            tmp.skills[z].value=cums.character.skills[z].value;
        }
        for(int z=0; z<6;z++){
            tmp.stats[z].prof=cums.character.stats[z].prof;
            tmp.stats[z].value=cums.character.stats[z].value;
        }
        return tmp;
    }
}
