using UnityEngine;

/// <summary>
/// Plays the audio on the state machine events.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioClipPlayerForStateMachine : MonoBehaviour
{
    private StateMachine _stateMachine;
    
    private AudioSource _audioSource;

    #region MonoBehaviour
    private void Awake()
    {
        _stateMachine = GetComponentInParent<StateMachine>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _stateMachine.OnStateChanged += PlaySoundEffect;
    }

    private void OnDisable()
    {
        _stateMachine.OnStateChanged -= PlaySoundEffect;
    }
    #endregion

    /// <summary>
    /// Plays the audio.
    /// </summary>
    private void PlaySoundEffect()
    {
        _audioSource.Play();
    }
}
