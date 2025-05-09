using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeepingStartState : IState
{
    private WeepingBrain brain;

    public WeepingStartState(WeepingBrain brain)
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
        
    }

    public void Exit()
    { }
}
