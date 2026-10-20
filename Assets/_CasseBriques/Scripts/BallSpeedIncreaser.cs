using NaughtyAttributes;
using UnityEngine;

public class BallSpeedIncreaser : MonoBehaviour
{
    // This script depend on Ball.cs
    // Place in same gameObject with Ball.cs
    Ball _ball;
    BallData _ballData; // Copy
    Collider2D _collider;

    private const float DefaultAddSpeed = 0f;
    private const float DefaultMultiplySpeed = 1f;
    [EnableIf(nameof(CanEditAddSpeed))]
    [MinValue(0)]
    [SerializeField] float _hitAddSpeed = 0f; // 0 Default
    [EnableIf(nameof(CanEditMultiplySpeed))]
    [MinValue(0)]
    [SerializeField] float _hitMultiplier = 1f; // 1 Default
    private bool CanEditAddSpeed => Mathf.Approximately(_hitMultiplier, DefaultMultiplySpeed);
    private bool CanEditMultiplySpeed => Mathf.Approximately(_hitAddSpeed, DefaultAddSpeed);


    void Start()
    {
        _ball = GetComponent<Ball>();
        if (_ball.BallData != null) _ballData = _ball.BallData; // copy BallData

        if (_ball.BallData != null)
        {
            _hitAddSpeed = _ballData.HitAddSpeed;
            _hitMultiplier = _ballData.HitMultiplier;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            if (_hitAddSpeed != DefaultAddSpeed)
            {
                _ball.IncreaseSpeed(_hitAddSpeed);
            }
            else if (_hitMultiplier != DefaultMultiplySpeed)
            {
                _ball.MultiplySpeed(_hitMultiplier);
            }
        }
    }
}
