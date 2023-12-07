using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
    private bool isMuted = false;
    
    public void OnMuteButtonClick()
    {
       Mute();
    }
    
    private void Mute()
    {
        AudioListener.volume = isMuted ? 1 : 0;
        isMuted = !isMuted;
    }
}
