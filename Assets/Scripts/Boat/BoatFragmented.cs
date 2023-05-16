using UnityEngine;

public class BoatFragmented : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;
    [SerializeField] private float _explosionForse;

    public void Explode()
    {
        Rigidbody[] pieces = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody piece in pieces)
        {
            //piece.useGravity = true;
            piece.AddForce((Vector3.up / 2 + Random.insideUnitSphere) * _explosionForse, ForceMode.Impulse);
        }

        Destroy(gameObject, _destroyDelay);
    }
}
