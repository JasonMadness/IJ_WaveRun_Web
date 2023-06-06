using UnityEngine;
using System;
using System.Collections.Generic;
using PathCreation;

public class Level : MonoBehaviour
{    
    [SerializeField] private Splines _splines;
    [SerializeField] private PickUpSpawner _pickUpSpawner;
    [SerializeField] private BoatSpawner _boatSpawner;

    private PathCreator _activeSpline;
    private List<PickUp> _pickUps = new();
    private List<PickUp> _unusedPickUps = new();
    private List<Boat> _boats = new();
    private List<Boat> _unusedBoats = new();

    public event Action<PathCreator, List<PickUp>, List<Boat>> Created;
    public event Action<List<PickUp>, List<Boat>> Deleted;

    private void OnEnable()
    {
        _pickUpSpawner.Spawned += OnPickUpSpawned;
        _pickUpSpawner.UnSpawned += OnPickUpUnspawned;
        _boatSpawner.Spawned += OnBoatSpawned;
        _boatSpawner.UnSpawned += OnBoatUnSpawned;
    }

    private void OnDisable()
    {
        _pickUpSpawner.Spawned -= OnPickUpSpawned;
        _pickUpSpawner.UnSpawned -= OnPickUpUnspawned;
        _boatSpawner.Spawned -= OnBoatSpawned;
        _boatSpawner.UnSpawned -= OnBoatUnSpawned;
    }

    public void Create()
    {
        if (_activeSpline != null)
        {            
            _pickUpSpawner.UnSpawn();
            _boatSpawner.UnSpawn();
            _activeSpline.GetComponent<RoadBorders>().Destroy();
            Deleted?.Invoke(_unusedPickUps, _unusedBoats);
            ClearAllCollections();
        }

        _activeSpline = _splines.GetRandom();
        _activeSpline.GetComponent<RoadBorders>().Create();
        _pickUpSpawner.Spawn();
        _boatSpawner.Initialize(_activeSpline);
        _boatSpawner.Spawn();
        Created?.Invoke(_activeSpline, _pickUps, _boats);
    }

    private void OnPickUpSpawned(PickUp pickUp)
    {
        _pickUps.Add(pickUp);
    }

    private void OnPickUpUnspawned(PickUp pickUp)
    {
        _unusedPickUps.Add(pickUp);
    }

    private void OnBoatSpawned(Boat boat)
    {
        _boats.Add(boat);
    }

    private void OnBoatUnSpawned(Boat boat)
    {
        _unusedBoats.Add(boat);
    }

    private void ClearAllCollections()
    {
        _boats.Clear();
        _unusedBoats.Clear();
        _pickUps.Clear();
        _unusedPickUps.Clear();
    }
}
