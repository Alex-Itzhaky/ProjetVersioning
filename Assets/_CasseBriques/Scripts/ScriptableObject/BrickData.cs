using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "BrickData", menuName = "Scriptable Objects/BrickData")]
public class BrickData : ScriptableObject
{
    [SerializeField] Sprite sprite;
    [SerializeField] Color color = new Color(255, 255, 255, 255);
    [MinValue(0)]
    [SerializeField] int hp = 1;
    [MinValue(0)]
    [SerializeField] float dropChance = 0f; // 0.15f => 0.15% 


    public Sprite Sprite => sprite;
    public Color Color => color;
    public int Hp => hp;
    public float DropChance => dropChance;
}