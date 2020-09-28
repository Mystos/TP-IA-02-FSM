using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public override PlayerState HandleInput(StateMachine stateMachine)
    {
        if (Input.GetAxis("Horizontal") > 0.3f || Input.GetAxis("Horizontal") < -0.3f)
        {
            if(stateMachine.GetState().GetType() != typeof(RunState))
            {
                stateMachine.SetState(PlayerState.runState);
            }
        }

        return stateMachine.GetState();
    }

    public override IEnumerator Start(StateMachine stateMachine)
    {
        Debug.Log("Start IdleState");

        stateMachine.animator.Play("PlayerIdle");

        return base.Start(stateMachine);
    }

    public override void Update(StateMachine stateMachine)
    {
        this.HandleInput(stateMachine);
    }
}
