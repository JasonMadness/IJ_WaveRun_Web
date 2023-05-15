using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScaler : MonoBehaviour
{
    [SerializeField] private Vector3 _min;
    [SerializeField] private Vector3 _max;
    [SerializeField] private float _speed;

    private Vector3 _current;
    private Vector3 _target;
    private float _interpolateValue = 0;

    private void Start()
    {
        _current = _min;
        _target = _max;
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(_current, _target, _interpolateValue);
        _interpolateValue += _speed * Time.deltaTime;

        if (_interpolateValue >= 1)
        {
            Vector3 temp = _current;
            _current = _target;
            _target = temp;
            _interpolateValue = 0;
        }
    }
}
