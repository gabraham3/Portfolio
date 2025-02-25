using UnityEngine;

public class ArmorI : Item // Inherit from the Item class
{
  public string armorClass;
  public string Strength;
  public string Stealth;
  public string Weight;
  public string Description;

  public ArmorI(string _Name, string _cost, string ac, string strengthReq, string stealthDisadv, string weight, string desc)
    : base(_Name, _cost) // Call the base class constructor
  {
    armorClass = ac;
    Strength = strengthReq;
    Stealth = stealthDisadv;
    Weight = weight;
    Description = desc;
  }
}