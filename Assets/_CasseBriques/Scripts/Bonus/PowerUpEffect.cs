using Unity.VisualScripting;
using UnityEngine;

public class PowerUpReferences
{
    BallManager _ballManager;
    ScaleChanger _scaleChanger;

    public BallManager BallManager => _ballManager;
    public ScaleChanger ScaleChanger => _scaleChanger;
    public PowerUpReferences(BallManager ballManager, ScaleChanger scaleChanger)
    {
        _ballManager = ballManager;
        _scaleChanger = scaleChanger;
    }
}

public abstract class PowerUpEffect : ScriptableObject
{
    [SerializeField] protected float _duration;

    public float Duration => _duration;
    public abstract void ApplyEffect(PowerUpReferences references);
    public virtual void RemoveEffect(PowerUpReferences references) { }
}