using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemsDisplay : MonoBehaviour
{

    public ArmorI[] armors;
    public FoodI[] foods;
    public GearI[] gears;
    public TackI[] tacks;
    public ToolI[] tools;
    public TradeI[] trades;
    public WeaponI[] weapons;
    public MountI[] mounts;
    public LifestyleI[] lifestyles;
    public ServiceI[] services; 
    public WaterborneI[] waterbornes;
    public PackI[] packs;
    public Item[] items;
    public int index = -1;
    public Text[] texts = new Text[7];
    public string spellType;

    void Start()
    {
        spellType = PlayerPrefs.GetString("ItemName");

        LoadRules();
        makeItems();
        int i = 0;
        foreach(Item item in items){
            if (item.Name == spellType){
                index = i;
            }
            i++;
        }
        if (index == -1){
            index = 0;
        }
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
        mounts = Resources.LoadAll<MountI>("Mount");
        lifestyles = Resources.LoadAll<LifestyleI>("Lifestyle");
        services = Resources.LoadAll<ServiceI>("Service");
        waterbornes = Resources.LoadAll<WaterborneI>("Waterborne");
        packs = Resources.LoadAll<PackI>("Pack");
    }

    //change to Start once everything works
    void Update ()
    {
        texts[0].text = items[index].Name;
        texts[1].text = items[index].cost;
        string Itype=PlayerPrefs.GetString("ItemType");

        switch (Itype)
        {
            case "Armor":
                texts[2].text = armors[index].armorClass;
                texts[3].text = "Strength:" + armors[index].Strength;
                texts[4].text = "Strealth" + armors[index].Stealth;
                texts[5].text = armors[index].Weight;
                texts[6].text = armors[index].Description;
                break;
            case "Food": case "Service":
                texts[2].text = "";
                texts[3].text = "";
                texts[4].text = "";
                texts[5].text = "";
                texts[6].text = "";
                break;
            case "Gear": 
                texts[2].text = "weight:" + gears[index].Weight;
                texts[3].text = "";
                texts[4].text = "";
                texts[5].text = "";
                texts[6].text = "";
                break;
            case "Tack": 
                texts[2].text = "weight:" + tacks[index].weight;
                texts[3].text = "";
                texts[4].text = "";
                texts[5].text = "";
                texts[6].text = "";
                break;
            case "Tool": 
                texts[2].text = "weight:" + tools[index].weight;
                texts[3].text = "";
                texts[4].text = "";
                texts[5].text = "";
                texts[6].text = "";
                break;
            case "Trade": 
                texts[2].text = "";
                texts[3].text = "";
                texts[4].text = "";
                texts[5].text = "";
                texts[6].text = "";
                break;
            case "Weapon":
                texts[2].text = "weight:" + weapons[index].weight;
                texts[3].text = "damage:" + weapons[index].damage;
                texts[4].text = "";
                texts[5].text = "";
                texts[6].text = weapons[index].properties;
                break;
                // Execute specific code for Button 1
            case "Mount":
                texts[2].text = "speed:" + mounts[index].speed;
                texts[3].text = "carrying capacity:" + mounts[index].CC;
                texts[4].text = "";
                texts[5].text = "";
                texts[6].text = "";
                break;
            case "Lifestyle":
                texts[2].text = "";
                texts[3].text = "";
                texts[4].text = "";
                texts[5].text = "";
                texts[6].text = lifestyles[index].Description;
                break;
            case "Waterborne":
                texts[2].text = "speed:" + waterbornes[index].speed;
                texts[3].text = "";
                texts[4].text = "";
                texts[5].text = "";
                texts[6].text = "";
                break;
            case "Pack":
                texts[2].text = "";
                texts[3].text = "";
                texts[4].text = "";
                texts[5].text = "";
                texts[6].text = packs[index].Description;
                break;
            default:


            break;
        }
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
            case "Mount":
                items = mounts;
                break;
            case "Lifestyle":
                items = lifestyles;
                break;
            case "Pack":
                items = packs;
                break;
            case "Service":
                items = services;
                break;
            case "Waterborne":
                items = waterbornes;
                break;
            default:

                break;
        }

    }

}
