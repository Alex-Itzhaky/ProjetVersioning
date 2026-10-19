using UnityEngine;
using NaughtyAttributes;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rb;
    Collider _collider;

    [SerializeField] BallData _ballData;
    private bool HasBallData => _ballData == null;
    [ShowIf(nameof(HasBallData))]
    [SerializeField] SpriteRenderer _sprite;
    [ShowIf(nameof(HasBallData))]
    [SerializeField] Color _color;
    [ShowIf(nameof(HasBallData))]
    [MinValue(0)]
    [SerializeField] float _baseSpeed = 5;
    [ShowIf(nameof(HasBallData))]
    [MinValue(0)]
    [SerializeField] float _maxSpeed = 16;
    [ShowIf(nameof(HasBallData))]
    [MinValue(0)]
    [SerializeField] int _damage = 1;
    [ShowIf(nameof(HasBallData))]
    [MinValue(0)]
    [SerializeField] int _piercing = 0;
    int _currentPiercing = 0;
    Vector2 _savedVelocity; // Pierce through object

    public int Damage => _damage;
    public int CurrentPiercing => _currentPiercing;
    public BallData BallData => _ballData; // Share to BallSpeedIncreaser.cs

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();

        // Replace data
        if (_ballData != null)
        {
            _baseSpeed = _ballData.BaseSpeed;
            _maxSpeed = _ballData.MaxSpeed;
            if (_ballData.Sprite != null) _sprite.sprite = _ballData.Sprite;
            _color = _ballData.Color;
            _damage = _ballData.Damage;
            _piercing = _ballData.Piercing;
        }
        ResetPiercing();

        LaunchBall();
    }

    void FixedUpdate()
    {
        if (_piercing > 0) _savedVelocity = _rb.linearVelocity;
    }

    private void LaunchBall()
    {
        // Y +- 30°
        float randomAngleDeg = Random.Range(-30f, 30f);

        Vector2 launchDirection = Quaternion.Euler(0f, 0f, randomAngleDeg) * Vector2.up;

        _rb.linearVelocity = launchDirection * _baseSpeed;
    }

    public void IncreaseSpeed(float additionalSpeed)
    {
        Vector2 direction = _rb.linearVelocity.normalized;
        float currentSpeed = _rb.linearVelocity.magnitude;

        float newSpeed = Mathf.Min(currentSpeed + additionalSpeed, _maxSpeed);
        _rb.linearVelocity = direction * newSpeed;
    }
    public void MultiplySpeed(float speedMultiplier)
    {
        Vector2 newVelocity = _rb.linearVelocity * speedMultiplier;
        _rb.linearVelocity = Vector2.ClampMagnitude(newVelocity, _maxSpeed);
    }


    #region Piercing
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
    #endregion
}
