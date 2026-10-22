using UnityEngine;
using NaughtyAttributes;
using System;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    [SerializeField] BrickData _brickData;
    private bool HasBrickData => _brickData == null;
    [ShowIf(nameof(HasBrickData))]
    [SerializeField] bool useSprite;
    [ShowIf(nameof(HasBrickData)), EnableIf(nameof(useSprite))]
    [SerializeField] SpriteRenderer _spriteFullHp;
    [ShowIf(nameof(HasBrickData)), EnableIf(nameof(useSprite))]
    [SerializeField] SpriteRenderer _spriteHalfHp;
    [ShowIf(nameof(HasBrickData)), DisableIf(nameof(useSprite))]
    [SerializeField] Color _colorFullHp = new Color(255, 255, 255, 255);
    [ShowIf(nameof(HasBrickData)), DisableIf(nameof(useSprite))]
    [SerializeField] Color _colorHalfHp = new Color(100, 100, 100, 255);
    [ShowIf(nameof(HasBrickData))]
    [MinValue(0)]
    [SerializeField] int _hp = 1;
    public float _halfHpValue;
    [ShowIf(nameof(HasBrickData))]
    [MinValue(0)]
    [SerializeField] float _dropChance = 0.15f; // 15%

    Collider2D _collider;
    SpriteRenderer _sprite;

    public event Action OnBrickDestroyed;
    public UnityEvent OnBrickDestruction;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>();

        // Replace data with BrickData
        if (_brickData != null)
        {
            useSprite = _brickData.UseSprite;
            _hp = _brickData.Hp;
            _dropChance = _brickData.DropChance;
            if (_brickData.SpriteFullHP != null && useSprite) _spriteFullHp.sprite = _brickData.SpriteFullHP;
            if (_brickData.SpriteHalfHP != null && useSprite) _spriteHalfHp.sprite = _brickData.SpriteHalfHP;
            _colorFullHp = _brickData.ColorFullHP;
            _colorHalfHp = _brickData.ColorHalfHP;
        }

        _halfHpValue = _hp / 2;

        if (_spriteFullHp) _sprite = _spriteFullHp;
        _sprite.color = _colorFullHp;

        // Disable sprites
        if (!useSprite)
        {
            _spriteFullHp = null;
            _spriteHalfHp = null;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();

            // Take damage and check sprite
            TakeDamage(ball.Damage);

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

    void TakeDamage(int value)
    {
        _hp -= value;
        CheckHalfHP();
    }
    void CheckHalfHP()
    {
        if (_hp <= _halfHpValue)
        {
            if (_spriteHalfHp != null) _sprite = _spriteHalfHp;
            _sprite.color = _colorHalfHp;
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