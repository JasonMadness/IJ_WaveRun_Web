using UnityEngine;

public class PlayerScaler : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private Vector3 _scaleUpgrade;
    [SerializeField] private float _scaleUpdateSpeed;

    private Vector3 _defaultScale;
    private Vector3 _targetScale;

    private void Start()
    {
        _defaultScale = transform.localScale;
        _targetScale = transform.localScale;
    }

    public void IncreaseAllAxis()
    {
        _targetScale += _scaleUpgrade;
    }

    public void Reset()
    {
        transform.localScale = _defaultScale;
    }

    private void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, _targetScale, _scaleUpdateSpeed * Time.deltaTime);
    }
}
