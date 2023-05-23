using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerScaler _scaler;
    [SerializeField] private float _speed;

    public event Action FinishedMoving; 

    public void OnPickedUp(PickUp pickUp)
    {
        _scaler.IncreaseAllAxis();
        pickUp.PickedUp -= OnPickedUp;
    }

    public void MoveToPosition(Vector3 targetPosition)
    {
        StartCoroutine(MoveSmoothly(transform.position, targetPosition));
    }

    private IEnumerator MoveSmoothly(Vector3 from, Vector3 to)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        float interpolateValue = 0;
        WaitForSeconds delay = new WaitForSeconds(Time.fixedDeltaTime / _speed);

        while (interpolateValue < 1)
        {
            transform.position = Vector3.Lerp(from, to, interpolateValue);
            interpolateValue += Time.deltaTime;
            yield return delay;
        }

        GetComponent<Rigidbody>().isKinematic = false;
        FinishedMoving?.Invoke();
    }
}
