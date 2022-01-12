using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmController : MonoBehaviour, IGameController
{
    public static RhythmController instance;
    public static event Action EndRhythmEvent;

    public Rhythm CurrentRhythm;

    private GameObject _attackReadyIndicator;

    public bool RhythmActive() { return CurrentRhythm != null && CurrentRhythm.AttackState == AttackState.Active; }

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void Initialize()
    {
        SubscribeEvents();
    }

    public void SubscribeEvents()
    {
        EndRhythmEvent += HideIndicator;
    }

    private void Update()
    {
        ProcessActiveRhythm();
    }

    public void StartNewRhythm()
    {
        StartCoroutine(ProcessRhythm());
    }

    public void SuccessfulHit()
    {
        EndRhythm();
    }

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

    private void EndRhythm()
    {
        EndRhythmEvent?.Invoke();
    }

    private IEnumerator ProcessRhythm()
    {
        yield return new WaitForSeconds(1.5f);

        SetRhythmActive();
    }

    private void SetRhythmActive()
    {
        if (_attackReadyIndicator == null) _attackReadyIndicator = Instantiate(PrefabManager.instance.AttackReadyIndicatorPrefab);

        _attackReadyIndicator.SetActive(true);
        _attackReadyIndicator.transform.SetParent(BattleController.instance.CurrentBattle.CurrentTurnAgent.Entity.transform);
        _attackReadyIndicator.transform.localPosition = new Vector3(0, 1.2f, 0);

        CurrentRhythm = new Rhythm();
        CurrentRhythm.Begin();
        EndRhythmEvent += CurrentRhythm.Complete;
    }

    private void HideIndicator()
    {
        if (_attackReadyIndicator == null) return;

        _attackReadyIndicator.SetActive(false);
    }
}
