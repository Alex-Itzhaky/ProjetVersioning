using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "ScreamerEffect", menuName = "Scriptable Objects/Power Ups/ScreamerEffect")]
public class ScreamerEffect : PowerUpEffect
{
    [SerializeField] private GameObject _screamerPrefab;
    [SerializeField] private AudioClip _audioClip;

    [Foldout("Screamer Shake Stats")]
    [SerializeField] private float _strength;
    [Foldout("Screamer Shake Stats")]
    [SerializeField] private int _vibrato;
    [Foldout("Screamer Shake Stats")]
    [SerializeField] private float _randomness;
    [Foldout("Screamer Shake Stats")]
    [SerializeField] private bool _snapping;

    private GameObject _screamerInstance;
    private Tweener _tween;

    public override void ApplyEffect(PowerUpReferences references)
    {
        _screamerInstance = Instantiate(_screamerPrefab);
        _tween = _screamerInstance.transform.DOShakePosition(_duration, _strength, _vibrato, _randomness, _snapping, false, ShakeRandomnessMode.Full)
            .SetUpdate(true);
        AudioManager.Instance.PlaySoundFXClip(_audioClip, 1f);
    }

    public override void RemoveEffect(PowerUpReferences references)
    {
        DOTween.Kill(_tween);
        Destroy(_screamerInstance);
    }
}
