using PathCreation;
using PathCreation.Examples;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SplineFollower : MonoBehaviour
{
    [SerializeField] private HorizontalInput _horizontalInput;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _horizontalSpeed = 0.5f;
    [SerializeField] private float _startOffsetForTestingOnly = 0.01f;
    [SerializeField] private float _endingOffset = 0.1f;

    private Rigidbody _rigidbody;
    private PathCreator _spline;
    private Vector3 _horizontalPosition;
    private float _horizontalBounding;
    private bool _canMove = false;
    private float _input;
    private float _distanceTravelled;
    private float _currentDistance;
    private float _maxDistance;

    public event Action Finished;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(PathCreator spline)
    {
        _spline = spline;
        _horizontalBounding = _spline.GetComponent<RoadMeshCreator>().roadWidth / 1.5f;
        _input = 0.0f;
        _horizontalPosition = Vector3.zero;
        _distanceTravelled = _startOffsetForTestingOnly;
        _maxDistance = _spline.path.GetPointAtDistance(_spline.path.length - _endingOffset).z;
        _rigidbody.isKinematic = true;
        SetTransform();
    }

    public void AllowMovement()
    {
        _rigidbody.isKinematic = false;
        _canMove = true;
    }

    private void Move()
    {
        _distanceTravelled += _speed * Time.deltaTime;
        _currentDistance = _spline.path.GetPointAtDistance(_distanceTravelled).z;

        if (_currentDistance < _maxDistance)
        {
            _input += _horizontalInput.GetInput() * _horizontalSpeed * Time.deltaTime;
            _input = Mathf.Clamp(_input, -_horizontalBounding, _horizontalBounding);
            _horizontalPosition = Vector3.right * _input;
        }
        else
        {
            _canMove = false;
            _rigidbody.isKinematic = true;
            Finished?.Invoke();
        }

        SetTransform();
    }

    private void SetTransform()
    {
        transform.position = _spline.path.GetPointAtDistance(_distanceTravelled) + _horizontalPosition;
    }

    private void Update()
    {
        if (_canMove)
        {
            Move();
        }
    }
}
