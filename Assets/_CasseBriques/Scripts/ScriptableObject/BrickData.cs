using UnityEngine;

[CreateAssetMenu(fileName = "BrickData", menuName = "Scriptable Objects/BrickData")]
public class BrickData : ScriptableObject
{
    [SerializeField] Sprite sprite;
    [SerializeField] Color color;
    [SerializeField] int hp = 1;
    [SerializeField] int armor = 0;
    [SerializeField] float dropChance = 0f; // 0.15f => 0.15% 


    public Sprite Sprite => sprite;
    public Color Color => color;
    public int Hp => hp;
    public int Armor => armor;
    public float DropChance => dropChance;
}