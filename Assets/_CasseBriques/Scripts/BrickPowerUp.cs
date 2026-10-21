using System;
using UnityEngine;

public class BrickPowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpData _powerData;
    public static event Action<PowerUpData, Vector2> OnPowerDropped;

    [SerializeField] private Brick _brick;


    //modifier script Brick pour recevoir event
    private void Start()
    {
        _brick.OnBrickDestroyed += OnDrop;
    }

    private void OnDestroy()
    {
        _brick.OnBrickDestroyed -= OnDrop;
    }
    private void OnDrop()
    {
        OnPowerDropped?.Invoke(_powerData, transform.position);
    }
}
