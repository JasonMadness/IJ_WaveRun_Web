using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    [SerializeField] private bool x, y, z;

    private void Start()
    {
        if (x)
            Rotate(Vector3.right);
        if (y)
            Rotate(Vector3.up);
        if (z)
            Rotate(Vector3.forward);
    }

    private void Rotate(Vector3 direction)
    {
        transform.Rotate(direction, GetRandomAngle());
    }

    private float GetRandomAngle()
    {
        return Random.Range(0.0f, 360f);
    }
}
