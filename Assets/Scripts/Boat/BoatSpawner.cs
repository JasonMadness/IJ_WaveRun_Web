using System;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private List<Transform> _finishSpawnPoints = new List<Transform>();
    [SerializeField] private Boat _boat;
    [SerializeField] private Boat _staticBoat;

    public event Action<Boat> Spawned;

    public void Instantiate()
    {
        foreach (Transform point in _spawnPoints)
        {
            Boat boat = CreateAndPlace(point, _boat);
            Spawned?.Invoke(boat);
        }

        foreach (Transform point in _finishSpawnPoints)
        {
            CreateAndPlace(point, _staticBoat);
        }
    }

    private Boat CreateAndPlace(Transform point, Boat boat)
    {
        Boat newBoat = Instantiate(boat);
        newBoat.transform.position = point.position;
        newBoat.transform.SetParent(point.transform);
        newBoat.SetLandTransform();
        return newBoat;
    }
}
