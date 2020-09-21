using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public override PlayerState HandleInput(StateMachine stateMachine)
    {
        if (Input.GetAxis("Horizontal") > 0.3f || Input.GetAxis("Horizontal") < -0.3f)
        {
            stateMachine.SetState(PlayerState.runState);
        }

        return stateMachine.GetState();
    }

    public override IEnumerator Start()
    {
        Debug.Log("Start IdleState");

        return base.Start();
    }

    public override void Update(StateMachine stateMachine)
    {
        base.Update(stateMachine);
    }
}
