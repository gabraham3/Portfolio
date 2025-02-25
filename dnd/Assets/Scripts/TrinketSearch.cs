using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;
using System;
public class TrinketSearch : MonoBehaviour
{
    public InputField searchBox;
    public Text textMeshPro;
    public TrinketI[] trinkets;
    public int index;
    public int found;
    void Start()
    {
        trinkets = Resources.LoadAll<TrinketI>("Trinket");

    }

    public void Search(int i)
    {
        found = -1;
        for(int j=0; j<100; j++){
            if(index==int.Parse(trinkets[j].cost)){
                found = j;
            }
        }
        if (found>=0 &&found<100){
            textMeshPro.text = trinkets[found].Name;
        }
    }

    public void SearchByText(){
        try
        {
            index = int.Parse(searchBox.text); // Convert string to int
        }
        catch (FormatException e)
        {
            index = 100;
        }
        if(index <= 0 || index >100){
            index = 100;
        }
        Search(index);
    }

    public void SearchByRoll(){
        index = UnityEngine.Random.Range(1,101);
        Search(index);
    }
}
