using UnityEngine.Events;

/// <summary>
/// Handles the Huntable interaction.
/// </summary>
public class Huntable : Interactable
{
    public UnityEvent onHuntableCaptured;
    public HuntableEventsSO huntableEventsSO;

    #region MonoBehaviour
    private void Awake()
    {
        enabled = false;
    }
    #endregion

    /// <summary>
    /// Executes the huntable interaction.
    /// </summary>
    public override void Interact()
    {
        onHuntableCaptured?.Invoke();
        huntableEventsSO.OnHuntableCaptured?.Invoke();
    }
}