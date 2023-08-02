using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private Audio _audio;

    private bool _paused = false;
    private bool _buttonClicked = false;

    public void PauseGame()
    {
        Time.timeScale = 0;
        _audio.PauseMusic();
        _paused = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        _audio.UnPauseMusic();
        _paused = false;
    }

    public void OnPauseButtonClicked()
    {
        if (_paused && _buttonClicked)
        {
            UnPause();
            _buttonClicked = false;
        }
        else
        {
            PauseGame();
            _buttonClicked = true;
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus == false)
        {
            PauseGame();
        }
        else if (_buttonClicked == false)
        {
            UnPause();
        }
    }
}
