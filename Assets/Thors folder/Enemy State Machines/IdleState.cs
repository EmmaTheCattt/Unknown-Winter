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
        brain.ChaseOver();
    }

    public void Execute()
    {


        if (brain.playerSpottet == true)
        {
            brain.EnemyStateMachine.ChangeState(brain.EnemyStateMachine.chaseState);
        }
        else
        {
            brain.agent.isStopped = true;
        }
        //brain.ChaseOver();
    }

    public void Exit()
    {
        
    }
}
