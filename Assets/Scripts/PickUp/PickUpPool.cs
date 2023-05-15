using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpPool : MonoBehaviour
{
    [SerializeField] private PickUp _prefab;
    
    private List<PickUp> _pool = new List<PickUp>();

    public void Initialize(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            PickUp pickUp = Instantiate(_prefab);
            pickUp.gameObject.SetActive(false);
            _pool.Add(pickUp);
        }
    }

    public PickUp GetPickUp()
    {
        
    }

    private bool TryGetPickUp(out PickUp pickUp)
    {
        PickUp pickUpToGet = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);
    }
}
