using UnityEngine;

/// <summary>
/// Spawns the Huntables.
/// </summary>
public class HuntableSpawner : MonoBehaviour
{
    [SerializeField] Transform huntablePredefinedSpawnsContainer;
    [SerializeField] GameObject huntablePrefab;
    [SerializeField] Transform huntablesContainer;

    [SerializeField] HuntableEventsSO huntableEventsSO;

    #region MonoBehaviour
    private void Awake()
    {
        SpawnHuntablesRandomly();
    }
    #endregion

    /// <summary>
    /// Spawns the Huntables at predefined positions.
    /// </summary>
    private void SpawnHuntablesRandomly()
    {
        foreach (Transform spawnPosition in huntablePredefinedSpawnsContainer)
        {
            Instantiate(huntablePrefab, spawnPosition.position, Quaternion.identity, huntablesContainer);
        }
        
        huntableEventsSO.OnHuntablesSpawned?.Invoke();
    }
}
