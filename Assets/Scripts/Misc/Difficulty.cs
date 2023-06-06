using UnityEngine;

public class Difficulty : MonoBehaviour
{
    private int _value = 1;

    public int Value => _value;

    public void SetEasy()
    {
        _value = 1;
    }

    public void SetMedium()
    {
        _value = 2;
    }

    public void SetHard()
    {
        _value = 3;
    }
}
