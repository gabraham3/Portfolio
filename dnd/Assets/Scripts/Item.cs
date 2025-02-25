using UnityEngine;
using System;

// Base class for items
public class Item:ScriptableObject
{
    public string Name;
    public string cost;
    public int score;
    public Item(string _Name, string _cost)
    {
        Name = _Name;
        cost = _cost;
    }
}
