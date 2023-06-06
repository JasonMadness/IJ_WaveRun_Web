using PathCreation;
using PathCreation.Examples;
using System.Collections.Generic;
using UnityEngine;

public class Splines : MonoBehaviour
{
    [SerializeField] private List<SplineCollection> _splineCollections = new List<SplineCollection>();

    private int _activeCollectionIndex = 0;
    private float _defaultRoadWidth = 0.4f;

    public PathCreator GetRandom(int difficulty)
    {
        PathCreator spline = _splineCollections[_activeCollectionIndex].GetRandomSpline();
        spline.GetComponent<RoadMeshCreator>().roadWidth = _defaultRoadWidth * difficulty;
        return spline;
    }
}
