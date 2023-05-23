using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private UIProgressGroup _progressgroup;

    public void OnPickedUp(PickUp pickUp)
    {
        _progressgroup.Increase(pickUp.Value);
        pickUp.PickedUp -= OnPickedUp;
    }
}
