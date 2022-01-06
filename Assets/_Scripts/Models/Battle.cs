using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Battle
{
    public Queue<Agent> BattleAgentsQueue;
    public Agent CurrentTurnAgent;

    //Constructor
    public Battle(List<Agent> agents)
    {
        BattleAgentsQueue = GenerateQueue(agents);
        CurrentTurnAgent = BattleAgentsQueue.Peek();

        //Init UI
        UIController.instance.SetCurrentTurnAgent(CurrentTurnAgent);
    }

    ///Public
    //Progress the queue by one and return the new top agent
    public Agent ProgressQueue()
    {
        var agent = BattleAgentsQueue.Dequeue();
        BattleAgentsQueue.Enqueue(agent);
        
        //Debug log for testing
        DebugLogQueue();

        //Get new turn enabled agent
        CurrentTurnAgent = BattleAgentsQueue.Peek();
        return CurrentTurnAgent;
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
