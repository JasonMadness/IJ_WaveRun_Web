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
    public int TotalScoreScore => _score;

    private float cntdwn = 5f;

    private void Start()
    {
        _leaderboard.PlayerScoreGet += OnPlayerScoreGet;
    }

    private void OnPlayerScoreGet(int score)
    {
        SetScore(score);
        Debug.Log(score);
    }

    public void SetScore(int score)
    {
        Debug.Log("Method 'Set Score' in class 'Total Score'");
        Debug.Log("Current score: " + _score);
        Debug.Log("DI score: " + score);
        Debug.Log("if " + _score + "<" + score);
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
        OnBonusValueChange();
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

    private void OnBonusValueChange()
    {
        Debug.Log("Bonus value changed to: " + _bonusValue);
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

    private void Update()
    {
        cntdwn -= Time.deltaTime;
        if (cntdwn < 0)
        {
            Debug.Log("Countdown ended. TotalScore is: " + _score);
            cntdwn = 5f;
        }
    }
}