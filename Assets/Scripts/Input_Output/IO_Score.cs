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
            score = PlayerPrefs.GetInt(SCORE);
        else
            score = 0;
    }

    public void Reset()
    {
        PlayerPrefs.SetInt(SCORE, 0);
    }
}
