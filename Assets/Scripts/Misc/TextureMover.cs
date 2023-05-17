using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureMover : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Vector2 _offset;

    private float _speed = 0.01f;

    private void Start()
    {
        _material.mainTextureOffset = Vector2.zero;
    }

    private void FixedUpdate()
    {
        _material.mainTextureOffset += _offset * _speed;
    }
}
