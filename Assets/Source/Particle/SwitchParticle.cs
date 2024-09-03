using UnityEngine;

public class SwitchParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _firstParticle;
    [SerializeField] private ParticleSystem _secondParticle;

    public void PlayFirstParticle()
    {
        if (!_firstParticle.isPlaying)
        {
            _firstParticle.Play();
        }
    }

    public void PlaySecondParticle()
    {
        if (!_firstParticle.isPlaying)
        {
            _secondParticle.Play();
        }
    }
}
