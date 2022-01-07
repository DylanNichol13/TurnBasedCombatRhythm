using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackAbility : AbilityData
{
    public int HitCount;
    public int HitPower;

    public override void OnActivated(Agent target)
    {
        Debug.Log($"Used {Name} on {target.Name}");
    }
}
