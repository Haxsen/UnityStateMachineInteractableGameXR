using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Contains the events for huntables.
/// </summary>
[CreateAssetMenu(fileName = "HuntableEvents", menuName = "ScriptableObjects/HuntableEventsScriptableObject", order = 2)]
public class HuntableEventsSO : ScriptableObject
{
    public UnityAction OnHuntableCaptured;
    public UnityAction OnHuntablesSpawned;
}
