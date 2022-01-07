using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentEntity : MonoBehaviour
{
    public Agent Agent;

    private void OnMouseDown()
    {
        InputController.instance.SelectTarget(Agent);
    }

    private void OnMouseEnter()
    {
        InputController.instance.TargetHoverEnter(gameObject);
    }

    private void OnMouseExit()
    {
        InputController.instance.TargetHoverExit();
    }
}
