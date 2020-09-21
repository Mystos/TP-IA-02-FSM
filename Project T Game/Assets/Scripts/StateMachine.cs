using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected PlayerState state;

    public void HandleInput()
    {
        state.HandleInput(this);
    }

    public void SetState(PlayerState state)
    {
        this.state = state;
        StartCoroutine(this.state.Start());
    }

    public PlayerState GetState()
    {
        return state;
    }
}
