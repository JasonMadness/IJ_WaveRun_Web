using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private List<Image> _images;
    [SerializeField] private Animation _animation;
    [SerializeField] private int _value = 4;

    private float _interval = 1.0f;
    private float _timer;
    private int _maxIndex;

    public event Action Stopped;

    private void Start()
    {
        DeactivateAllImages();
        _maxIndex = _images.Count - 1;
        _timer = _interval;
    }

    public void Initialize(int delay)
    {
        _value = delay;
    }

    private void ShowImage(int index)
    {
        if (index <= _maxIndex)
            _images[index].gameObject.SetActive(true);
    }

    private void DeactivateAllImages()
    {
        foreach (Image image in _images)
        {
            image.gameObject.SetActive(false);
        }
    }

    private void DecreaseTimer()
    {
        _value--;

        if (_value == 0)
        {
            Stopped?.Invoke();
        }
    }

    private void Update()
    {
        if (_value > 0)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                DeactivateAllImages();
                DecreaseTimer();
                ShowImage(_value);
                _animation.Play();
                _timer = _interval;
            }
        }
    }
}