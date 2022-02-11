using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmController : MonoBehaviour
{
    public static RhythmController instance;

    public Rhythm CurrentRhythm;

    private GameObject _attackReadyIndicator;

    public bool RhythmActive() { return CurrentRhythm != null && CurrentRhythm.AttackState == AttackState.Active; }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    private void Update()
    {
        ProcessActiveRhythm();
    }
    
    //Check for active rhythm expiration
    private void ProcessActiveRhythm()
    {
        if (CurrentRhythm == null) return;

        if(CurrentRhythm.AttackState == AttackState.Active)
        {
            var complete = CurrentRhythm.IsProcessComplete();
            if (complete)
            {
                EndRhythm();
            }
        }
    }

    //Called by UserInput when a target is selected
    public void StartNewRhythm()
    {
        StartCoroutine(ProcessRhythm());
    }

    //Wait for X time and set the rhythm to active and waiting for input
    private IEnumerator ProcessRhythm()
    {
        yield return new WaitForSeconds(1.5f);

        SetRhythmActive();
    }

    //Show the rhythm indicator sprite and set the Rhythm active timer in CurrentRhythm.Begin()
    private void SetRhythmActive()
    {
        if (_attackReadyIndicator == null) _attackReadyIndicator = Instantiate(PrefabManager.instance.AttackReadyIndicatorPrefab);

        _attackReadyIndicator.SetActive(true);
        _attackReadyIndicator.transform.SetParent(BattleController.instance.CurrentBattle.CurrentTurnAgent.Entity.transform);
        _attackReadyIndicator.transform.localPosition = new Vector3(0, 1.2f, 0);

        CurrentRhythm = new Rhythm();
        CurrentRhythm.Begin();
    }

    //Called by userInput when a rhythm is active and user successfully completes
    public void SuccessfulHit()
    {
        EndRhythm();
    }

    //Called to end the rhythm in session
    private void EndRhythm()
    {
        CurrentRhythm.Complete();
        HideIndicator();
        BattleController.instance.ProgressTurn();
        InputController.instance.UserInput.SetInputState(PlayerInputState.SelectAbility);
    }

    //Hide the sprite indicator
    private void HideIndicator()
    {
        if (_attackReadyIndicator == null) return;

        _attackReadyIndicator.SetActive(false);
    }
}
