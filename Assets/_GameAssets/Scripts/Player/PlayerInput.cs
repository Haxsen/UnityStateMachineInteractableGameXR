using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// Handles the player input.
/// </summary>
public class PlayerInput : MonoBehaviour
{
    #region Globally Accessible Values
    public static Vector2 InputDirection;
    public static Vector2 PointerDelta;
    #endregion

    [Header("Events")]
    public UnityEvent movementInputPerformedEvent;
    public UnityEvent movementInputEndedEvent;
    public UnityEvent lookInputPerformedEvent;

    private bool _isLooking;

    /// <summary>
    /// Gets the movement input from the new Input System and invokes the movement events.
    /// </summary>
    /// <param name="context">the input action callback context</param>
    public void Move(InputAction.CallbackContext context)
    {
        InputDirection = context.ReadValue<Vector2>();

        if (context.performed) movementInputPerformedEvent?.Invoke();
        else if (context.canceled) movementInputEndedEvent?.Invoke();
    }

    /// <summary>
    /// Gets the look input from the new Input System and invokes the look event.
    /// </summary>
    /// <param name="context">the input action callback context</param>
    public void Look(InputAction.CallbackContext context)
    {
        if (!_isLooking) return;
        
        PointerDelta = context.ReadValue<Vector2>();

        if (context.performed) lookInputPerformedEvent?.Invoke();
    }

    /// <summary>
    /// Gets primary button input from the new Input System and enables the looking boolean.
    /// </summary>
    /// <param name="context">the input action callback context</param>
    public void ActivateLook(InputAction.CallbackContext context)
    {
        if (context.started) _isLooking = true;
        else if (context.canceled) _isLooking = false;
    }
}
