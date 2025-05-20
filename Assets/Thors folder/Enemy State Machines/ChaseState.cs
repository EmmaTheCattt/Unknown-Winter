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
        brain.Chasetime();
    }

    public void Execute()
    {
        if (brain.playerSpottet == false)
        {
            brain.EnemyStateMachine.ChangeState(brain.EnemyStateMachine.idleState);
        }
        brain.agent.isStopped = false;
        brain.agent.SetDestination(brain.playerTransform.position);
        //brain.Chasetime();
    }

    public void Exit()
    {
        
    }
}
