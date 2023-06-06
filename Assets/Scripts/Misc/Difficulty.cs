using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [SerializeField] private Difficulties _difficulties;

    private int _value;

    public int Value => _value;

    public void SetDifficuly(Difficulties difficulty)
    {
        _value = (int)difficulty;
    }
}

[System.Serializable]
public enum Difficulties
{
    EASY = 1, 
    MEDIUM = 2, 
    HARD = 3
}
