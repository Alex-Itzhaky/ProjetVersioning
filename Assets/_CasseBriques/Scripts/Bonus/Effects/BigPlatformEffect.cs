using UnityEngine;

[CreateAssetMenu(fileName = "BigPlatform", menuName = "Scriptable Objects/Power Ups/Big Platform")]
public class BigPlatformEffect : PowerUpEffect
{
    [SerializeField] private float _bigScale;

    public override void ApplyEffect(PowerUpReferences references)
    {
        references.ScaleChanger.UpdateScale(_bigScale);
    }

    public override void RemoveEffect(PowerUpReferences references)
    {
        references.ScaleChanger.UpdateScale(references.ScaleChanger.BaseScale);
    }
}
