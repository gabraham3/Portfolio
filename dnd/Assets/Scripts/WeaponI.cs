using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponI : Item
{
    public string damage;
    public string weight;
    public string properties;
    public WeaponI(string Name, string cost, string damage, string weight, string properties)
        : base(Name, cost)
    {
        this.damage = damage;
        this.weight = weight;
        this.properties = properties;
    }
}
