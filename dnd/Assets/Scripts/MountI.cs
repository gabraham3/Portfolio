using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountI : Item
{
    public string speed;
    public string CC;
    public MountI(string Name, string cost, string speed, string carryingCapacity)
        : base(Name, cost)
    {
        this.speed = speed;
        this.CC = carryingCapacity;
    }
}
