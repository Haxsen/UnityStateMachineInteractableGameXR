using UnityEngine;

/// <summary>
/// Contains the player statistics.
/// </summary>
[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStatsScriptableObject", order = 1)]
public class PlayerStatsSO : ScriptableObject
{
    [Header("Player Control")]
    public float movementSpeed;
    public float lookSensitivity;

    [Header("Player Interaction")]
    public float interactionRange = 20f;
}
