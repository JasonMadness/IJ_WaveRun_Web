using PathCreation;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerScaler _scaler;
    [SerializeField] private SplineFollower _splineFollower;

    public event Action SplineEnded;
    public event Action LevelEnded;

    private void OnEnable()
    {
        _mover.Finished += OnFinishedMoving;
        _splineFollower.Finished += OnSplineFinished;
    }

    private void OnDisable()
    {
        _mover.Finished -= OnFinishedMoving;
        _splineFollower.Finished -= OnSplineFinished;
    }

    private void OnFinishedMoving()
    {
        LevelEnded?.Invoke();
    }

    private void OnSplineFinished()
    {
        SplineEnded?.Invoke();
    }

    public void Initialize(PathCreator spline)
    {
        _splineFollower.Initialize(spline);
    }

    public void ResetScale()
    {
        _scaler.Reset();
    }

    public void StartMovement()
    {
        _splineFollower.AllowMovement();
    }

    public void MoveToEndingPosition(Vector3 targetPosition)
    {
        _mover.MoveToPosition(targetPosition);
    }

    public void OnPickedUp(PickUp pickUp)
    {
        _scaler.IncreaseAllAxis();
        pickUp.PickedUp -= OnPickedUp;
    }
}
