using PathCreation;
using System.Collections;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] private CameraSwitcher _cameraSwitcher;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;

    private float _interpolateValue = 0;
    private bool _canMove = false;

    public void Initialize()
    {
        _cameraSwitcher.SwitchPriorities();
        _player.MoveToPosition(_startPosition.position);
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        float t = 2;

        while (t > 0)
        {
            t -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        _player.GetComponent<Rigidbody>().isKinematic = false;

        _canMove = true;
    }

    private void Update()
    {
        if (_canMove)
        {
            _player.transform.position = Vector3.Lerp(_startPosition.position, _endPosition.position, _interpolateValue);
            _interpolateValue += Time.deltaTime * _speed;

            if (Mathf.Approximately(_player.transform.position.z, _endPosition.position.z))
            {
                _canMove = false;
            }
        }
    }
}
