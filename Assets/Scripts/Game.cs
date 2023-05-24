using PathCreation;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SplineGetter _splineGetter;
    [SerializeField] private PickUpSpawner _pickUpSpawner;
    [SerializeField] private BoatSpawner _boatSpawner;
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private UI _ui;
    [SerializeField] private Timer _startingTimer;
    [SerializeField] private Ending _ending;

    private void Start()
    {
        _ui.Initialize();
    }


    private void OnEnable()
    {
        _player.SplineEnded += BeginFinishCutscene;
        _startingTimer.Stopped += OnStartingTimerStopped;
        _ending.GameEnded += _ui.OnGameEnded;
    }

    private void OnDisable()
    {
        _player.SplineEnded -= BeginFinishCutscene;
        _startingTimer.Stopped -= OnStartingTimerStopped;
        _ending.GameEnded -= _ui.OnGameEnded;
    }

    public void StartNewGame()
    {
        InitializeSplines();
        InitializeSpawners();
        _cameraSwitcher.SetStartingPriorities();
        _startingTimer.Initialize();
    }

    private void InitializeSplines()
    {
        PathCreator spline = _splineGetter.GetRandomSpline();
        _player.InitializeSpline(spline);
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
        pickUp.PickedUp += _ui.OnPickedUp;
    }

    private void OnStartingTimerStopped()
    {
        _player.StartMovement();
        _ui.ChangeProgressBarStatus(true);
    }
    
    private void BeginFinishCutscene()
    {
        _ending.Initialize();
        _ui.ChangeProgressBarStatus(false);
    }
}
