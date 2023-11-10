using System;
using System.Collections;
using Misc.Yandex;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private Leaderboard _leaderboard;
    [SerializeField] private TMP_Text _text;

    private int _score;
    private int _additionValue;
    private float _delayBeforeCalculations = 1.0f;
    private float _calculationTime = 0.8f;

    private int _bonusValue;
    public int BonusValue => _bonusValue;

    public void SetScore(int score)
    {
        if (_score < score)
        {
            _score = score;
        }
    }

    public void StartIncreasing(int value)
    {
        Debug.Log("Current score: " + _score);
        Debug.Log("Additional score: " + value);
        _leaderboard.SetPlayer(_score + value);
        StartCoroutine(Increase(value));
    }

    private IEnumerator Increase(int value)
    {
        _additionValue = value;
        _bonusValue = value;
        UpdateUI();
        yield return new WaitForSeconds(_delayBeforeCalculations);
        WaitForSeconds delay = new WaitForSeconds(_calculationTime / _additionValue);

        while (_additionValue > 0)
        {
            _score++;
            _additionValue--;
            UpdateUI();
            yield return delay;
        }
    }

    private void UpdateUI()
    {
        if (_text.gameObject.activeSelf)
        {
            if (_additionValue > 0)
                _text.text = $"{_score} + <color=green>{_additionValue}</color>";
            else
                _text.text = _score.ToString();
        }
    }
}