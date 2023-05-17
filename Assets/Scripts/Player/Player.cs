using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerScaler _scaler;

    public void OnPickedUp(PickUp pickUp)
    {
        _scaler.IncreaseAllAxis();
        pickUp.PickedUp -= OnPickedUp;
    }
}
