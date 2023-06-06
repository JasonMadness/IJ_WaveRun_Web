using System;
using System.Collections.Generic;
using System.Linq;
using PathCreation;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    [SerializeField] private BoatPool _pool;
    [SerializeField] private Transform _container;

    private List<BoatSpawnPoint> _spawnPoints;

    public event Action<Boat> Spawned;
    public event Action<Boat> UnSpawned;

    public void Initialize(PathCreator spline)
    {
        _spawnPoints = spline.GetComponentsInChildren<BoatSpawnPoint>().ToList();
    }

    public void Spawn()
    {
        foreach (BoatSpawnPoint spawnPoint in _spawnPoints)
        {
            Boat boat = CreateAndPlace(spawnPoint.transform);
            Spawned?.Invoke(boat);
        }
    }
    
    public void UnSpawn()
    {
        List<GameObject> activeBoats = _pool.GetAllActive();
        
        foreach (GameObject boat in activeBoats)
        {
            boat.SetActive(false);
            UnSpawned?.Invoke(boat.GetComponent<Boat>());
        }
    }

    private Boat CreateAndPlace(Transform point)
    {
        Boat boat = _pool.GetGameObject().GetComponent<Boat>();
        boat.transform.position = point.position;
        boat.transform.SetParent(point.transform);
        boat.Initialize(_container);
        boat.LandTransform();
        boat.gameObject.SetActive(true);
        return boat;
    }
}
