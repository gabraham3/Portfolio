// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;
// using System;
// using System.Globalization;
// using UnityEngine.SceneManagement;
// using JetBrains.Annotations;
// using Unity.VisualScripting;
// using UnityEngine.UIElements;
// using UnityEngine.UI;
// using TMPro;
// using System.IO;

// public class JsonReader : MonoBehaviour
// {
//     public TextAsset jsonData;
//     public BookList books = new BookList();
//     public string scene;

//     [System.Serializable]
//     public class Book
//     {
//         public string Chapter;
//         public string CTitle;
//         public string Section;
//         public string STitle;
//         public string Text;
//     }

//     [System.Serializable]
//     public class BookList
//     {
//         public Book[] book;
//     }

//     // Start is called before the first frame update
//     void Start()
//     {
//         books = JsonUtility.FromJson<BookList>(jsonData.text);
//         for (int i = 0; i < books.book.Length; i++)
//         {
//             Debug.Log(books.book[i].Chapter);
//             Debug.Log(books.book[i].CTitle);
//             Debug.Log(books.book[i].Section);
//             Debug.Log(books.book[i].STitle);
//             Debug.Log(books.book[i].Text);
            
//             Rule rule = ScriptableObject.CreateInstance<Rule>();
//             rule.title = books.book[i].STitle;
//             rule.description = books.book[i].Text;
//             rule.CTitle = books.book[i].CTitle;
//             rule.score=0;

//             SaveScriptableObject(rule);

//         }
//     }



//     private void SaveScriptableObject(Rule ruleObject)
//     {
//         string folderPath = "Assets/Rules";

//         // Ensure the folder exists, create it if not
//         if (!AssetDatabase.IsValidFolder(folderPath))
//         {
//             AssetDatabase.CreateFolder("Assets", "Rules");
//         }

//         // Use title as the file name (remove invalid characters)
//         string fileName = ruleObject.title.Replace(" ", "_") + ".asset";

//         char[] invalidChars = Path.GetInvalidFileNameChars();

//         // Replace invalid characters with underscores
//         foreach (char invalidChar in invalidChars)
//         {
//             fileName = fileName.Replace(invalidChar, '_');
//         }
//         // Combine the folder path and file name
//         string path = $"{folderPath}/{fileName}";

//         // Create and save the asset
//         AssetDatabase.CreateAsset(ruleObject, path);
//         AssetDatabase.SaveAssets();
//         AssetDatabase.Refresh();
//     }


// }