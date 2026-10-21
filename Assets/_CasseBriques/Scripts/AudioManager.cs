using NaughtyAttributes;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioManager Instance { get; private set; }

    [RequiredType(typeof(AudioSource))]
    [SerializeField] private AudioSource _audioSourcePrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, float volume = 0.8f, float pitchVariance = 0f)
    {
        AudioSource audioSource = Instantiate(_audioSourcePrefab, transform);
        audioSource.clip = audioClip;
        audioSource.volume = volume;

        if (pitchVariance != 0f)
        {
            float randomPitch = Random.Range(1f - pitchVariance, 1f + pitchVariance);
            audioSource.pitch = randomPitch;
        }

        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayMusicClip(AudioClip audioClip, Transform spawnTransform, float volume = 1f, bool looping = true)
    {
        AudioSource audioSource = Instantiate(_audioSourcePrefab, transform);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.loop = looping;

        audioSource.Play();
    }
}
