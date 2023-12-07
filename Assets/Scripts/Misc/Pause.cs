using Agava.WebUtility;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private Audio _audio;

    private bool _paused = false;
    private bool _buttonClicked = false;

    private void PauseGame()
    {
        Time.timeScale = 0;
        _audio.PauseMusic();
        _paused = true;
    }

    private void UnPause()
    {
        Time.timeScale = 1;
        _audio.UnPauseMusic();
        _paused = false;
        _buttonClicked = false;
    }

    public void OnPauseButtonClicked()
    {
        if (_paused && _buttonClicked)
        {
            UnPause();
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_paused == false)
            {
                PauseGame();
                _buttonClicked = true;
            }
            else
            {
                UnPause();
            }
        }
    }
}
