using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
public class delay : MonoBehaviour
{
    private float timer = 0f;

    void Start()
    {
        string saveDirectory = Application.persistentDataPath + "/CharacterSaves";
        for(int z=0; z<5;z++){
            string filePath = Path.Combine(saveDirectory, $"character_{z}.json");
            if (!File.Exists(filePath))
            {
                // Create a default character data object
                Character character = ScriptableObject.CreateInstance<Character>();
                character.Name = "";
                character.hp = new int[] { 0, 0 };
                character.ac = 0;
                character.initiative = 0;
                character.level = "level 0";
                character.race = "";
                character.inventory = "";
                character.proficiency = 2;
                character.passive = 0;

                for (int i = 0; i < character.skills.Length; i++)
                {
                    character.skills[i].prof = false;
                    character.skills[i].value = 0;

                }

                for (int i = 0; i < character.stats.Length; i++)
                {
                    character.stats[i].prof = false;
                    character.stats[i].value = 0;
                }
                // Serialize the default character data to JSON
            string jsonData = JsonUtility.ToJson(character, true);
            Debug.Log(jsonData);
            jsonData = $"{{\"character\": {jsonData}}}";  // Wrap in a single character object

                try
                {
                    System.IO.File.WriteAllText(filePath, jsonData);
                    Debug.Log($"Saved character {character.Name} to {filePath}");
                }
                catch (Exception e)
                {
                    Debug.LogError($"Error saving character {character.Name}: {e.Message}");
                }

                Debug.Log("Created default character JSON file: " + filePath);
            }
            else
            {
                Debug.Log("Default character JSON file already exists: " + filePath);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            SceneManager.LoadScene("home");
        }
    }
}
