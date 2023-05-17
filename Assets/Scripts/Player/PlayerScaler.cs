using UnityEngine;

public class PlayerScaler : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private Vector3 _scaleUpgrade;
    [SerializeField] private float _scaleUpdateSpeed;

    private Vector3 _targetScale;

    private void Start()
    {
        _targetScale = transform.localScale;
    }

    public void IncreaseAllAxis()
    {
        _targetScale += _scaleUpgrade;
    }

    private void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, _targetScale, _scaleUpdateSpeed * Time.deltaTime);
    }
}
