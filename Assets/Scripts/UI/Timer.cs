using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private List<Image> _images;

    private int _value = 4;
    private float _interval = 1.0f;
    private float _timer;
    private int _maxIndex;

    private void Start()
    {
        _maxIndex = _images.Count - 1;
        _timer = _interval;
        UpdateText();
    }

    public void Initialize(int delay)
    {
        _value = delay;
    }

    private void UpdateText() // удалить при первой воможности
    {
        _text.text = _value.ToString();
    }

    private void ShowImage(int index)
    {
        if (index < _maxIndex)
            _images[index].gameObject.SetActive(true);
    }

    private void DecreaseTimer()
    {
        _value--;
        UpdateText();
    }

    private void Update()
    {
        if (_value > 0)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0 && _value <= 0)
            {
                foreach (Image image in _images)
                {
                    image.gameObject.SetActive(false);
                }
            }

            if (_timer <= 0)
            {
                ShowImage(_value);
                DecreaseTimer();
                _timer = _interval;
            }
        }
    }
}
