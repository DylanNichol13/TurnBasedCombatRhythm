using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Agent
{
    public string Name;
    public int HP, HPMax;

    public Agent(string name, int hpMax)
    {
        Name = name;
        HP = hpMax;
        HPMax = hpMax;
    }
}
