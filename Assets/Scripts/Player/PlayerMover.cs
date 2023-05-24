using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _endingSpeed;

    private Rigidbody _rigidbody;

    public event Action Finished;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveToPosition(Vector3 targetPosition)
    {
        StartCoroutine(MoveSmoothly(transform.position, targetPosition));
    }

    private IEnumerator MoveSmoothly(Vector3 from, Vector3 to)
    {
        _rigidbody.isKinematic = true;
        float interpolateValue = 0;
        WaitForSeconds delay = new WaitForSeconds(Time.fixedDeltaTime / _endingSpeed);

        while (interpolateValue < 1)
        {
            transform.position = Vector3.Lerp(from, to, interpolateValue);
            interpolateValue += Time.deltaTime;
            yield return delay;
        }

        _rigidbody.isKinematic = false;
        Finished?.Invoke();
    }
}
