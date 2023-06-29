using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _mainMenu;
    [SerializeField] private AudioSource _game;
    [SerializeField] private AudioSource _waterDrop;
    [SerializeField] private AudioSource _player;

    public void PlayMainMenuTheme()
    {
        _mainMenu.Play();
    }

    public void StopMainMenuTheme()
    {
        _mainMenu.Stop();
    }

    public void PlayGameTheme()
    {
        _game.Play();
    }

    public void PauseMusic()
    {
        _mainMenu.Pause();
        _game.Pause();        
        _player.Pause();    
    }

    public void UnPauseMusic()
    {
        _mainMenu.UnPause();
        _game.UnPause();
        _player.UnPause();
    }
    
    public void StopGameTheme()
    {
        _game.Stop();
    }

    public void OnPickedUp(PickUp pickUp)
    {
        _waterDrop.Play();
        pickUp.PickedUp -= OnPickedUp;
    }
}
