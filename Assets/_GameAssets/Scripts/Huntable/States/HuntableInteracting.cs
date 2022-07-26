using UnityEngine;

/// <summary>
/// Interacting state for Huntable.
/// </summary>
public class HuntableInteracting : BaseState
{
    protected HuntableStateMachine huntableStateMachine;

    public HuntableInteracting(HuntableStateMachine stateMachine) : base(stateMachine)
    {
        huntableStateMachine = (HuntableStateMachine) this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        huntableStateMachine.onEnterInteracting?.Invoke();
        
        Debug.Log("Entered Interacting state");
    }

    public override void Update()
    {
        huntableStateMachine.LookAtCamera();
        if (huntableStateMachine.IsPlayerInteracting())
        {
            huntableStateMachine.interactableCircle.FillCircle();
        }
        else
        {
            huntableStateMachine.ChangeState(huntableStateMachine.catchableState);
        }
    }
}