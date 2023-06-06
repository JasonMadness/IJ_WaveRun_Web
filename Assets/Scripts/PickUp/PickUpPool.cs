using UnityEngine;

public class PickUpPool : ObjectPool
{
    [SerializeField] private PickUp _pickupPrefab;

    private void Start()
    {
        Initialize(_pickupPrefab.gameObject);
    }
}