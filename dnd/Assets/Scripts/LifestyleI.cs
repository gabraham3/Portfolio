using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifestyleI : Item
{
    public string Description;
    
    public LifestyleI(string Name, string cost, string description)
        : base(Name, cost)
    {
        this.Description = description;
    }
}
