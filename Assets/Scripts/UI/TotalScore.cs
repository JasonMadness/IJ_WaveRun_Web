using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    private int _score;
    private int _additionValue;

    public void StartIncreasing(int value)
    {
        StartCoroutine(Increase(value));
    }

    private IEnumerator Increase(int value)
    {
        _additionValue = value;
        UpdateUI();
        yield return new WaitForSeconds(1);
        WaitForSeconds delay = new WaitForSeconds(2.0f / _additionValue);

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
        if (_additionValue > 0)
            _text.text = $"{_score} + {_additionValue}";
        else
            _text.text = _score.ToString();
    }
}
