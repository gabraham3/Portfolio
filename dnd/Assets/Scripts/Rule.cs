using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rule", menuName = "Rules")]
public class Rule : ScriptableObject
{
    public string CTitle;
    public string title;
    public string description;

    public int score;

}
