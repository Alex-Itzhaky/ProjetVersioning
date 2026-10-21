using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    readonly List<Ball> _ballRegistry = new List<Ball>();
    public IReadOnlyList<Ball> BallRegistry => _ballRegistry;
    [SerializeField] private Transform _ballStartPosition;

    [RequiredType(typeof(Ball), typeof(Rigidbody2D))]
    [SerializeField] private GameObject _ballPrefab;

    public event Action OnEmptyBallRegistry;

    private void Start()
    {
        SpawnBall(_ballStartPosition.position, Vector2.up * 5);
    }

    public void AddBall(Ball ball)
    {
        _ballRegistry.Add(ball);
    }

    public void RemoveBall(Ball ball)
    {
        _ballRegistry.Remove(ball);
        Destroy(ball.gameObject);
        if (_ballRegistry.Count == 0)
        {
            OnEmptyBallRegistry?.Invoke();
        }
    }


    public void SpawnBall(Vector2 startPos, Vector2 startVelocity)
    {
        GameObject ball = Instantiate(_ballPrefab, startPos, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().linearVelocity = startVelocity;
        AddBall(ball.GetComponent<Ball>());
    }
}
