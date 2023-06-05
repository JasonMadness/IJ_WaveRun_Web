using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickUpPool : MonoBehaviour
{
    [SerializeField] private PickUp _prefab;

    private List<PickUp> _pool = new List<PickUp>();

    public PickUp GetPickUp()
    {
        PickUp pickUp = _pool.FirstOrDefault(pickUp => pickUp.gameObject.activeSelf == false);
        return pickUp != null ? pickUp : Create();
    }

    public List<PickUp> GetAllActive()
    {
        return _pool.Where(pickUp => pickUp.gameObject.activeSelf).ToList();
    }

    private PickUp Create()
    {
        PickUp pickUp = Instantiate(_prefab);
        pickUp.gameObject.SetActive(false);
        _pool.Add(pickUp);
        pickUp.transform.SetParent(transform);
        return pickUp;
    }
}