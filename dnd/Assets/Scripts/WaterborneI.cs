using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterborneI : Item
{
    public string speed;
    public WaterborneI(string Name, string cost, string speed)
        : base(Name, cost)
    {
        this.speed = speed;
    }
}
