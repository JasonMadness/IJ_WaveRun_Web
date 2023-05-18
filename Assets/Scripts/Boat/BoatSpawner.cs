using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private Boat _boat;

    public void Instantiate()
    {
        foreach (Transform spawnPoint in _spawnPoints)
        {
            Boat boat = Instantiate(_boat);
            boat.transform.position = spawnPoint.position;
            boat.transform.SetParent(spawnPoint.transform);
            boat.SetLandTransform();
        }
    }
}
