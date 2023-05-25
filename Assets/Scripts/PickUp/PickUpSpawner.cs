using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private PickUpPool _pool;
    [SerializeField] private Transform _particlesContainer;
    [SerializeField] private int _count;
    [SerializeField] private float _step;
    [SerializeField] private Vector3 _sideOffset;
    [SerializeField] private float _upOffset;

    private Vector3 _currentOffset;
    private float _pickUpValue;

    public event Action<PickUp> Spawned;
    public event Action<List<PickUp>> Deactivated;

    private void Start()
    {
        int pickUpsCount = _spawnPoints.Count * _count;
        _pickUpValue = 1.0f / pickUpsCount;
        _pool.Initialize(pickUpsCount);
    }

    public void Instantiate()
    {
        foreach (Transform point in _spawnPoints)
        {
            _currentOffset = GetNewOffset();

            for (int i = 0; i < _count; i++)
            {
                PickUp pickUp = _pool.GetPickUp();
                pickUp.transform.position = point.transform.position + _step * i * Vector3.forward + _currentOffset;
                pickUp.transform.SetParent(point);
                LandPosition(pickUp);
                pickUp.Initialize(_pickUpValue, _particlesContainer);
                pickUp.gameObject.SetActive(true);
                Spawned?.Invoke(pickUp);
            }
        }
    }

    public void DeactivateAllPickUps()
    {
        List<PickUp> deactivated = _pool.ReturnAllPickUps();
        Deactivated?.Invoke(deactivated);
    }

    private void LandPosition(PickUp pickUp)
    {
        Ray ray = new Ray(pickUp.transform.position, Vector3.down);
        Physics.Raycast(ray, out RaycastHit hit);
        pickUp.transform.position = hit.point + Vector3.up * _upOffset;
    }

    private Vector3 GetNewOffset()
    {
        if (_sideOffset == Vector3.zero)
            throw new ArgumentException("Side offset cannot be Vector3.zero, infinity loop error");

        Vector3[] posibleOffsets = {-_sideOffset, Vector3.zero, _sideOffset};
        Vector3 offset = posibleOffsets[Random.Range(0, posibleOffsets.Length)];

        while (offset == _currentOffset)
            offset = posibleOffsets[Random.Range(0, posibleOffsets.Length)];

        return offset;
    }
}
