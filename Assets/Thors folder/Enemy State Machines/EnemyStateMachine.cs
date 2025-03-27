using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class EnemyStateMachine
{
    public IState CurrentState { get; private set; }

    //  reference to state objects
    //  public SomeState someState
    public IdleState idleState;
    public ChaseState chaseState;

    //  state machine constructor
    public EnemyStateMachine(EnemyBrain brain)
    {
        //  create instance for each state to be handled
        //  this.SomeState = new SomeState();
        this.idleState = new IdleState(brain);
        this.chaseState = new ChaseState(brain);
    }

    //  Sets first state
    public void StartState(IState state)
    {
        CurrentState = state;
        state.Enter();
    }

    //  Exits current state and enters a new
    public void ChangeState(IState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }

    //  Allows state machine to update state
    public void Execute()
    {
        if (CurrentState != null)
        {
            CurrentState.Execute();
        }
    }
}
