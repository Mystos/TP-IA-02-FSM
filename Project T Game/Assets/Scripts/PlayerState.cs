using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{

    public static IdleState idleState;
    public static RunState runState;

    public PlayerState() {}

    public virtual PlayerState HandleInput(StateMachine stateMachine) { return null; }
    public virtual void Update(StateMachine stateMachine) {}
    public virtual IEnumerator Start() { yield break; }
}
