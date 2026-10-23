using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    class ActiveEffect
    {
        public PowerUpEffect effect;
        public float remainingDuration;
    }

    [SerializeField] private BallManager _ballManager;
    [SerializeField] private ScaleChanger _scaleChanger;
    [SerializeField] private GameObject _bonusPrefab;

    private List<ActiveEffect> _activeEffects = new List<ActiveEffect>();
    private PowerUpReferences _powerReferences;

    private void Awake()
    {
        _powerReferences = new PowerUpReferences(_ballManager, _scaleChanger);
    }

    private void Start()
    {
        BrickPowerUp.OnPowerDropped += SpawnBonus;
    }

    private void OnDestroy()
    {
        BrickPowerUp.OnPowerDropped -= SpawnBonus;
    }

    private void Update()
    {
        for (int i = _activeEffects.Count - 1; i >= 0; i--)
        {
            _activeEffects[i].remainingDuration -= Time.deltaTime;
            if (_activeEffects[i].remainingDuration > 0)
                continue;

            ActiveEffect expiredEffect = _activeEffects[i];
            _activeEffects.RemoveAt(i);
            expiredEffect.effect.RemoveEffect(_powerReferences);
        }
    }


    public void SpawnBonus(PowerUpData data, Vector2 pos)
    {
        GameObject bonusInstance = Instantiate(_bonusPrefab, pos, Quaternion.identity);
        bonusInstance.GetComponent<PowerUpContainer>().Init(data, this);
        bonusInstance.GetComponentInChildren<SpriteRenderer>().sprite = data.Icon;
    }

    public void ActivatePower(PowerUpEffect effect)
    {
        //Si le pouvoir est instant
        if (effect.Duration <= 0)
        {
            effect.ApplyEffect(_powerReferences);
            return;
        }

        //Si le pouvoir est déjà active, on ralonge la durée de l'effet
        ActiveEffect existingEffect = _activeEffects.Find(e => e.effect == effect);
        if (existingEffect != null)
        {
            existingEffect.remainingDuration += effect.Duration;
            return;
        }

        //Si le pouvoir est pas activé, on le rajoute
        effect.ApplyEffect(_powerReferences);
        _activeEffects.Add(new ActiveEffect { effect = effect , remainingDuration = effect.Duration});
        
    }
}


