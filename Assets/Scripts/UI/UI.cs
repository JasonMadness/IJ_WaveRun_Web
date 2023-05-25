using System;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private UIProgressGroup _progressGroup;
    [SerializeField] private EndScreen _endScreen;

    internal void Initialize()
    {
        _mainMenu.gameObject.SetActive(true);
    }

    public void DeactivateEndScreen()
    {
        _endScreen.gameObject.SetActive(false);
    }

    public void OnPickedUp(PickUp pickUp)
    {
        _progressGroup.Increase(pickUp.Value);
        pickUp.PickedUp -= OnPickedUp;
    }

    public void ChangeProgressBarStatus(bool status)
    {
        if (status)
            _progressGroup.Show();
        else
            _progressGroup.Hide();
    }

    public void ResetProgress()
    {
        _progressGroup.ResetProgress();
    }

    public void OnGameEnded()
    {
        _endScreen.gameObject.SetActive(true);
    }
}
