using PathCreation;
using PathCreation.Examples;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{    
    [SerializeField] private Splines _splines;
    [SerializeField] private PickUpSpawner _pickUpSpawner;
    [SerializeField] private BoatSpawner _boatSpawner;
    [SerializeField] private Finish _finish;
    [SerializeField] private Bonus _bonus;

    private const string ROAD_MESH_HOLDER = "Road Mesh Holder";

    private PathCreator _activeSpline;
    private GameObject _roadMesh;
    private List<PickUp> _pickUps = new();
    private List<PickUp> _unusedPickUps = new();
    private List<Boat> _boats = new();
    private List<Boat> _finishBoats = new();
    private List<Boat> _unusedBoats = new();

    public event Action<PathCreator, List<PickUp>, List<Boat>, List<Boat>> Created;
    public event Action<List<PickUp>, List<Boat>> Deleted;

    private void OnEnable()
    {
        _pickUpSpawner.Spawned += OnPickUpSpawned;
        _pickUpSpawner.UnSpawned += OnPickUpUnspawned;
        _boatSpawner.Spawned += OnBoatSpawned;
        _boatSpawner.UnSpawned += OnBoatUnSpawned;
        _finish.FinishBoatsSpawned += OnFinishBoatsSpawned;
    }

    private void OnDisable()
    {
        _pickUpSpawner.Spawned -= OnPickUpSpawned;
        _pickUpSpawner.UnSpawned -= OnPickUpUnspawned;
        _boatSpawner.Spawned -= OnBoatSpawned;
        _boatSpawner.UnSpawned -= OnBoatUnSpawned;
        _finish.FinishBoatsSpawned -= OnFinishBoatsSpawned;
    }

    public void Create(int difficulty)
    {
        if (_activeSpline != null)
        {            
            _activeSpline.GetComponent<RoadBorders>().Destroy();            
            Destroy(_roadMesh.GetComponent<MeshCollider>());
            _pickUpSpawner.UnSpawn();
            _boatSpawner.UnSpawn();
            Deleted?.Invoke(_unusedPickUps, _unusedBoats);
            ClearAllCollections();
        }

        _activeSpline = _splines.GetRandom(difficulty);
        _activeSpline.GetComponent<RoadMeshCreator>().ForceMeshUpdate();
        _roadMesh = _activeSpline.transform.Find(ROAD_MESH_HOLDER).gameObject;
        _activeSpline.GetComponent<RoadBorders>().Create();
        _roadMesh.AddComponent<MeshCollider>();
        _pickUpSpawner.Initialize(_activeSpline);
        _boatSpawner.Initialize(_activeSpline);
        _finish.SpawnBoats();
        SubscribeBonus();
        _bonus.Reset();
        Created?.Invoke(_activeSpline, _pickUps, _boats, _finishBoats);
    }

    public float GetTotalPickUpsValue()
    {
        return _pickUpSpawner.PickUpsTotalValue;
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

    private void OnFinishBoatsSpawned(List<Boat> boats)
    {
        _finishBoats = boats;
    }

    private void SubscribeBonus()
    {
        foreach(Boat boat in _finishBoats)
            boat.GetComponent<FinishBonus>().Destroyed += _bonus.OnFinishBoatDestroyed;
    }

    private void ClearAllCollections()
    {
        _boats.Clear();
        _unusedBoats.Clear();
        _pickUps.Clear();
        _unusedPickUps.Clear();
    }
}
