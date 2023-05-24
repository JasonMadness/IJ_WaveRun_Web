using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private List<Image> _images;
    [SerializeField] private Animation _animation;
    [SerializeField] private int _timeBeforeStart = 4;

    private float _interval = 1.0f;
    private int _timeLeft;
    private float _timer;
    private int _maxIndex;

    public event Action Stopped;

    private void Start()
    {
        DeactivateAllImages();
        _maxIndex = _images.Count - 1;
        _timer = _interval;
    }

    public void Initialize()
    {
        _timeLeft = _timeBeforeStart;
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
        _timeLeft--;

        if (_timeLeft == 0)
        {
            Stopped?.Invoke();
        }
    }

    private void Update()
    {
        if (_timeLeft > 0)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                DeactivateAllImages();
                DecreaseTimer();
                ShowImage(_timeLeft);
                _animation.Play();
                _timer = _interval;
            }
        }
    }
}