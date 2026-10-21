using UnityEngine;

public class BallKiller : MonoBehaviour
{
    // This script hate balls. If you have balls, you dead.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
        }
    }
}
