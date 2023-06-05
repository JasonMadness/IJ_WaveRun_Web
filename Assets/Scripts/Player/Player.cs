using PathCreation;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private FinalMover _mover;
    [SerializeField] private Scaler _scaler;
    [SerializeField] private SplineFollower _splineFollower;
    [SerializeField] private Animator _modelAnimator;
    [SerializeField] private AudioSource _audio;

    private const string UP = "Up";
    private const string DOWN = "Down";
    
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
        _modelAnimator.SetTrigger(UP);
        _scaler.ExpandSides();
    }

    public void Initialize(PathCreator spline)
    {
        _splineFollower.Initialize(spline);
        _audio.Play();
    }

    public void ResetScale()
    {
        _scaler.Reset();
        _modelAnimator.SetTrigger(DOWN);
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
