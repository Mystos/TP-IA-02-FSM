using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected PlayerState state;
    public Animator animator;

    public void HandleInput()
    {
        state.Update(this);
    }

    public void SetState(PlayerState state)
    {
        this.state = state;
        this.state.Start(this);
        //StartCoroutine(this.state.Start(this));
    }

    public PlayerState GetState()
    {
        return state;
    }
}
