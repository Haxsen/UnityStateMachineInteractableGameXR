using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Handles the huntables count on the UI.
/// </summary>
public class HuntablesCountUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    
    [SerializeField] HuntableEventsSO huntableEventsSO;

    private Transform _huntablesContainerTransform;

    private int _count;
    private int _totalCount;

    #region MonoBehaviour
    private void Awake()
    {
        _huntablesContainerTransform = GameObject.FindWithTag("HuntablesContainer").transform;
    }

    private void OnEnable()
    {
        huntableEventsSO.OnHuntableCaptured += OnHuntablesCountDecreased;
        huntableEventsSO.OnHuntablesSpawned += OnHuntablesSpawned;
        UpdateHuntablesCountText();
    }

    private void OnDisable()
    {
        huntableEventsSO.OnHuntableCaptured -= OnHuntablesCountDecreased;
        huntableEventsSO.OnHuntablesSpawned -= OnHuntablesSpawned;
    }
    #endregion

    /// <summary>
    /// Counts the huntables and updates the UI.
    /// </summary>
    private void OnHuntablesSpawned()
    {
        _count = _huntablesContainerTransform.childCount;
        _totalCount = _count;
        UpdateHuntablesCountText();
    }

    /// <summary>
    /// Decrements the huntables by 1 and updates the UI.
    /// </summary>
    private void OnHuntablesCountDecreased()
    {
        _count--;
        UpdateHuntablesCountText();
    }

    /// <summary>
    /// Updates the UI text for huntables.
    /// </summary>
    private void UpdateHuntablesCountText()
    {
        text.text = String.Concat(_totalCount-_count, "/", _totalCount);
    }
}
