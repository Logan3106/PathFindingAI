using NUnit.Framework.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


public class StateMachine : MonoBehaviour
{
    public State CurrentState { get; private set; }
    public State LastState { get; private set; }

    public void Init(State startingState)
    {
        CurrentState = startingState;
        LastState = null;
        startingState.Enter();
    }

    public void ChangeState(State newState)
    {
        //Debug.Log("Changing state to " + newState);
        CurrentState.Exit();

        LastState = CurrentState;
        CurrentState = newState;
        newState.Enter();

    }

    public State GetState()
    {
        return CurrentState;
    }
}
