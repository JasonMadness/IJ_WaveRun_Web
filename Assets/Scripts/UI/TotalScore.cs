using System.Collections;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private Leaderboard _leaderboard;
    [SerializeField] private TMP_Text _text;

    private IO_Score _io = new IO_Score();
    
    private int _score;
    private int _additionValue;
    private float _delayBeforeCalculations = 1.0f;
    private float _calculationTime = 0.8f;

    public int BonusValue;

    private void OnEnable()
    {
        _io.Load(out _score);          
        UpdateUI();
    }

    public void StartIncreasing(int value)
    {
        _io.Save(_score + value);
        _leaderboard.SetPlayer(_score + value);
        StartCoroutine(Increase(value));
    }

    private IEnumerator Increase(int value)
    {
        _additionValue = value;
        BonusValue = value;
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
