using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearI : Item
{
    public string Weight;
    public GearI(string Name, string cost, string weight)
        : base(Name, cost)
    {
        this.Weight = weight;
    }
}
