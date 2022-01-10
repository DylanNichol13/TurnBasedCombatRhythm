using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Battle
{
    public Queue<Agent> BattleAgentsQueue;
    public Agent CurrentTurnAgent;

    public static event Action ChangeTurnEvent;
    public static event Action ClearTurnEvent;

    //Constructor
    public Battle(List<Agent> agents)
    {
        BattleAgentsQueue = GenerateQueue(agents);
        CurrentTurnAgent = BattleAgentsQueue.Peek();

        SubscribeEvents();
    }

    //Subscribe actions to events
    private void SubscribeEvents()
    {
        ChangeTurnEvent += ProgressQueue;
        ChangeTurnEvent += SetupNewTurn;

        ClearTurnEvent += ChangeTurn;
    }

    ///Public
    public void Destroy()
    {
        ChangeTurnEvent -= ProgressQueue;
        Debug.Log("Deleting old turn");
    }

    public void ChangeTurn()
    {
        ChangeTurnEvent?.Invoke();
    }
    
    //Progress the queue by one and return the new top agent
    public void ProgressQueue()
    {
        var agent = BattleAgentsQueue.Dequeue();
        agent.Entity.SetAnimation(false);

        BattleAgentsQueue.Enqueue(agent);
        
        //Debug log for testing
        DebugLogQueue();
    }

    public void SetupNewTurn()
    {
        //Get new turn enabled agent
        CurrentTurnAgent = BattleAgentsQueue.Peek();
        CurrentTurnAgent.Entity.SetAnimation(true);
    }
    
    ///Private
    //Generate the queue
    private Queue<Agent> GenerateQueue(List<Agent> agents)
    {
        Queue<Agent> agentQueue = new Queue<Agent>();
        foreach(var agent in agents)
        {
            agentQueue.Enqueue(agent);
        }

        return agentQueue;
    }

    //Debug.Log order of queue
    private void DebugLogQueue()
    {
        foreach(var agent in BattleAgentsQueue)
        {
            Debug.Log(agent.Name);
        }
    }
}
