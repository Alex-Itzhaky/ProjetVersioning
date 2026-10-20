using UnityEngine;
using NaughtyAttributes;

public class PowerUpTrigger : MonoBehaviour
{
    [Tag]
    [SerializeField] private string _platformTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_platformTag))
        {
            //Invoquer le pouvoir
        }
    }
}
