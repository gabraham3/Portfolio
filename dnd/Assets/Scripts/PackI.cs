using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackI : Item
{
    public string Description;
    public PackI(string Name, string cost, string description)
        : base(Name, cost)
    {
        this.Description = description;
    }
}
