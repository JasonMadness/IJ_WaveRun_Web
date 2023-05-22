using PathCreation;
using System;
using System.Collections;
using UnityEngine;

public class SplineFollower : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _horizontalSpeed = 0.5f;
    [SerializeField] private float _horizontalBounding = 0.25f;
    [SerializeField] private float _startDelay = 3.0f;
    [SerializeField] private float _startOffsetForTestingOnly = 0.01f;
    [SerializeField] private float _endingOffset = 0.1f;

    private bool _canMove = false;
    private PathCreator _spline;
    private Vector3 _horizontalPosition = Vector3.zero;
    private float _distanceTravelled;
    private float _currentDistance;
    private float _maxDistance;

    public event Action SplineEnded;

    public void Initialize(PathCreator spline)
    {
        _spline = spline;
        _distanceTravelled = 0.0f + _startOffsetForTestingOnly;
        _maxDistance = _spline.path.GetPointAtDistance(_spline.path.length - _endingOffset).z;
        this.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void AllowMovement()
    {
        SetTransform();
        StartCoroutine(Allow(_startDelay));
    }

    private IEnumerator Allow(float delay)
    {
        WaitForSeconds step = new WaitForSeconds(Time.fixedDeltaTime);

        while (delay > 0)
        {
            delay -= Time.fixedDeltaTime;
            yield return step;
        }

        this.GetComponent<Rigidbody>().isKinematic = false;
        _canMove = true;
    }

    private void Move()
    {
        _distanceTravelled += _speed * Time.deltaTime;
        _currentDistance = _spline.path.GetPointAtDistance(_distanceTravelled).z;

        if (_currentDistance < _maxDistance)
        {
            MoveHorizontal();
            SetTransform();
        }
        else
        {
            // костыль. переделать.
            _canMove = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
            SetTransform();
            //this.GetComponent<Rigidbody>().isKinematic = false;
            SplineEnded?.Invoke();
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
        if (_canMove)
        {
            Move();
        }
    }
}
