using UnityEngine;

[CreateAssetMenu(fileName = "BallData", menuName = "Scriptable Objects/BallData")]
public class BallData : ScriptableObject
{
    [Header("Base Stats")]
    [SerializeField] float baseSpeed;
    [SerializeField] float hitMultiplier;
    [SerializeField] float maxSpeed;
    [SerializeField] Sprite sprite;
    [SerializeField] Color color;

    [Header("Ball plus")]
    [SerializeField] int damage = 1;
    [SerializeField] int piercing = 0;



    public float BaseSpeed => baseSpeed;
    public float HitMultiplier => hitMultiplier;
    public float MaxSpeed => maxSpeed;
    public Sprite Sprite => sprite;
    public Color Color => color;


    public int Damage => damage;
    public int Piercing => piercing;
}
