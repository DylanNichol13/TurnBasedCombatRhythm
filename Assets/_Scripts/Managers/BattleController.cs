using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance;

    public Battle CurrentBattle;

    // Start is called before the first frame update
    internal void Start()
    {
        instance = this;

        //Init test battle
        InitBattle();
    }

    // Update is called once per frame
    internal void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ProgressTurn();
        }
    }

    ///Public
    //Progress the turn and do all related behaviour here
    public void ProgressTurn()
    {
        var newCurrentAgent = CurrentBattle.ProgressQueue();

        //Update UI
        UIController.instance.SetCurrentTurnAgent(newCurrentAgent);
    }

    ///Private
    //Init a test battle
    private void InitBattle()
    {
        var agents = new List<Agent>();
        agents.Add(new Agent("Agent one", 5));
        agents.Add(new Agent("Agent two", 5));
        agents.Add(new Agent("Agent three", 5));
        agents.Add(new Agent("Agent four", 5));
        agents.Add(new Agent("Agent five", 5));

        CurrentBattle = new Battle(agents);
    }
}
