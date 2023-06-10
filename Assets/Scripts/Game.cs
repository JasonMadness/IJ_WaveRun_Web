using PathCreation;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Level _level;
    [SerializeField] private Difficulty _difficulty;
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private Score _score;
    [SerializeField] private TotalScore _totalScore;
    [SerializeField] private UI _ui;
    [SerializeField] private Audio _audio;
    [SerializeField] private Timer _startingTimer;
    [SerializeField] private Ending _ending;

    private void OnEnable()
    {
        _player.SplineEnded += BeginFinishCutscene;
        _level.Created += OnLevelCreated;
        _level.Deleted += OnLevelDeleted;
        _startingTimer.Stopped += OnStartingTimerStopped;
        _ending.GameEnded += _ui.OnGameEnded;
        _ending.GameEnded += OnGameEnded;
    }

    private void OnDisable()
    {
        _player.SplineEnded -= BeginFinishCutscene;
        _level.Created -= OnLevelCreated;
        _level.Deleted -= OnLevelDeleted;
        _startingTimer.Stopped -= OnStartingTimerStopped;
        _ending.GameEnded -= _ui.OnGameEnded;
        _ending.GameEnded -= OnGameEnded;
    }

    private void Start()
    {
        _ui.Initialize();
        _audio.PlayMainMenuTheme();
    }

    public void StartGame()
    {
        _level.Create(_difficulty.Value);
        _cameraSwitcher.SetStartingPriorities();
        _ui.DeactivateEndScreen();
        _ui.ResetProgress(_level.GetTotalPickUpsValue());
        _score.Reset(_difficulty.Value);
        _player.ResetScale();
        _startingTimer.Initialize();
    }

    private void OnLevelCreated(PathCreator spline, List<PickUp> pickUps, List<Boat> boats)
    {
        _player.Initialize(spline);

        foreach (PickUp pickUp in pickUps)
        {
            pickUp.PickedUp += _player.OnPickedUp;
            pickUp.PickedUp += _ui.OnPickedUp;
            pickUp.PickedUp += _score.OnPickedUp;
            pickUp.PickedUp += _audio.OnPickedUp;
        }            

        foreach (Boat boat in boats)
        {
            boat.Destroyed += _score.OnBoatDestroyed;
        }
    }

    private void OnLevelDeleted(List<PickUp> pickUps, List<Boat> boats)
    {
        foreach (PickUp pickUp in pickUps)
        {
            pickUp.PickedUp -= _player.OnPickedUp;
            pickUp.PickedUp -= _ui.OnPickedUp;
            pickUp.PickedUp -= _score.OnPickedUp;
            pickUp.PickedUp -= _audio.OnPickedUp;
        }            

        foreach (Boat boat in boats)
        {
            boat.Destroyed -= _score.OnBoatDestroyed;
        }
    }

    private void OnStartingTimerStopped()
    {
        _player.StartMovement();
        _ui.ShowProgressBar();
    }

    private void BeginFinishCutscene()
    {
        _ending.Initialize();
        _ui.HideProgressBar();
    }

    private void OnGameEnded()
    {
        _totalScore.StartIncreasing(_score.LevelScore);
    }
}