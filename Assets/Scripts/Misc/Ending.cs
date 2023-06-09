using System;
using System.Collections;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _delayBeforeCutscene = 2.0f;

    private float _interpolateValue;
    private bool _canMove = false;

    public event Action GameEnded;

    public void Initialize()
    {
        _cameraSwitcher.SetEndingPriorities();
        _interpolateValue = 0.0f;
        _player.MoveToEndingPosition(_start.position);
        _player.LevelEnded += OnPlayerEndLevel;
    }

    private void OnDisable()
    {
        _player.LevelEnded -= OnPlayerEndLevel;
    }

    private void OnPlayerEndLevel()
    {
        StartCoroutine(BeginCutscene());
    }

    private IEnumerator BeginCutscene()
    {
        yield return new WaitForSeconds(_delayBeforeCutscene);
        _canMove = true;
    }

    private void Update()
    {
        if (_canMove)
        {
            _player.transform.position = Vector3.Lerp(_start.position, _end.position, _interpolateValue);
            _interpolateValue += Time.deltaTime * _speed;

            if (Mathf.Approximately(_player.transform.position.z, _end.position.z))
            {
                _canMove = false;
                GameEnded?.Invoke();
                _player.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}
