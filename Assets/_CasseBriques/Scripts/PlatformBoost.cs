using UnityEngine;

public class PlatformBoost : MonoBehaviour
{
    // Req Rigidbody2D
    [SerializeField] float influence;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (ballRb != null)
        {
            Vector2 vel = ballRb.linearVelocity;
            vel.x += _rb.linearVelocity.x * influence;
            ballRb.linearVelocity = vel;
        }
    }
}