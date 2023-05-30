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
        _pickUpSpawner.Spawned += OnPickUpSpawned;
        _pickUpSpawner.UnSpawned += OnPickUpUnSpawned;
        _ending.GameEnded += _ui.OnGameEnded;
    }

    private void OnDisable()
    {
        _player.SplineEnded -= BeginFinishCutscene;
        _startingTimer.Stopped -= OnStartingTimerStopped;
        _pickUpSpawner.Spawned -= OnPickUpSpawned;
        _pickUpSpawner.UnSpawned -= OnPickUpUnSpawned;
        _ending.GameEnded -= _ui.OnGameEnded;
    }

    public void StartNewGame()
    {
        InitializeSpline();
        InitializeSpawners();
        _ui.ResetProgress();
        _cameraSwitcher.SetStartingPriorities();
        _startingTimer.Initialize();
    }

    public void StartNextLevel()
    {
        _cameraSwitcher.SetStartingPriorities();
        _pickUpSpawner.UnSpawn();
        InitializeSpline();
        InitializeSpawners();
        _ui.DeactivateEndScreen();
        _ui.ResetProgress();
        _player.ResetScale();
        _startingTimer.Initialize();
    }

    private void InitializeSpline()
    {
        PathCreator spline = _splineGetter.GetRandomSpline();
        _player.Initialize(spline);
    }

    private void InitializeSpawners()
    {
        _pickUpSpawner.Spawn();
        _boatSpawner.Instantiate();
    }

    private void OnPickUpSpawned(PickUp pickUp)
    {
        pickUp.PickedUp += _player.OnPickedUp;
        pickUp.PickedUp += _ui.OnPickedUp;
    }

    private void OnPickUpUnSpawned(PickUp pickUp)
    {
        pickUp.PickedUp -= _player.OnPickedUp;
        pickUp.PickedUp -= _ui.OnPickedUp;
    }

    private void OnStartingTimerStopped()
    {
        _player.StartMovement();
        _ui.SetProgressBarActive(true);
    }

    private void BeginFinishCutscene()
    {
        _pickUpSpawner.UnSpawn();
        _ending.Initialize();
        _ui.SetProgressBarActive(false);
    }
}