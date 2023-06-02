using UnityEngine;

public class HorizontalInput : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private const string HORIZONTAL = "Horizontal";

    private float _touchPositionX;
    private float _horizontalInput;
    private float _halfOfScreen; 
    private float _halfOfPlayArea;

    private void Start()
    {
        _halfOfScreen = Screen.width / 2;
        _halfOfPlayArea = _mainCamera.pixelWidth / 2;
    }

    public float GetInput()
    {
        if (Input.GetMouseButton(0))
            _touchPositionX = Input.mousePosition.x;
        else if (Input.touchCount > 0)
            _touchPositionX = Input.GetTouch(0).position.x;
        else 
            _touchPositionX = _halfOfScreen;

        float horizontalInput = (_touchPositionX - _halfOfScreen) / _halfOfPlayArea + Input.GetAxisRaw(HORIZONTAL);
        return Mathf.Clamp(horizontalInput, -1.0f, 1.0f);
    }
}
