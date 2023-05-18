using PathCreation;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SplineFollower _splineFollower;
    [SerializeField] private SplineGetter _splineGetter;
    [SerializeField] private PickUpSpawner _pickUpSpawner;
    [SerializeField] private BoatSpawner _boatSpawner;

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
    }

    private void InitializeSplines()
    {
        PathCreator spline = _splineGetter.GetRandomSpline();
        PathCreator finishSpline = _splineGetter.FinishSpline;
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
        Debug.Log("Player finished");
    }
}
