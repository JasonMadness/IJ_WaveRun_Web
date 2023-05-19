using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerScaler _scaler;
    [SerializeField] private float _speed;

    public void OnPickedUp(PickUp pickUp)
    {
        _scaler.IncreaseAllAxis();
        pickUp.PickedUp -= OnPickedUp;
    }

    public void MoveToPosition(Vector3 targetPosition)
    {
        StartCoroutine(MoveSmootly(transform.position, targetPosition));
    }

    private IEnumerator MoveSmootly(Vector3 from, Vector3 to)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        float interpolateValue = 0;
        WaitForSeconds delay = new WaitForSeconds(Time.fixedDeltaTime / _speed);

        while (interpolateValue < 1)
        {
            transform.position = Vector3.Lerp(from, to, interpolateValue);
            //transform.position = new Vector3
            //    (Mathf.Lerp(from.x, to.x, interpolateValue),
            //    transform.position.y, 
            //    Mathf.Lerp(from.z, to.z, interpolateValue));
            interpolateValue += Time.deltaTime;
            yield return delay;
        }

        GetComponent<Rigidbody>().isKinematic = false;
    }
}
