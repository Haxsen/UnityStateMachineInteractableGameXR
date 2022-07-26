using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base state machine.
/// </summary>
public class StateMachine : MonoBehaviour
{
    public UnityAction OnStateChanged;
    
    private BaseState _currentState;

    #region MonoBehaviour
    private void Start()
    {
        _currentState = GetInitialState();
        
        if(_currentState != null) _currentState.Enter();
    }

    private void Update()
    {
        if(_currentState != null) _currentState.Update();
    }
    #endregion

    /// <summary>
    /// Initializes the state.
    /// </summary>
    /// <returns>null</returns>
    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    /// <summary>
    /// Exits the current state and enters the new state.
    /// </summary>
    /// <param name="newState">the new state</param>
    public void ChangeState(BaseState newState)
    {
        _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
        
        OnStateChanged?.Invoke();
    }
}
