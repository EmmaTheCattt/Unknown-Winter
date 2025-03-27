using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void Enter()
    {
        //  Logic for entering state
    }

    public void Execute()
    {
        //  Logic that runs each frame, and state switch condition
    }

    public void Exit()
    {
        // Logic for exiting state
    }
}
