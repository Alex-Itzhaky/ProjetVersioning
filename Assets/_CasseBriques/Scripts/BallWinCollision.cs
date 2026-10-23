using UnityEngine;

public class BallWinCollision : MonoBehaviour
{
    [SerializeField] WinChecker winChecker;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (winChecker != null) winChecker.WinGame();
            else
            {
                Debug.Log("winChecker missing");
            }
        }
    }
}
