using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testing : MonoBehaviour
{
    public GameObject progress;
    public TotalScore score;
    public TMP_Text text;
    public TMP_Text addWatched;
    public TMP_Text adScore;

    public void activateUI()
    {
        progress.SetActive(!progress.activeSelf);
    }

    public void setWatched(string value)
    {
        addWatched.text = value;
    }

    public void setScore(string value)
    {
        adScore.text = value;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activateUI();
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            score.StartIncreasing(100);
        }

        text.text = score.BonusValue.ToString();
    }
}
