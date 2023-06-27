using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _text;

    private int _coefficient;

    public void OnFinishBoatDestroyed()
    {
        _coefficient++;
    }

    public void Reset()
    {
        _coefficient = 0;
    }
}
