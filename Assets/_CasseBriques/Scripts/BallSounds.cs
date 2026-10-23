using UnityEngine;
using System.Collections.Generic;

public class BallSounds : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _collisionsSFX = new List<AudioClip>();
    [SerializeField] private float _volume = 0.8f;
    [SerializeField] private float _pitchVariance = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            int random = Random.Range(0, _collisionsSFX.Count - 1);
            AudioManager.Instance.PlaySoundFXClip(_collisionsSFX[random], _volume, _pitchVariance);
        }
    }
}
