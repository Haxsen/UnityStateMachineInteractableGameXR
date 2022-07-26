using UnityEngine;

/// <summary>
/// Catchable state for Huntable.
/// </summary>
public class HuntableCatchable : BaseState
{
    protected HuntableStateMachine huntableStateMachine;

    public HuntableCatchable(HuntableStateMachine stateMachine) : base(stateMachine)
    {
        huntableStateMachine = (HuntableStateMachine) this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        huntableStateMachine.onEnterInteractable?.Invoke();
        
        Debug.Log("Entered Catchable state");
    }

    public override void Update()
    {
        huntableStateMachine.LookAtCamera();
        if (huntableStateMachine.IsPlayerInteracting())
        {
            huntableStateMachine.ChangeState(huntableStateMachine.interactingState);
        }
    }
}
