using UnityEngine;
using NaughtyAttributes;

public class BallHp : MonoBehaviour
{
    Ball _ball;
    BallData _ballData; // Copy
    Collider2D _collider;


    public bool EnableHP = true;
    [EnableIf(nameof(EnableHP))]
    [MinValue(1)]
    [SerializeField] int _hp = 1;

    void Start()
    {
        _ball = GetComponent<Ball>();
        if (_ball.BallData != null) _ballData = _ball.BallData; // copy BallData

        if (_ball.BallData != null)
        {
            EnableHP = _ballData.EnableHP;
            _hp = _ballData.Hp;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick") && EnableHP)
        {
            _hp--;
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