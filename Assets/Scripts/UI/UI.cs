using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private UIProgressGroup _progressgroup;

    public void OnPickedUp(PickUp pickUp)
    {
        _progressgroup.Increase(pickUp.Value);
        pickUp.PickedUp -= OnPickedUp;
    }

    public void ChangeProgressBarStatus(bool status)
    {
        if (status)
            _progressgroup.Reveal();
        else
            _progressgroup.Hide();
    }
}
