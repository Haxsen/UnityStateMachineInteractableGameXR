using UnityEngine;

/// <summary>
/// Sleeping state for Huntable.
/// </summary>
public class HuntableSleeping : BaseState
{
    protected HuntableStateMachine huntableStateMachine;

    public HuntableSleeping(HuntableStateMachine stateMachine) : base(stateMachine)
    {
        huntableStateMachine = (HuntableStateMachine) this.stateMachine;
    }
    
    public override void Enter()
    {
        base.Enter();
        huntableStateMachine.onEnterSleep?.Invoke();
        
        Debug.Log("Entered Sleeping state");
    }
}
