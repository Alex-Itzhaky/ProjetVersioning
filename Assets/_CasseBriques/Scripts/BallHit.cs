using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallHit : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioClipsOnHit = new List<AudioClip>();
    AudioClip _currentAudioClip;

    [Foldout("Audio Settings")]
    [SerializeField] private float _volume = 0.8f;
    [Foldout("Audio Settings")]
    [SerializeField] private float _pitchVariance = 0;

    public UnityEvent OnBallHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int random = Random.Range(0, _audioClipsOnHit.Count);
        _currentAudioClip = _audioClipsOnHit[random];
        OnBallHit?.Invoke();
    }

    public void PlayRandomSFXClip()
    {
        AudioManager.Instance.PlaySoundFXClip(_currentAudioClip, _volume, _pitchVariance);
    }
}
