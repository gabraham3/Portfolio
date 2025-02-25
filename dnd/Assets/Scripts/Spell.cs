using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells")]
public class Spell : ScriptableObject
{
    public string Name;
    public string[] Classes;
    public string School;
    public string[] Description;
    public string Level;
    public int score;

}
