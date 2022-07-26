using System;
using UnityEngine;

/// <summary>
/// Handles the player interaction.
/// </summary>
public class PlayerInteraction : MonoBehaviour
{
    [Header("Config")]
    public PlayerStatsSO playerStatsSO;
    public string interactableLayerName = "InteractableLayer";
    
    private Camera _camera;
    private Interactable _currentInteractable;

    #region MonoBehaviour
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        CreateRaycastForInteraction();
    }
    #endregion

    /// <summary>
    /// Creates a raycast and handles the interactable if it was hit.
    /// </summary>
    private void CreateRaycastForInteraction()
    {
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        bool rayWasHit = Physics.Raycast(
            ray,
            out RaycastHit hitInfo,
            playerStatsSO.interactionRange,
            LayerMask.GetMask(interactableLayerName));
        
        if (rayWasHit)
        {
            Debug.Log("+ Raycast hit in the layer: " + interactableLayerName);

            _currentInteractable = hitInfo.collider.GetComponentInParent<Interactable>();
            if (!_currentInteractable)
            {
                Debug.LogWarning(
                    "Raycast was hit on an InteractableLayer object but it lacks Interactable component!");
                return;
            }

            if (_currentInteractable.enabled)
            {
                HandleInteraction(_currentInteractable);
                _currentInteractable.SetIsInteracting(true);
            }
        }
        else
        {
            Debug.Log("- Raycast did not hit anything in the layer: " + interactableLayerName);
            if (_currentInteractable)
            {
                _currentInteractable.SetIsInteracting(false);
                _currentInteractable = null;
            }
        }
    }

    /// <summary>
    /// Handles the interaction with the interactable.
    /// </summary>
    /// <param name="interactable">the interactable component of the object</param>
    /// <exception cref="NotSupportedException">Interactable can only handle predefined interaction types</exception>
    private void HandleInteraction(Interactable interactable)
    {
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                // if clicked/pressed then interactable.Interact();
                break;
            case Interactable.InteractionType.Hover:
                // no button required for hover;
                HoldInteraction(interactable);
                break;
            case Interactable.InteractionType.Hold:
                // if held a button then HoldInteraction(interactable);
                break;
            
            default:
                throw new NotSupportedException("The provided InteractionType is not supported!");
        }
    }

    /// <summary>
    /// Progresses the interaction of type hold.
    /// </summary>
    /// <param name="interactable">the interactable component of the object</param>
    private void HoldInteraction(Interactable interactable)
    {
        interactable.IncreaseHoldTime();
        if (interactable.GetHoldTime() > 1f)
        {
            interactable.ResetHoldTime();
            interactable.Interact();
        }
    }
}
