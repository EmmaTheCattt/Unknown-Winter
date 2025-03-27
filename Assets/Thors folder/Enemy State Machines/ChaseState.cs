using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ChaseState : IState
{
    private EnemyBrain brain;

    public ChaseState(EnemyBrain brain)
    {
        this.brain = brain;
    }

    public void Enter()
    {
        Debug.Log("Enter Chase State");
    }

    public void Execute()
    {
        Debug.Log("I´m Chasing");
        brain.agent.SetDestination(brain.playerTransform.position);
        if (brain.playerSpottet == false)
        {
            brain.EnemyStateMachine.ChangeState(brain.EnemyStateMachine.idleState);
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Chase State");
    }
}
