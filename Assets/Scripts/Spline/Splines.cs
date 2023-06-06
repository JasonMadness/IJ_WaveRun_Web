using PathCreation;
using System.Collections.Generic;
using UnityEngine;

public class Splines : MonoBehaviour
{
    [SerializeField] private List<SplineCollection> _splineCollections = new List<SplineCollection>();

    private int _activeCollectionIndex = 0;

    public PathCreator GetRandom()
    {
        return _splineCollections[_activeCollectionIndex].GetRandomSpline();
    }
}
