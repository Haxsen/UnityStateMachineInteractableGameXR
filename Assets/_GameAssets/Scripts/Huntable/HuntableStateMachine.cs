using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Huntable state machine.
/// </summary>
[RequireComponent(typeof(Huntable))]
public class HuntableStateMachine : StateMachine
{
    [Header("Component References")]
    public UIViewInteractableCircle interactableCircle;
    [SerializeField] Transform wakeUpSphereTriggerTransform;
    [SerializeField] Transform interactionUICanvas;

    [Header("Huntable Config")]
    [SerializeField] [Tooltip("The threshold distance from the player that wakes this huntable.")]
    float wakeUpDistance = 10f;
    
    [Header("Events")]
    public UnityEvent onEnterSleep;
    public UnityEvent onEnterInteractable;
    public UnityEvent onEnterInteracting;
    public UnityEvent onEnterCaptured;
    
    // states
    public HuntableSleeping sleepingState;
    public HuntableCatchable catchableState;
    public HuntableInteracting interactingState;
    public HuntableCaptured capturedState;
    
    // private variables
    private Huntable _huntable;
    private Camera _mainCamera;

    #region MonoBehaviour
    private void Awake()
    {
        _huntable = GetComponent<Huntable>();
        _mainCamera = Camera.main;

        ApplySphereTriggerScale();
        
        sleepingState = new HuntableSleeping(this);
        catchableState = new HuntableCatchable(this);
        interactingState = new HuntableInteracting(this);
        capturedState = new HuntableCaptured(this);
    }
    #endregion

    /// <summary>
    /// Initializes the state.
    /// </summary>
    /// <returns>the sleeping state</returns>
    protected override BaseState GetInitialState()
    {
        return sleepingState;
    }

    /// <summary>
    /// Checks if the player is interacting.
    /// </summary>
    /// <returns>whether the player is interacting</returns>
    public bool IsPlayerInteracting() => _huntable.GetIsInteracting();

    /// <summary>
    /// Captures the huntable by changing its state.
    /// </summary>
    public void CaptureHuntable()
    {
        Debug.Log("Huntable captured!");
        ChangeState(capturedState);
        onEnterCaptured?.Invoke();
    }

    /// <summary>
    /// Wakes or Sleeps the huntable.
    /// </summary>
    /// <param name="wake">whether to wake it up or sleep</param>
    public void WakeUp(bool wake)
    {
        ChangeState(wake ? catchableState : sleepingState);
    }

    /// <summary>
    /// Rotates the interaction UI to look at the camera.
    /// </summary>
    public void LookAtCamera()
    {
        interactionUICanvas.LookAt(_mainCamera.transform);
    }

    /// <summary>
    /// Applies the trigger scale, i.e. Creates a wake up threshold distance from the player.
    /// </summary>
    private void ApplySphereTriggerScale()
    {
        wakeUpSphereTriggerTransform.localScale = new Vector3(wakeUpDistance, wakeUpDistance, wakeUpDistance);
    }
}
