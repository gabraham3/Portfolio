using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq; // Add this using directive

public class ItemManagerButton : MonoBehaviour
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
    public ItemScript[] itemScripts;
    void Start()
    {
        LoadRules();
        makeItems();
        ChangeButtons();
    }

    public void Search(){
        ChangeButtons();
    }
    /// <summary>
    /// AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH KILL MEEEEEEEE
    /// </summary>
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

    private void ChangeButtons()
    {
        int[] topIndices = GetTop10Indices(items);
        int i = 0;
        foreach (ItemScript itemScript in itemScripts)
        {
            // Ensure we don't exceed the bounds of the rules array
            if (i < items.Length)
            {
                itemScript.item = items[topIndices[i]];
            }
            else
            {
                // Handle if there are more buttons than rules
                Debug.LogWarning("More buttons than rules.");
            }
            i++;
        }
    }

        // Define a local function to get the top 10 indices        
        int[] GetTop10Indices(Item[] items)
        {
            // If rules is null or empty, return an empty array
            if (items == null || items.Length == 0)
                return new int[0];

            // Get indices of top 10 scores
            var topIndices = Enumerable.Range(0, items.Length)
                                        .OrderByDescending(i => items[i].score)
                                        .Take(10)
                                        .ToArray();

            return topIndices;
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
            case "Service":
                items = services;
                break;
            case "Waterborne":
                items = waterbornes;
                break;
            case "Pack":
                items = packs;
                break;
            default:

                break;
        }
        }
}
