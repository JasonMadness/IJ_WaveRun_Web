using System;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private float _upOffset = 0.1f;
    [SerializeField] private float _sideOffset = 0.1f;
    [SerializeField] private bool _needNormalFromRaycast;
    [SerializeField] private BoatFragmented _prefab;

    public event Action<Boat> Destroyed;

    public void LandTransform()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Physics.Raycast(ray, out RaycastHit hit);
        Vector3 upOffset = Vector3.up * _upOffset;
        Vector3 sideOffset = GetRandomSideOffset();
        transform.position = hit.point;

        if (_needNormalFromRaycast)
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            
        transform.position += upOffset + sideOffset;
    }

    private Vector3 GetRandomSideOffset()
    {
        float sideOffset = UnityEngine.Random.Range(-_sideOffset, _sideOffset);
        return Vector3.right * sideOffset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            gameObject.SetActive(false);
            BoatFragmented boat = Instantiate(_prefab, transform.position, transform.rotation);
            boat.Explode();
            Destroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
