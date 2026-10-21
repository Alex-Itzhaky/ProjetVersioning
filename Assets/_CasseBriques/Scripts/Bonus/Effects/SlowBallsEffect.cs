using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "SlowBalls", menuName = "Scriptable Objects/Power Ups/Slow Balls")]
public class SlowBallsEffect : PowerUpEffect
{
    [MinValue(0), MaxValue(1)]
    [SerializeField] private float _speedMultiplier;
    public override void ApplyEffect(PowerUpReferences references)
    {
        foreach(Ball ball in references.BallManager.BallRegistry)
        {
            ball.GetComponent<Rigidbody2D>().linearVelocity *= _speedMultiplier;
        }
    }

    public override void RemoveEffect(PowerUpReferences references)
    {
        foreach (Ball ball in references.BallManager.BallRegistry)
        {
            ball.GetComponent<Rigidbody2D>().linearVelocity /= _speedMultiplier;
        }
    }

}
