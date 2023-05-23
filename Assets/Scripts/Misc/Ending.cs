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

    private float _interpolateValue = 0;
    private bool _canMove = false;

    public void Initialize()
    {
        _cameraSwitcher.SwitchPriorities();
        _player.MoveToPosition(_start.position);
        _player.FinishedMoving += OnPlayerFinishedMoving;
    }

    private void OnDisable()
    {
        _player.FinishedMoving -= OnPlayerFinishedMoving;
    }

    private void OnPlayerFinishedMoving()
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
            }
        }
    }
}
