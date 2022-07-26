using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles the Huntable trigger events.
/// </summary>
public class HuntableTrigger : MonoBehaviour
{
    public UnityEvent onPlayerTriggerEntered;
    public UnityEvent onPlayerTriggerExited;
    
    #region MonoBehaviour
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player trigger entered the huntable.");
            onPlayerTriggerEntered?.Invoke();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player trigger exited the huntable.");
            onPlayerTriggerExited?.Invoke();
        }
    }
    #endregion
}
