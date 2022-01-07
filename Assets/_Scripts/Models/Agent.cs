using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent 
{
    public string Name;
    public int HP, HPMax;
    public bool IsPlayer;
    public Sprite Sprite;
    public List<AbilityData> Abilities;

    public Agent(AgentData data)
    {
        this.Name = data.Name;
        this.HP = data.HPMax;
        this.HPMax = data.HPMax;
        this.IsPlayer = data.IsPlayer;
        this.Sprite = data.Sprite;
        this.Abilities = data.Abilities;
    }
}
