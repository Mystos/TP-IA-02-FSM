using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : PlayerState
{

    public override void Update(StateMachine stateMachine)
    {
        this.HandleInput(stateMachine);
    }

    public override PlayerState HandleInput(StateMachine stateMachine)
    {
        if (Input.GetAxis("Horizontal") < 0.3f || Input.GetAxis("Horizontal") > -0.3f)
        {
            if (stateMachine.GetState().GetType() != typeof(IdleState))
            {
                stateMachine.SetState(PlayerState.idleState);
            }
        }

        return stateMachine.GetState();
    }

    public override IEnumerator Start(StateMachine stateMachine)
    {

        Debug.Log("Start RunState");

        stateMachine.animator.Play("PlayerRun");

        return base.Start(stateMachine);
    }


}
