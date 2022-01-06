using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance;

    public Battle CurrentBattle;

    [SerializeField] private Sprite _testSprite;
    private List<BattlePosition> _battlePositions = new List<BattlePosition>();

    // Start is called before the first frame update
    internal void Start()
    {
        instance = this;

        //Init test battle
        InitBattle();
        SpawnCharacters();
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
        agents.Add(new Agent("Agent one", 5, true));
        agents.Add(new Agent("Agent two", 5, true));
        agents.Add(new Agent("Agent three", 5, true));
        agents.Add(new Agent("Agent four", 5));
        agents.Add(new Agent("Agent five", 5));

        CurrentBattle = new Battle(agents);
    }

    //Spawn visuals
    private void SpawnCharacters()
    {
        if(_battlePositions.Count < 1)
            _battlePositions = GameObject.Find("BattlePositionParent").GetComponentsInChildren<BattlePosition>().ToList();

        foreach(var agent in CurrentBattle.BattleAgentsQueue)
        {
            BattlePosition battlePosition;
            GameObject agentObj = new GameObject();
            SpriteRenderer renderer = agentObj.AddComponent<SpriteRenderer>();
            
            if (agent.IsPlayer)
            {
                battlePosition = _battlePositions.First(x => x.IsPlayer && !x.IsTaken);
                renderer.flipX = true;
            }
            else
            {
                battlePosition = _battlePositions.First(x => !x.IsPlayer && !x.IsTaken);
            }

            agentObj.name = agent.Name;
            agentObj.transform.SetParent(battlePosition.transform);
            agentObj.transform.localPosition = Vector3.zero;
            renderer.sprite = _testSprite;
            battlePosition.IsTaken = true;
        }
    }
}
