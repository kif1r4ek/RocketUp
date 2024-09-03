using UnityEngine;


public class SwitchSaund : MonoBehaviour
{
    [SerializeField] private AudioClip _audioFirst;
    [SerializeField] private AudioClip _audioSecond;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayFirstSaund()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_audioFirst);
        }
    }

    public void PlaySecondSaund()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_audioSecond);
        }
    }

}
