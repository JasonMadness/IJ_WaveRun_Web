using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _followingCamera;
    [SerializeField] private CinemachineVirtualCamera _endingCamera;

    private int _lowPriority = 5;
    private int _highPriority = 10;

    public void SetStartingPriorities()
    {
        _followingCamera.Priority = _highPriority;
        _endingCamera.Priority = _lowPriority;
    }

    public void SetEndingPriorities()
    {
        _followingCamera.Priority = _lowPriority;
        _endingCamera.Priority = _highPriority;
    }
}
