using PathCreation;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private SplineFollower _player;
    [SerializeField] private SplineGetter _splineGetter;
    [SerializeField] private PickUpSpawner _pickUpSpawner;
    [SerializeField] private BoatSpawner _boatSpawner;

    private void Start()
    {
        InitializeSpline();
    }

    public void InitializeSpline()
    {
        PathCreator spline = _splineGetter.GetRandomSpline();
        PathCreator finishSpline = _splineGetter.FinishSpline;
        _player.Init(spline, finishSpline);
        _pickUpSpawner.Instantiate();
        _boatSpawner.Instantiate();
    }
}
