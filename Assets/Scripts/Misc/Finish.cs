using System.Collections.Generic;
using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints = new();
    [SerializeField] private Boat _prefab;

    public event Action<List<Boat>> FinishBoatsSpawned;

    public void SpawnBoats()
    {
        List<Boat> boats = new();

        foreach(Transform point in _spawnPoints)
        {
            Boat boat = Instantiate(_prefab);
            boat.transform.SetParent(point);
            boat.transform.position = point.transform.position;
            boats.Add(boat);
        }

        FinishBoatsSpawned?.Invoke(boats);
    }
}
