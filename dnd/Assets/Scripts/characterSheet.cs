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
public class characterSheet : MonoBehaviour
{
    public Character[] characters = new Character[5];
    private Character character;
    public TextMeshProUGUI Name;
    public InputField[] lvlrace = new InputField[2];
    public InputField[] HPAC = new InputField[4];
    public InputField[] Misc = new InputField[3];
    public InputField[] Skills = new InputField[18];
    public Toggle[] SProf = new Toggle[18];
    public InputField[] Stats = new InputField[6];
    public Toggle[] StatProf = new Toggle[6];
    private float timer = 0f;
    public TMP_Text[] Mods = new TMP_Text[6];
    public TMP_Text[] ST = new TMP_Text[6];
    public TMP_Text[] SkillMod = new TMP_Text[18];
    public TMP_Text PassiveP;
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
        character=characters[PlayerPrefs.GetInt("CharacterIndex")];
        //set up first box
        Name.text = character.Name;
        lvlrace[0].text = character.level;
        lvlrace[1].text = character.race;

        HPAC[0].text = character.hp[0].ToString();
        HPAC[1].text = character.hp[1].ToString();
        HPAC[2].text = character.ac.ToString();
        HPAC[3].text = character.initiative.ToString();

        Misc[0].text = character.passive.ToString();
        Misc[1].text= character.proficiency.ToString();
        Misc[2].text = character.inventory;

        for(int i = 0; i< 18; i++){
            Skills[i].text = character.skills[i].value.ToString();
            if(character.skills[i].prof == true){
                SProf[i].isOn = true;
            }else{
                SProf[i].isOn = false;
            }
        }

        for(int i = 0; i<6; i++){
            Debug.Log(i);
            Stats[i].text = character.stats[i].value.ToString();
            if(character.stats[i].prof == true){
                StatProf[i].isOn = true;
            }else{
                StatProf[i].isOn = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer=Time.deltaTime;
        character.level = lvlrace[0].text;
        character.race = lvlrace[1].text;
        character.initiative = int.Parse(HPAC[3].text);
        character.hp[0] = int.Parse(HPAC[0].text);
        character.hp[1] = int.Parse(HPAC[1].text);
        character.ac = int.Parse(HPAC[2].text);
        character.proficiency = int.Parse(Misc[1].text);
        character.passive = int.Parse(Misc[0].text);
        character.inventory = Misc[2].text;
        for(int i = 0; i<18; i++){
            character.skills[i].value = int.Parse(Skills[i].text);
            if(SProf[i].isOn){
                character.skills[i].prof = true;
            }else{
                character.skills[i].prof = false;

            }
        }
        for(int i = 0; i<6; i++){
            character.stats[i].value = int.Parse(Stats[i].text);
            if(StatProf[i].isOn){
                character.stats[i].prof = true;
            }else{
                character.stats[i].prof = false;

            }
        }
        PP();
        if(timer >= 30f){
            timer = 0f;
        }
    }

    public void PP()
    {
        int Passive = ChangeSkills();
        Passive += 10;
        Passive += character.passive;
        PassiveP.text = Passive.ToString();
    }
    public int ChangeSkills()
    {
        int[] skills=ChangeStats();
        int[] value = {2,5,3,4,0,3,5,1,3,5,3,5,0,0,3,2,2,5};      //CHA=0, CON=1, DEX=2, INT=3, STR=4, WIS=5
        for(int i = 0; i<18; i++){
            value[i] = skills[value[i]] + character.skills[i].value;
            if(SProf[i].isOn){
                value[i] += character.proficiency;
            }
            SkillMod[i].text = value[i].ToString();
        }
        return(value[11]);
    }
    public int[] ChangeStats()
    {
        int[] value = new int[6];
        for(int i = 0; i<6; i++){
            if((character.stats[i].value % 2) == 1){
                value[i] = (character.stats[i].value - 11)/2;            
            }
            else{
                value[i] = (character.stats[i].value - 10)/2;
            }
            Mods[i].text = value[i].ToString();
            if(StatProf[i].isOn){
                ST[i].text = (value[i]+character.proficiency).ToString();
            }else{
                ST[i].text = value[i].ToString();
            }
        }
        return value;
    }
    public void SaveScriptableObjects(Action onSavedCallback)  // Callback for scene loading
    {
        string saveDirectory = Application.persistentDataPath + "/CharacterSaves";

        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }

        int characterIndex = 0;
        List<Task> saveTasks = new List<Task>(); // List to store save tasks

        foreach (Character character in characters)
        {

            string filePath = Path.Combine(saveDirectory, $"character_{characterIndex}.json");
            string jsonData = JsonUtility.ToJson(character, true);
            Debug.Log(jsonData);
            jsonData = $"{{\"character\": {jsonData}}}";  // Wrap in a single character object

            saveTasks.Add(Task.Run(() =>
            {
                try
                {
                    System.IO.File.WriteAllText(filePath, jsonData);
                    Debug.Log($"Saved character {character.Name} to {filePath}");
                }
                catch (Exception e)
                {
                    Debug.LogError($"Error saving character {character.Name}: {e.Message}");
                }
            }));

            characterIndex++;
        }

        // Wait for all save tasks to complete asynchronously
        Task.WaitAll(saveTasks.ToArray());

        // Call the callback after all saves are complete
        onSavedCallback?.Invoke();
    }

    public void NewScene()
    {
        SaveScriptableObjects(() =>
        {
            SceneManager.LoadScene("Character Selection");
        });

    }
    public Character[] LoadCharacters(){


        string saveDirectory = Application.persistentDataPath + "/CharacterSaves";
        for(int z=0; z<5;z++){
            string filePath = Path.Combine(saveDirectory, $"character_{z}.json");
            characters[z]=pog(filePath,characters[z]);
        }
        return characters;
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

