using UnityEngine;

/// <summary>
/// Base interactable class.
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Click,
        Hover,
        Hold
    }

    public InteractionType interactionType;

    // private variables
    private float _holdTime;
    private bool _isInteracting;

    #region Public Methods
    public abstract void Interact();

    public float GetHoldTime() => _holdTime;
    public void IncreaseHoldTime() => _holdTime += Time.deltaTime;
    public void ResetHoldTime() => _holdTime = 0;

    public bool GetIsInteracting() => _isInteracting;
    public void SetIsInteracting(bool value)
    {
        _isInteracting = value;
        if (!_isInteracting) ResetHoldTime();
    }
    #endregion
}
