using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeepingStateMachine
{
    public IState CurrentState { get; private set; }

    //  Reference to state objects
    public WeepingStartState startState;
    public WeepingChaseState chaseState;
    public WeepingIdleState idleState;

    //  State machince constructor
    public WeepingStateMachine(WeepingBrain brain)
    {
        //create instance for each state to be handled
        this.startState = new WeepingStartState(brain);
        this.chaseState = new WeepingChaseState(brain);
        this.idleState = new WeepingIdleState(brain);
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
