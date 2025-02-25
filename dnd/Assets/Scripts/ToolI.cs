using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolI : Item
{
    public string weight;
    public ToolI(string Name, string cost, string weight)
        : base(Name, cost)
    {
        this.weight = weight;
    }
}
