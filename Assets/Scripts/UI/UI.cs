using System;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private UIProgressGroup _progressgroup;
    [SerializeField] private EndScreen _endScreen;

    internal void Initialize()
    {
        _mainMenu.gameObject.SetActive(true);
    }

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

    public void OnGameEnded()
    {
        _endScreen.gameObject.SetActive(true);
    }
}
