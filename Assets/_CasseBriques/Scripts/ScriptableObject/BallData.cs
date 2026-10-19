using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "BallData", menuName = "Scriptable Objects/BallData")]
public class BallData : ScriptableObject
{
    [Header("Base Stats")]
    private const float DefaultAddSpeed = 0f;
    private const float DefaultMultiplySpeed = 1f;
    [MinValue(0)]
    [SerializeField] float baseSpeed = 5;
    [EnableIf(nameof(CanEditAddSpeed))]
    [MinValue(0)]
    [SerializeField] float hitAddSpeed = 0f; // +0
    [EnableIf(nameof(CanEditMultiplySpeed))]
    [MinValue(0)]
    [SerializeField] float hitMultiplySpeed = 1f; // +0% / 100%
    private bool CanEditAddSpeed => Mathf.Approximately(hitMultiplySpeed, DefaultMultiplySpeed);
    private bool CanEditMultiplySpeed => Mathf.Approximately(hitAddSpeed, DefaultAddSpeed);
    [MinValue(0)]
    [SerializeField] float maxSpeed = 16;
    [SerializeField] Sprite sprite;
    [SerializeField] Color color = new Color(255, 255, 255, 255);

    [Header("Ball plus")]
    [MinValue(0)]
    [SerializeField] int damage = 1;
    [MinValue(0)]
    [SerializeField] int piercing = 0;



    public float BaseSpeed => baseSpeed;
    public float HitAddSpeed => hitAddSpeed;
    public float HitMultiplier => hitMultiplySpeed;
    public float MaxSpeed => maxSpeed;
    public Sprite Sprite => sprite;
    public Color Color => color;


    public int Damage => damage;
    public int Piercing => piercing;
}
