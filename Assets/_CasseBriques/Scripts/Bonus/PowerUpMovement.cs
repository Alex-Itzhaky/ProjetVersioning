using NaughtyAttributes;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    [MinValue(0)]
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
