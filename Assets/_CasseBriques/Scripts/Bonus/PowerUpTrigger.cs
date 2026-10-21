using UnityEngine;
using NaughtyAttributes;
using System;
using UnityEngine.Events;

public class PowerUpTrigger : MonoBehaviour
{
    [Tag]
    [SerializeField] private string _platformTag;

    public event Action OnBonusTrigger;
    public UnityEvent OnPowerUpPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("touché pour de faux");
        if (collision.CompareTag(_platformTag))
        {
            //Invoquer le pouvoir
            Debug.Log("touché");
            OnBonusTrigger?.Invoke();
            OnPowerUpPickup?.Invoke();
            Destroy(transform.parent.gameObject);
        }
    }
}
