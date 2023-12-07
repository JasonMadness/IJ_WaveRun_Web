using Misc.Yandex;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private LevelScore _levelScore;
    [SerializeField] private EndingScore _endingScore;
    [SerializeField] private Leaderboard _leaderboard;

    private IO_Score _ioScore = new();
    private int _score;
    private int _scoreAtTheEndOfLevel;

    private void OnEnable()
    {
        _leaderboard.PlayerScoreGet += OnPlayerWebScoreLoaded;
        _endingScore.ScoreIncreasingCompleted += OnScoreIncreasingCompleted;
    }

    private void OnDisable()
    {
        _leaderboard.PlayerScoreGet -= OnPlayerWebScoreLoaded;
        _endingScore.ScoreIncreasingCompleted -= OnScoreIncreasingCompleted;
    }

    private void Start()
    {
        _ioScore.Load(out _score);
    }

    private void OnPlayerWebScoreLoaded(int score)
    {
        if (_score < score)
        {
            _score = score;
            _ioScore.Save(_score);
        }
        
        _endingScore.SetScore(_score);
    }

    public void StartEnding()
    {
        _scoreAtTheEndOfLevel = _levelScore.Score;
        _endingScore.StartIncreasing(_scoreAtTheEndOfLevel);
    }

    public void AddBonusScore()
    {
        int bonusScore = _scoreAtTheEndOfLevel * 5;
        _endingScore.StartIncreasing(bonusScore);
    }

    private void OnScoreIncreasingCompleted(int score)
    {
        _score = score;
        _ioScore.Save(_score);
        _leaderboard.SetPlayer(_score);
    }
}
