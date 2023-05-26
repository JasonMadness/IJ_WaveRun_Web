using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private PickUpPool _pickUpPool;
    [SerializeField] private Transform _particlesContainer;
    [SerializeField] private int _count;
    [SerializeField] private float _step;
    [SerializeField] private Vector3 _sideOffset;
    [SerializeField] private float _upOffset;

    private int _pickUpsCount;
    private Vector3 _currentOffset;
    private float _pickUpValue;

    public event Action<PickUp> Spawned;
    public event Action<PickUp> UnSpawned;

    private void Start()
    {
        _pickUpsCount = _spawnPoints.Count * _count;
        _pickUpValue = 1.0f / _pickUpsCount;
    }

    public void Spawn()
    {
        foreach (Transform point in _spawnPoints)
        {
            _currentOffset = GetNewOffset();

            for (int i = 0; i < _count; i++)
            {
                PickUp pickUp = _pickUpPool.GetPickUp();
                pickUp.transform.position = point.transform.position + _step * i * Vector3.forward + _currentOffset;
                pickUp.transform.SetParent(point);
                LandPosition(pickUp);
                pickUp.Initialize(_pickUpValue, _particlesContainer);
                pickUp.gameObject.SetActive(true);
                Spawned?.Invoke(pickUp);
            }
        }
    }

    public void UnSpawn()
    {
        List<PickUp> activePickups = _pickUpPool.GetAllActive();
        
        foreach (PickUp pickUp in activePickups)
        {
            pickUp.gameObject.SetActive(false);
            UnSpawned?.Invoke(pickUp);
        }
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

        Vector3[] posibleOffsets = { -_sideOffset, Vector3.zero, _sideOffset };
        Vector3 offset = posibleOffsets[Random.Range(0, posibleOffsets.Length)];

        while (offset == _currentOffset)
            offset = posibleOffsets[Random.Range(0, posibleOffsets.Length)];

        return offset;
    }
}