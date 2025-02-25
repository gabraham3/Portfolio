using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackI : Item
{
    public string weight;
    public TackI(string Name, string cost, string weight)
        : base(Name, cost)
    {
        this.weight = weight;
    }
}