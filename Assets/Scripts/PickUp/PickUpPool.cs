using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickUpPool : MonoBehaviour
{
    [SerializeField] private PickUp _prefab;
    
    private List<PickUp> _pool = new List<PickUp>();

    public void Initialize(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            CreatePickUp();
        }
    }

    public PickUp GetPickUp()
    {
        if (TryGetPickUp(out PickUp pickUp))
        {
            return pickUp;
        }
        else
        {
            CreatePickUp();
            return _pool.Last();
        }
    }

    private bool TryGetPickUp(out PickUp pickUp)
    {
        pickUp = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);
        return pickUp != null;
    }

    private void CreatePickUp()
    {
        PickUp pickUp = Instantiate(_prefab);
        pickUp.gameObject.SetActive(false);
        _pool.Add(pickUp);
    }
}
