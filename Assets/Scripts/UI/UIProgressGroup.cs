using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProgressGroup : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private Image _barFill;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private List<string> _waveSizes;
    [SerializeField] private List<Color> _colors;
    [SerializeField] private GradientColorGetter _colorGetter;
    [SerializeField] [Range(0.0f, 1.0f)] private float _updateSpeed;
    [SerializeField] private UILocalization _localization;

    private int _index = 0;
    private int _maxIndex;
    private float _targetValue = 0.0f;
    private bool _needToUpdate = false;

    public void Show()
    {
        GetComponent<Animator>().SetTrigger("Show");
    }

    public void Hide()
    {
        GetComponent<Animator>().SetTrigger("Hide");
    }

    public void ResetProgress()
    {
        _index = 0;
        _bar.value = 0.0f;
        _targetValue = 0.0f;
        _needToUpdate = false;
        UpdateUI();
    }

    private void Start()
    {
        _maxIndex = _waveSizes.Count - 1;
        _colorGetter.Initialize(_colors);
        UpdateUI();
    }

    private void IncreaseIndex()
    {
        if (_index < _maxIndex)
            _index++;
    }

    private void SetColors()
    {
        //_barFill.color = _colors[_index];
        //_text.color = _colors[_index];
        _barFill.color = _colorGetter.GetColor(_bar.value);
        _text.color = _colorGetter.GetColor(_bar.value);
    }

    private void SetText()
    {
        _text.text = _waveSizes[_index];
        _text.text = _localization.GetSizeString(_index);
    }

    private void UpdateUI()
    {
        SetColors();
        SetText();
    }

    public void Increase(float value)
    {
        if (_targetValue < 1)
        {
            _targetValue += value;

            if (_targetValue > 1)
                _targetValue = 1;

            _targetValue = MathF.Round(_targetValue, 4);
            _needToUpdate = true;
        }
    }

    private void Update()
    {
        if (_needToUpdate)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, _targetValue, Time.deltaTime * _updateSpeed);
            _bar.value = MathF.Round(_bar.value, 4);

            if (_bar.value >= _targetValue)
            {
                _needToUpdate = false;
            }

            float stage = 1.0f / (_maxIndex + 1);
            float currentStage = stage * (_index + 1);

            if (_bar.value >= currentStage)
            {
                IncreaseIndex();
            }
            
            UpdateUI();
        }
    }
}