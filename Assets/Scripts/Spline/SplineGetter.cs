using PathCreation;
using System.Collections.Generic;
using UnityEngine;

public class SplineGetter : MonoBehaviour
{
    [SerializeField] private List<PathCreator> _splines = new List<PathCreator>();

    private PathCreator _activeSpline = null;
    private int _activeSplineIndex = -1;

    public PathCreator GetRandomSpline()
    {
        DeactivateAllActiveSplines();
        _activeSpline = _splines[GetNewIndex()];
        _activeSpline.gameObject.SetActive(true);
        return _activeSpline;
    }

    private void DeactivateAllActiveSplines()
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
