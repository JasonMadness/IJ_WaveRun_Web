using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatExplosion : MonoBehaviour
{
    [SerializeField] private BoatFragmented _prefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            gameObject.SetActive(false);
            BoatFragmented boat = Instantiate(_prefab, transform.position, transform.rotation);
            boat.Explode();
            Destroy(gameObject);
        }
    }
}
