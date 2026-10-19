using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rb;
    Collider _collider;

    [SerializeField] BallData _ballData;
    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] Color _color;
    [SerializeField] float _baseSpeed;
    [SerializeField] float _hitMultiplier;
    [SerializeField] float _maxSpeed;
    [SerializeField] int _damage = 1;
    [SerializeField] int _piercing = 0;
    int _currentPiercing = 0;
    Vector2 _savedVelocity; // Pierce through object

    public int Damage => _damage;
    public int CurrentPiercing => _currentPiercing;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();

        _rb.AddForce(new Vector2(150, 500), ForceMode2D.Force);

        // Replace data
        if (_ballData != null)
        {
            _baseSpeed = _ballData.BaseSpeed;
            _hitMultiplier = _ballData.HitMultiplier;
            _maxSpeed = _ballData.MaxSpeed;
            if (_ballData.Sprite != null) _sprite.sprite = _ballData.Sprite;
            _color = _ballData.Color;
            _damage = _ballData.Damage;
            _piercing = _ballData.Piercing;
        }
        ResetPiercing();
    }

    void FixedUpdate()
    {
        if (_piercing > 0) _savedVelocity = _rb.linearVelocity;
    }
    public void PierceBrick()
    {
        _rb.linearVelocity = _savedVelocity;
        _currentPiercing--;
    }
    public void StopPiercing() => _currentPiercing = 0;

    // Call it when collide with Plateform
    public void ResetPiercing()
    {
        _currentPiercing = _piercing;
    }
}
