using UnityEngine;

public class BoatFragmented : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;
    [SerializeField] private float _explosionForse;
    [SerializeField] private AudioSource[] _audioSources;

    public void Explode()
    {
        Rigidbody[] pieces = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody piece in pieces)
        {
            piece.AddForce((Vector3.up / 2 + Random.insideUnitSphere) * _explosionForse, ForceMode.Impulse);
        }

        int randomIndex = Random.Range(0, _audioSources.Length);
        _audioSources[randomIndex].Play();
        Destroy(gameObject, _destroyDelay);
    }
}
