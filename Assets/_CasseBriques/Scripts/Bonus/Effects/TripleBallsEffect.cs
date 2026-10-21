using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName ="TripleBallEffect", menuName = "Scriptable Objects/Power Ups/Triple Balle")]
public class TripleBallsEffect : PowerUpEffect
{
    [SerializeField] private int _nbOfExtraBalls = 2;

    public override void ApplyEffect(PowerUpReferences references)
    {
        Debug.Log("Triplé");
        List<Ball> ballRegistryCopy = new List<Ball>(references.BallManager.BallRegistry);
        for (int i = 0; i < _nbOfExtraBalls; i++)
        {
            for (int j = 0; j < ballRegistryCopy.Count; j++)
            {
                float randomAngle = Random.Range(-30, 30);
                Rigidbody2D rb = ballRegistryCopy[j].GetComponent<Rigidbody2D>();
                float velocity = rb.linearVelocity.magnitude;
                Vector2 direction = Quaternion.Euler(0, 0, randomAngle) * rb.linearVelocity.normalized;

                references.BallManager.SpawnBall(ballRegistryCopy[j].transform.position, direction * velocity);
            }
        }
    }
}
