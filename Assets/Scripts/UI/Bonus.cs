using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Animation _animation;

    private int _coefficient;

    public void OnFinishBoatDestroyed()
    {
        if (_text.gameObject.activeSelf == false)
        {            
            _icon.gameObject.SetActive(true);
            _text.gameObject.SetActive(true);
        }
        
        _coefficient++;
        _text.text = "x" + _coefficient;
        _animation.Play();
    }

    public void Reset()
    {
        _coefficient = 0;
        _icon.gameObject.SetActive(false);
        _text.gameObject.SetActive(false);
    }
}
