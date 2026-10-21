using System;
using UnityEngine;

public class BallKiller : MonoBehaviour
{
    // This script hate balls. If you have balls, you dead.

    [SerializeField] BallManager ballManager;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballManager.RemoveBall(collision.GetComponent<Ball>());
        }
    }
}
