using UnityEngine;

/// <summary>
/// Captured state for Huntable.
/// </summary>
public class HuntableCaptured : BaseState
{
    protected HuntableStateMachine huntableStateMachine;

    public HuntableCaptured(HuntableStateMachine stateMachine) : base(stateMachine)
    {
        huntableStateMachine = (HuntableStateMachine) this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        
        Debug.Log("Entered Captured state");
    }
}