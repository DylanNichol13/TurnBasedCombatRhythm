using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Agent Data", menuName = "ScriptableObjects/Agent Data", order = 1)]
public class AgentData : ScriptableObject
{
    public string Name;
    public int HP, HPMax;
    public bool IsPlayer;
    public Sprite Sprite;
    public List<AbilityData> Abilities;
}
