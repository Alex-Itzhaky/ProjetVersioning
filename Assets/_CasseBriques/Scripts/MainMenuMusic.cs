using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _musicClip;

    private void Start()
    {
        AudioManager.Instance.PlayMusicClip(_musicClip);
    }
}
