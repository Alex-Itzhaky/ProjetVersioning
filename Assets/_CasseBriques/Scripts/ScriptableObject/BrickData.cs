using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "BrickData", menuName = "Scriptable Objects/BrickData")]
public class BrickData : ScriptableObject
{
    [SerializeField] bool useSprite;
    [EnableIf(nameof(useSprite))]
    [SerializeField] Sprite spriteFullHp;
    [EnableIf(nameof(useSprite))]
    [SerializeField] Sprite spriteHalfHp;
    [DisableIf(nameof(useSprite))]
    [SerializeField] Color colorFullHp = new Color(255, 255, 255, 255);
    [DisableIf(nameof(useSprite))]
    [SerializeField] Color colorHalfHp = new Color(100, 100, 100, 255);
    [MinValue(0)]
    [SerializeField] int hp = 1;
    [SerializeField] float dropChance = 0f; // 0.15f => 0.15% 


    public bool UseSprite => useSprite;
    public Sprite SpriteFullHP => spriteFullHp;
    public Sprite SpriteHalfHP => spriteFullHp;
    public Color ColorFullHP => colorFullHp;
    public Color ColorHalfHP => colorHalfHp;
    public int Hp => hp;
    public float DropChance => dropChance;
}