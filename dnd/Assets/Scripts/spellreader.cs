// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;
// using System;
// using UnityEngine.SceneManagement;

// public class spellreader : MonoBehaviour
// {
//     public TextAsset jsonData;
//     public BookList books = new BookList();

//     [System.Serializable]
//     public class Book
//     {
//         public string name;
//         public Info info;
//     }
//     [System.Serializable]
//     public class Info
//     {
//         public string[] Spellclass;
//         public string Spellschool;
//         public string[] Spelldes;
//         public string Spelllevel;
//     }
//     [System.Serializable]
//     public class BookList
//     {
//         public Book[] book;
//     }

//     // Start is called before the first frame update
//     void Start()
//     {
//             books = JsonUtility.FromJson<BookList>(jsonData.text);
//         for (int i = 0; i < books.book.Length; i++)
//         {
//             Spell spell = ScriptableObject.CreateInstance<Spell>();
//             spell.Name = books.book[i].name;
//             spell.Classes = books.book[i].info.Spellclass;
//             spell.School = books.book[i].info.Spellschool;
//             spell.Description = books.book[i].info.Spelldes;
//             spell.Level = books.book[i].info.Spelllevel;
//             spell.score = 0;
//             SaveScriptableObject(spell);
//         }    
        

//     }

   
//     private void SaveScriptableObject(Spell ruleObject)
//     {
//         string folderPath = "Assets/Spells";

//         // Ensure the folder exists, create it if not
//         if (!AssetDatabase.IsValidFolder(folderPath))
//         {
//             AssetDatabase.CreateFolder("Assets", "Spells");
//         }

//         // Use title as the file name (remove invalid characters)
//         string fileName = ruleObject.Name.Replace(" ", "_") + ".asset";
//         fileName = fileName.Replace("/", "_");

//         // Combine the folder path and file name
//         string path = $"{folderPath}/{fileName}";

//         // Create and save the asset
//         AssetDatabase.CreateAsset(ruleObject, path);
//         AssetDatabase.SaveAssets();
//         AssetDatabase.Refresh();
//     }
// }