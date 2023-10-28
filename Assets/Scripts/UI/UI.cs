using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private ProgressGroup _progressGroup;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private Button _bonusButton;

    public void Initialize()
    {
        _mainMenu.gameObject.SetActive(true);
    }

    public void ResetEndScreen()
    {
        _bonusButton.gameObject.SetActive(true);
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

    public void ResetProgress(float maxProgress)
    {
        _progressGroup.ResetProgress(maxProgress);
    }

    public void OnGameEnded()
    {
        _endScreen.gameObject.SetActive(true);
        _endScreen.Reveal();
    }
}
