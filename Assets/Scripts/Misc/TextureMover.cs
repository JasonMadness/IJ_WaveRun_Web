using UnityEngine;

public class TextureMover : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Vector2 _offset;

    private float _speed = 0.01f;

    private void FixedUpdate()
    {
        _material.mainTextureOffset += _offset * _speed;
    }

    private void OnDisable()
    {
        _material.mainTextureOffset = Vector2.zero;
    }
}
