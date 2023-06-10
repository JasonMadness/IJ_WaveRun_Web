using System.Collections;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private const string SCORE = "Score";
    
    private int _score;
    private int _additionValue;
    private float _delayBeforeCalculations = 1.0f;
    private float _calculationTime = 1.0f;

    private void Start()
    {
        if (PlayerPrefs.HasKey(SCORE))
            _score = PlayerPrefs.GetInt(SCORE);
        else
            _score = 0;
            
        UpdateUI();
    }

    public void StartIncreasing(int value)
    {
        StartCoroutine(Increase(value));
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
        
        PlayerPrefs.SetInt(SCORE, _score);
    }

    private void UpdateUI()
    {
        if (_additionValue > 0)
            _text.text = $"{_score} + <color=green>{_additionValue}</color>";
        else
            _text.text = _score.ToString();
    }
}
