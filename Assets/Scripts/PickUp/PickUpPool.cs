using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickUpPool : MonoBehaviour
{
    [SerializeField] private PickUp _prefab;

    private List<PickUp> _pool = new List<PickUp>();

    public event Action<PickUp> Created;

    public void Initialize(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            Create();
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
            Create();
            return _pool.Last();
        }
    }

    private bool TryGetPickUp(out PickUp pickUp)
    {
        pickUp = _pool.FirstOrDefault(pickUp => pickUp.gameObject.activeSelf == false);
        return pickUp != null;
    }

    private void Create()
    {
        PickUp pickUp = Instantiate(_prefab);
        pickUp.gameObject.SetActive(false);
        _pool.Add(pickUp);
        pickUp.transform.SetParent(transform);
        Created?.Invoke(pickUp);
    }
}