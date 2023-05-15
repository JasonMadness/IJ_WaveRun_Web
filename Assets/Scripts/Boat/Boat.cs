using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private float _upOffset = 0.1f;
    [SerializeField] private float _sideOffset = 0.1f;

    public void SetLandTransform()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Physics.Raycast(ray, out RaycastHit hit);
        Vector3 upOffset = Vector3.up * _upOffset;
        Vector3 sideOffset = GetRandomSideOffset();
        transform.SetPositionAndRotation(hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
        transform.position += upOffset + sideOffset;
    }

    private Vector3 GetRandomSideOffset()
    {
        float sideOffset = Random.Range(-_sideOffset, _sideOffset);
        return Vector3.right * sideOffset;
    }
}
