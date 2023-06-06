using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private GameObject _prefab;
    private List<GameObject> _pool = new();

    public void Initialize(GameObject prefab)
    {
        _prefab = prefab;
    }

    public GameObject GetGameObject()
    {
        GameObject result = _pool.FirstOrDefault(poolObject => poolObject.activeSelf == false);
        return result != null ? result : Create();
    }
    
    public List<GameObject> GetAllActive()
    {
        return _pool.Where(poolObject => poolObject.activeSelf).ToList();
    }

    private GameObject Create()
    {
        GameObject newObject = Instantiate(_prefab);
        newObject.SetActive(false);
        _pool.Add(newObject);
        newObject.transform.SetParent(transform);
        return newObject;
    }
}
