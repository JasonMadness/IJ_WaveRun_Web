using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _followingCamera;
    [SerializeField] private CinemachineVirtualCamera _endingCamera;

    private int _lowPriority = 5;
    private int _highPriority = 10;

    private void Start()
    {
        SetStartingPriorities();
    }

    private void SetStartingPriorities()
    {
        _followingCamera.Priority = _highPriority;
        _endingCamera.Priority = _lowPriority;
    }

    public void SwitchPriorities()
    {
        if (_followingCamera.Priority > _endingCamera.Priority)
        {
            _followingCamera.Priority = _lowPriority;
            _endingCamera.Priority = _highPriority;
        }
        else
        {
            SetStartingPriorities();
        }
    }
}
