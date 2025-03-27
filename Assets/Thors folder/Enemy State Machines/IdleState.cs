using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class IdleState : IState
{
    private EnemyBrain brain;

    //  Class instance
    //EnemyEyes2 eyes = new EnemyEyes2();

    public IdleState(EnemyBrain brain)
    {
        this.brain = brain;
    }

    public void Enter()
    {
        Debug.Log("Enter Idle State");
    }

    public void Execute()
    {
        Debug.Log("Im Idling");

        if (brain.playerSpottet == true)
        {
            brain.EnemyStateMachine.ChangeState(brain.EnemyStateMachine.chaseState);
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Idle State");
    }
}
