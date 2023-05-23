using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _splashes;

    private Transform _container;
    private float _value;

    public float Value => _value;

    public event Action<PickUp> PickedUp;

    public void Initialize(float value, Transform container)
    {
        _value = value;
        _container = container;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            foreach (ParticleSystem splash in _splashes)
            {
                ParticleSystem particles = Instantiate(splash, transform.position, transform.rotation);
                particles.transform.SetParent(_container);
                Destroy(particles.gameObject, 2f);
            }

            PickedUp?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}
