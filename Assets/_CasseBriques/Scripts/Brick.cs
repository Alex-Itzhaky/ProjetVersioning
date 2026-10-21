using UnityEngine;
using NaughtyAttributes;
using System;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    [SerializeField] BrickData _brickData;
    private bool HasBrickData => _brickData == null;
    [ShowIf(nameof(HasBrickData))]
    [SerializeField] SpriteRenderer _sprite;
    [ShowIf(nameof(HasBrickData))]
    [SerializeField] Color _color;
    [ShowIf(nameof(HasBrickData))]
    [MinValue(0)]
    [SerializeField] int _hp = 1;
    [ShowIf(nameof(HasBrickData))]
    [MinValue(0)]
    [SerializeField] float _dropChance = 0.15f; // 15%

    Collider2D _collider;

    public event Action OnBrickDestroyed;
    public UnityEvent OnBrickDestruction;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>();

        // Replace data
        if (_brickData != null)
        {
            _color = _brickData.Color;
            _hp = _brickData.Hp;
            _dropChance = _brickData.DropChance;
            if (_brickData.Sprite != null) _sprite.sprite = _brickData.Sprite;
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

            // Pierce > Hp else
            if (ball.CurrentPiercing > 0 && _hp <= 0)
            {
                ball.PierceBrick();
            }
            else
            {
                ball.StopPiercing();
            }

            CheckDestroy();
        }
    }

    void CheckDestroy()
    {
        if (_hp <= 0)
        {
            GamblingDrop();
            OnBrickDestroyed?.Invoke(); // Tell to WinChecker to remove from list
            OnBrickDestruction?.Invoke();
            Destroy(gameObject);
        }
    }

    public void GamblingDrop()
    {
        float result = UnityEngine.Random.value;
        if (result < _dropChance)
        {
            Debug.Log($"Dropped");
        }
        else
        {
            Debug.Log("Mambo :(");
        }
    }
}