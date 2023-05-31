using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _drops;
    [SerializeField] private TMP_Text _boats;
    [SerializeField] private TMP_Text _score;

    private int _dropsCount;
    private int _boatsCount;
    private int _levelScore;
    private int _totalScore;

    public int LevelScore => _levelScore;

    public void Reset()
    {
        _dropsCount = 0;
        _boatsCount = 0;
        SetScore();
    }

    public void OnPickedUp(PickUp pickUp)
    {
        pickUp.PickedUp -= OnPickedUp;
        _dropsCount++;
        SetScore();
    }

    public void OnBoatDestroyed(Boat boat)
    {
        boat.Destroyed -= OnBoatDestroyed;
        _boatsCount++;
        SetScore();
    }

    private void SetScore()
    {
        _drops.text = _dropsCount.ToString();
        _boats.text = _boatsCount.ToString();
        _levelScore = _dropsCount * _boatsCount;
        _score.text = _levelScore.ToString();
    }

    public void AddToTotal(int score)
    {
        _totalScore += score;
    }
}
