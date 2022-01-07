using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability Data", menuName = "ScriptableObjects/Ability Data", order = 1)]
public class AbilityData : ScriptableObject
{
    public string Name;

    public virtual void OnActivated(Agent target) { }
}
