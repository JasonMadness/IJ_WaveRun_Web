using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class UIProgressGroup : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private Image _barFill;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private List<string> _waveSizes;
    [SerializeField] private List<Color> _colors;

    private int _index = 0;
    private int _maxIndex;

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
        _bar.value = 0;
        UpdateUI();
    }

    private void Start()
    {
        _maxIndex = _waveSizes.Count - 1;
        UpdateUI();
    }

    private void IncreaseIndex()
    {
        if (_index < _maxIndex)
            _index++;
    }

    private void SetColors()
    {
        _barFill.color = _colors[_index];
        _text.color = _colors[_index];
    }

    private void SetText()
    {
        _text.text = _waveSizes[_index];
        _text.text = LocalizationSettings.StringDatabase.GetLocalizedString("UI_Text", "Wave_Tiny");
    }

    private void UpdateUI()
    {
        SetColors();
        SetText();
    }

    public void Increase(float value)
    {
        _bar.value += value;
        _bar.value = MathF.Round(_bar.value, 4);

        if (_bar.value > 1)
            _bar.value = 1;

        float stage = 1.0f / (_maxIndex + 1);
        float currentStage = stage * (_index + 1);

        if (_bar.value >= currentStage)
        {
            IncreaseIndex();
            UpdateUI();
        }
    }
}
