using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Agent
{
    public string Name;
    public int HP, HPMax;
    public bool IsPlayer;

    public Agent(string name, int hpMax, bool? isPlayer = false)
    {
        Name = name;
        HP = hpMax;
        HPMax = hpMax;
        IsPlayer = isPlayer ?? false;
    }
}
