using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpData", menuName = "Scriptable Objects/PowerUpData")]
public class PowerUpData : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private PowerUpEffect _effect;

    public Sprite Icon => _icon;
    public PowerUpEffect Effect => _effect;

}
