using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeepingChaseState : IState
{
    private WeepingBrain brain;

    public WeepingChaseState(WeepingBrain brain)
    {
        this.brain = brain;
    }

    public void Enter()
    { }

    public void Execute()
    {
        if (brain.canSeeMe == true)
        {
            brain.WeepingStateMachine.ChangeState(brain.WeepingStateMachine.idleState);
        }
        else
        {
            brain.agent.isStopped = false;
            brain.agent.SetDestination(brain.Player.transform.position);
        }
        
    }

    public void Exit()
    { }
}
