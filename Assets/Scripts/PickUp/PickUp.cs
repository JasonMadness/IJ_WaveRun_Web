using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _splashes;

    public event Action<PickUp> PickedUp;

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
