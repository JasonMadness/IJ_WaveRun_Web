using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class SplineCollection : MonoBehaviour
{
    [SerializeField] private List<PathCreator> _splines = new List<PathCreator>();
    
    private int _activeSplineIndex = -1;

    public PathCreator GetRandomSpline()
    {
        DeactivateAll();
        PathCreator spline = _splines[GetNewIndex()];
        spline.gameObject.SetActive(true);
        return spline;
    }    

    private void DeactivateAll()
    {
        foreach (PathCreator spline in _splines)
            spline.gameObject.SetActive(false);
    }

    private int GetNewIndex()
    {
        int index = GenerateRandomIndex();
        
        while (_activeSplineIndex == index)
            index = GenerateRandomIndex();

        _activeSplineIndex = index;
        return _activeSplineIndex;
    }

    private int GenerateRandomIndex()
    {
        return Random.Range(0, _splines.Count);
    }
}
