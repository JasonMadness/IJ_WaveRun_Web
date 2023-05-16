using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _splashes;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            foreach (ParticleSystem splash in  _splashes)
            {
                ParticleSystem particles = Instantiate(splash, transform.position, transform.rotation);
                Destroy(particles.gameObject, 2f);
            }

            gameObject.SetActive(false);
        }
    }
}
