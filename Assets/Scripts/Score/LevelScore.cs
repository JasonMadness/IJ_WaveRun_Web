using TMPro;
using UnityEngine;

public class LevelScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _drops;
    [SerializeField] private TMP_Text _boats;
    [SerializeField] private TMP_Text _score;

    private int _dropsCount;
    private int _boatsCount;
    private int _levelScore;
    private int _difficulty;

    public int Score => _levelScore;

    public void Reset(int difficulty)
    {
        _dropsCount = 0;
        _boatsCount = 0;
        _difficulty = difficulty;
        UpdateUI();
    }

    public void OnPickedUp(PickUp pickUp)
    {
        pickUp.PickedUp -= OnPickedUp;
        _dropsCount++;
        UpdateUI();
    }

    public void OnBoatDestroyed(Boat boat)
    {
        boat.Destroyed -= OnBoatDestroyed;
        _boatsCount++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _drops.text = _dropsCount.ToString();
        _boats.text = _boatsCount.ToString();
        _levelScore = _dropsCount * _boatsCount * _difficulty;
        _score.text = _levelScore.ToString();
    }
}
