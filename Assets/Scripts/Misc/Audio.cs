using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _mainMenu;
    [SerializeField] private AudioSource _game;

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
    
    public void StopGameTheme()
    {
        _game.Stop();
    }
}
