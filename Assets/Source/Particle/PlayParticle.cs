using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _playParticle;

    public void LaunchParticle()
    {
        if (!_playParticle.isPlaying)
        {
            _playParticle.Play();
        }
    }

    public void StopParticle()
    {
        _playParticle.Stop();
    }
}
