using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class SplineFollower : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _horizontalSpeed = 0.5f;
    [SerializeField] private float _horizontalBounding = 0.25f;
    [SerializeField] private float _endingOffset = 0.1f;

    private PathCreator _spline;
    private PathCreator _finishSpline;
    private Vector3 _horizontalPosition = Vector3.zero;
    private float _distanceTravelled;
    private float _currentDistance;
    private float _maxDistance;

    public void Init(PathCreator spline, PathCreator finishSpline)
    {
        _spline = spline;
        _finishSpline = finishSpline;
        _distanceTravelled = 0.0f;
        _maxDistance = _spline.path.GetPointAtDistance(_spline.path.length - _endingOffset).z;
        SetTransform();
    }

    private void Move()
    {
        _currentDistance = _spline.path.GetPointAtDistance(_distanceTravelled).z;

        if (_currentDistance < _maxDistance)
        {
            _distanceTravelled += _speed * Time.deltaTime;
            MoveHorizontal();
            SetTransform();
        }
    }

    private void MoveHorizontal()
    {
        if (Input.GetKey(KeyCode.A))
            _horizontalPosition += _horizontalSpeed * Time.deltaTime * Vector3.left;

        if (Input.GetKey(KeyCode.D))
            _horizontalPosition += _horizontalSpeed * Time.deltaTime * Vector3.right;

        ClampHorizontalPosition();
    }

    private void ClampHorizontalPosition()
    {
        if (_horizontalPosition.x > _horizontalBounding)
            _horizontalPosition = new Vector3(_horizontalBounding, 0.0f, 0.0f);

        if (_horizontalPosition.x < -_horizontalBounding)
            _horizontalPosition = new Vector3(-_horizontalBounding, 0.0f, 0.0f);
    }

    private void SetTransform()
    {
        transform.position = _spline.path.GetPointAtDistance(_distanceTravelled) + _horizontalPosition;
    }

    private void Update()
    {
        Move();
    }
}
