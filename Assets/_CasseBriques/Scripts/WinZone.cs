using UnityEngine;
using UnityEngine.Events;

public class WinZone : MonoBehaviour
{
    public UnityEvent OnWin;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball")) 
        {
            OnWin?.Invoke();
        }
    }
}
