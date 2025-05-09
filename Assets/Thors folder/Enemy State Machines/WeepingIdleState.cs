using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeepingIdleState : IState
{
    private WeepingBrain brain;

    public WeepingIdleState(WeepingBrain brain)
    {
        this.brain = brain;
    }

    public void Enter()
    { }

    public void Execute()
    {
        if (brain.canSeeMe == false)
        {
            brain.WeepingStateMachine.ChangeState(brain.WeepingStateMachine.chaseState);
        }
        else
        {
            brain.agent.isStopped = true;
        }
        
    }

    public void Exit()
    { }
}
