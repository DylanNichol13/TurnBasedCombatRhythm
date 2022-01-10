using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput
{
    public AbilityData SelectedAbility;
    public Agent SelectedTarget;
    public PlayerInputState PlayerInputState;

    public UserInput()
    {
        PlayerInputState = PlayerInputState.SelectAbility;
    }

    public void SelectAbility(AbilityData abilityData)
    {
        SelectedAbility = abilityData;
#if DEBUG
        Debug.Log($"{SelectedAbility.Name} selected");
#endif

        SetInputState(PlayerInputState.SelectTarget);
    }

    public void SelectTarget(Agent agent)
    {
        if (PlayerInputState != PlayerInputState.SelectTarget)
        {
#if DEBUG
            Debug.Log("You must select an ability");
#endif
            return;
        }

        SelectedTarget = agent;

        //Rhythm will happen here
        RhythmController.instance.StartNewRhythm();

#if DEBUG
        Debug.Log($"Used {SelectedAbility.Name} on target: {SelectedTarget.Name}");
#endif
    }

    internal void SuccessfulHit()
    {
        RhythmController.instance.SuccessfulHit();

#if DEBUG
        Debug.Log($"Succesful hit - {SelectedAbility.Name} on target: {SelectedTarget.Name}");
#endif
    }

    public void SetInputState(PlayerInputState state)
    {
        PlayerInputState = state;
    }

    public void SetInputSelectAbility()
    {
        SetInputState(PlayerInputState.SelectAbility);
    }
}
