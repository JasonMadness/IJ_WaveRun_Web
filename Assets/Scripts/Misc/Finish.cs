using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints = new();
    [SerializeField] private Boat _prefab;

    public void SpawnBoats()
    {
        foreach(Transform point in _spawnPoints)
        {
            Boat boat = Instantiate(_prefab);
            boat.transform.SetParent(point);
            boat.transform.position = point.transform.position;
        }
    }
}
