using UnityEngine;

public class IO_Score
{
    private const string SCORE = "Score";

    public void Save(int score)
    {
        PlayerPrefs.SetInt(SCORE, score);
    }

    public void Load(out int score)
    {
        if (PlayerPrefs.HasKey(SCORE))
        {
            score = PlayerPrefs.GetInt(SCORE);
            Debug.Log(SCORE + " loaded: " + score);
            
        }
        else
        {
            score = 0;
            Debug.Log("PlayerPrefs doesnt have entry: " + SCORE);
        }
    }
}
