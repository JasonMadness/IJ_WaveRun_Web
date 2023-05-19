using PathCreation;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SplineFollower _splineFollower;
    [SerializeField] private SplineGetter _splineGetter;
    [SerializeField] private PickUpSpawner _pickUpSpawner;
    [SerializeField] private BoatSpawner _boatSpawner;
    [SerializeField] private CameraSwitcher _cameraSwitcher;

    private void OnEnable()
    {
        _splineFollower.SplineEnded += BeginFinishCutscene;
    }

    private void OnDisable()
    {
        _splineFollower.SplineEnded -= BeginFinishCutscene;
    }

    private void Start()
    {
        InitializeSplines();
        InitializeSpawners();
        _splineFollower.AllowMovement();
    }

    private void InitializeSplines()
    {
        PathCreator spline = _splineGetter.GetRandomSpline();
        _splineFollower.Initialize(spline);
    }

    private void InitializeSpawners()
    {
        _pickUpSpawner.PickUpSpawned += OnPickUpSpawned;
        _pickUpSpawner.Instantiate();
        _boatSpawner.Instantiate();
    }

    private void OnPickUpSpawned(PickUp pickUp)
    {
        pickUp.PickedUp += _player.OnPickedUp;
    }

    private void BeginFinishCutscene()
    {
        _cameraSwitcher.SwitchPriorities();
        _splineFollower.Initialize(_splineGetter.FinishSpline);
        Vector3 temp = _splineGetter.FinishSplineStart;
        _player.MoveToPosition(temp);
    }
}
