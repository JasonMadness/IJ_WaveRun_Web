using System;
using System.Collections;
using Misc.Yandex;
using TMPro;
using UnityEngine;

public class EndingScore : MonoBehaviour
{
    [SerializeField] private Leaderboard _leaderboard;
    [SerializeField] private TMP_Text _text;

    private int _score;
    private int _additionValue;
    private float _delayBeforeCalculations = 1.0f;
    private float _calculationTime = 0.8f;

    public event Action<int> ScoreIncreasingCompleted; 

    public void StartIncreasing(int value)
    {
        StartCoroutine(Increase(value));
    }

    public void SetScore(int score)
    {
        _score = score;
    }

    private IEnumerator Increase(int value)
    {
        _additionValue = value;
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
        
        ScoreIncreasingCompleted?.Invoke(_score);
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