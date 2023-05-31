using System;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _drops;
    [SerializeField] private TMP_Text _boats;
    [SerializeField] private TMP_Text _score;

    private int _dropsCount;
    private int _boatsCount;
    private int _totalScore;

    public void Reset()
    {
        _dropsCount = 0;
        _boatsCount = 0;
        SetScore();
    }

    public void OnPickedUp(PickUp pickUp)
    {
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
        _totalScore = _dropsCount * _boatsCount;
        _drops.text = _dropsCount.ToString();
        _boats.text = _boatsCount.ToString();
        _score.text = _totalScore.ToString();
    }
}
