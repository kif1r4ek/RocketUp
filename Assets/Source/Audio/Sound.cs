using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySaund()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }

    public void StopSound()
    {
        _audioSource.Stop();
    }
}
