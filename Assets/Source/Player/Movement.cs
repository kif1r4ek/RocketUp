using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _thrust;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rb;
    private Sound _sound;
    private PlayParticle _particle;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _sound = GetComponent<Sound>();
        _particle = GetComponent<PlayParticle>();
    }

    private void FixedUpdate()
    {
        if (_rb != null)
        {
            ProcessThrust();
        }
    }

    private void Update()
    {
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(_rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-_rotateSpeed);
        }
    }

    private void ApplyRotation(float directionOfRotation)
    {
        _rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * directionOfRotation * Time.deltaTime);
        _rb.freezeRotation = false;
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrust();
        }
        else
        {
            StopThrust();
        }
    }

    private void StartThrust() 
    {
        _rb.AddRelativeForce(Vector3.up * _thrust * Time.deltaTime);
        _sound.PlaySaund();
        _particle.LaunchParticle();
    }

    private void StopThrust() 
    {
        _sound.StopSound();
        _particle.StopParticle();
    }
}
