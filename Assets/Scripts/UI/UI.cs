using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private ProgressGroup _progressGroup;
    [SerializeField] private EndScreen _endScreen;

    public void Initialize()
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

    public void ShowProgressBar()
    {
        _progressGroup.Show();
    }

    public void HideProgressBar()
    {
        _progressGroup.Hide();
    }

    public void ResetProgress()
    {
        _progressGroup.ResetProgress();
    }

    public void OnGameEnded()
    {
        _endScreen.gameObject.SetActive(true);
        _endScreen.Reveal();
    }
}
