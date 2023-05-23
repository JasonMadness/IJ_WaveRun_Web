using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _splashes;

    private float _value;

    public float Value => _value;

    public event Action<PickUp> PickedUp;

    public void Initialize(float value)
    {
        _value = value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            foreach (ParticleSystem splash in _splashes)
            {
                ParticleSystem particles = Instantiate(splash, transform.position, transform.rotation);
                Destroy(particles.gameObject, 2f);
            }

            PickedUp?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}
