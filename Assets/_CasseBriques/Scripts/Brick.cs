using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] BrickData _brickStats;
    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] Color _color;
    [SerializeField] int _hp = 1;
    [SerializeField] int _armor = 0;
    [SerializeField] float _dropChance = 0.15f; // 15%

    Collider2D _collider;



    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>();

        // Replace data
        if (_brickStats != null)
        {
            _color = _brickStats.Color;
            _hp = _brickStats.Hp;
            _armor = _brickStats.Armor;
            _dropChance = _brickStats.DropChance;
            if (_brickStats.Sprite != null) _sprite.sprite = _brickStats.Sprite;
            _sprite.color = _color;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();

            // Damage
            _hp -= ball.Damage;

            // Piercing > Hp
            if (ball.CurrentPiercing > 0) ball.PierceBrick();

            CheckDestroy();
        }
    }

    void CheckDestroy()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}