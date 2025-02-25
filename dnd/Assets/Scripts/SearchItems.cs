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
public class SearchItems : MonoBehaviour
{
    //This should be the json text
    public ArmorI[] armors;
    public FoodI[] foods;
    public GearI[] gears;
    public TackI[] tacks;
    public ToolI[] tools;
    public TradeI[] trades;
    public WeaponI[] weapons;
    public Item[] items;
    public InputField searchBox;
    //This should be user input
    //This is the score based on where the string is found
    public int score;
    public bool chapterTitle = false;
    public bool sectionTitle = false;
    public bool bodyText = false;
    public string str1;
    public string str2;
    void Start(){
        LoadRules();
        makeItems();
    }
    // Start is called before the first frame update
    public void Search()
    {
        //need to get the type of text being searched from unity object stuff, like chapter title or body text
        string str2 = searchBox.text.ToUpper(new CultureInfo("en-US", false));
        foreach (Item item in items)
        {
            item.score = 0;
        }
        foreach (Item item in items){
            str1 = item.Name.ToUpper(new CultureInfo("en-US", false));
            bool containsSearchResult = str1.Contains(str2);
            if (containsSearchResult == true){
                item.score += 10;
            }
            str1 = item.cost.ToUpper(new CultureInfo("en-US", false));
            containsSearchResult = str1.Contains(str2);
            if (containsSearchResult == true){
                item.score += 6;
            }
        }
        //string str1 = stringtobesearched.ToUpper(new CultureInfo("en-US", false));
    }
    private void LoadRules()
    {
        armors = Resources.LoadAll<ArmorI>("Armors");
        foods = Resources.LoadAll<FoodI>("Food");
        gears = Resources.LoadAll<GearI>("Gear");
        tacks = Resources.LoadAll<TackI>("Tack");
        tools = Resources.LoadAll<ToolI>("Tool");
        trades = Resources.LoadAll<TradeI>("Trade");
        weapons = Resources.LoadAll<WeaponI>("Weapon");

    }
    private void makeItems()
    {
        string Itype=PlayerPrefs.GetString("ItemType");

        switch (Itype)
        {
            case "Armor":
                items = armors;
                break;
            case "Food": 
                items = foods;
                break;
            case "Gear": 
                items = gears;
                break;
            case "Tack": 
                items = tacks;
                break;
            case "Tool": 
                items = tools;
                break;
            case "Trade": 
                items = trades;
                break;
            case "Weapon":
                items = weapons;
                break;
                // Execute specific code for Button 1
            default:

                break;
        }

    }

}
