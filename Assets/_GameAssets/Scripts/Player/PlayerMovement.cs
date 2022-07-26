using UnityEngine;

/// <summary>
/// Handles the Player movement and look.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public PlayerStatsSO playerStatsSO;
    
    private Rigidbody _rb;

    #region MonoBehaviour
    private void Awake()
    {
        if(!TryGetComponent(out _rb)) Debug.LogError("Player lacks Rigidbody!");
    }
    #endregion

    /// <summary>
    /// Moves the player based on the input direction from the <c>PlayerInput</c>.
    /// </summary>
    public void Move()
    {
        float mV = PlayerInput.InputDirection.y;
        float mH = PlayerInput.InputDirection.x;
        _rb.velocity = (transform.forward * mV + transform.right * mH).normalized * playerStatsSO.movementSpeed;
    }

    /// <summary>
    /// Stops the player movement.
    /// </summary>
    public void Stop()
    {
        _rb.velocity = Vector3.zero;
    }

    /// <summary>
    /// Rotates the player based on Pointer delta (e.g. Mouse position change).
    /// </summary>
    public void Look()
    {
        Vector3 rotationDelta = new Vector3(-PlayerInput.PointerDelta.y, PlayerInput.PointerDelta.x, 0);
        transform.localEulerAngles += (rotationDelta * playerStatsSO.lookSensitivity);
    }
}
