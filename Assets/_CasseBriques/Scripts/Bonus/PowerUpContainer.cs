using NaughtyAttributes;
using System;
using UnityEngine;

public class PowerUpContainer : MonoBehaviour
{
    [Required]
    [SerializeField] private PowerUpTrigger _trigger;
    private PowerUpData _data;
    private PowerUpManager _powerUpManager;

    private void Start()
    {
        _trigger.OnBonusTrigger += ExecutePower;
    }

    private void OnDestroy()
    {
        _trigger.OnBonusTrigger -= ExecutePower;
    }

    public void Init(PowerUpData data,  PowerUpManager manager)
    {
        _powerUpManager = manager;
        _data = data;
    }

    public void ExecutePower() => _powerUpManager.ActivatePower(_data.Effect);

}
