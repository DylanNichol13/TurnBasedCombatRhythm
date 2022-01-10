using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentEntity : MonoBehaviour
{
    public Agent Agent;
    public Animator Animator;

    private void OnEnable()
    {
        Animator = GetComponent<Animator>();
    }

    public void SetAnimation(bool turnActive)
    {
        Animator.SetBool("turnActive", turnActive);
    }

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
