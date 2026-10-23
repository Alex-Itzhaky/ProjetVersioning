using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _musicClip;
    static bool hasPlayed;

    private void Start()
    {
        if (hasPlayed)
            return;
        AudioManager.Instance.PlayMusicClip(_musicClip);
        hasPlayed = true;
    }
}
