using UnityEngine;

public class BoatPool : ObjectPool
{
    [SerializeField] private Boat _boatPrefab;

    private void Start()
    {
        Initialize(_boatPrefab.gameObject);
    }
}