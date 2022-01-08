using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm
{
    public AttackState AttackState;
    public float ActiveTime;
    public float Timer;

    public Rhythm()
    {
        AttackState = AttackState.Inactive;
        ActiveTime = 1f;
    }

    public void Begin()
    {
        Timer = ActiveTime;
        AttackState = AttackState.Active;
    }

    public bool IsProcessComplete()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            return true;
        }
        return false;
    }

    public void Complete()
    {
        AttackState = AttackState.Inactive;
    }
}
