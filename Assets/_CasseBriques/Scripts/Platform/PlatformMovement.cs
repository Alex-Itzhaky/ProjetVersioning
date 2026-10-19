using NaughtyAttributes;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformMovement : MonoBehaviour
{
    [Required("Rigidbody2D est requis")]
    [Label("Rigidbody2D")]
    [SerializeField] private Rigidbody2D _rb;
    [MinValue(0)]
    [SerializeField] private float _speed;
    private float _direction;

    private void Reset()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Move();
    }

    public void UpdateDirection(float direction)
    {
        _direction = Mathf.Clamp(direction, -1f, 1f);
    }

    private void Move()
    {
        _rb.linearVelocityX = _direction * _speed;
    }
}
