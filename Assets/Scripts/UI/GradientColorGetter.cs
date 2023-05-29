using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientColorGetter : MonoBehaviour
{
    public Gradient _gradient;

    public void Initialize(List<Color> colors)
    {
        GradientColorKey[] colorKeys = new GradientColorKey[colors.Count];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1.0f;
        alphaKeys[0].time = 0.0f;
        alphaKeys[1].alpha = 1.0f;
        alphaKeys[1].time = 1.0f;

        for (int i = 0; i < colors.Count; i++)
        {
            colorKeys[i].color = colors[i];
            colorKeys[i].time = (1.0f / colors.Count) * i;
        }
        
        Gradient gradient = new Gradient();
        gradient.SetKeys(colorKeys, alphaKeys);
        _gradient = gradient;

        /*for (int i = 0; i < colors.Count - 1; i++)
        {
            GradientColorKey[] colorKeys = new GradientColorKey[2];
            colorKeys[0].color = colors[i];
            colorKeys[0].time = 0.0f;
            colorKeys[1].color = colors[i + 1];
            colorKeys[1].time = 1.0f;
            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
            alphaKeys[0].alpha = 1.0f;
            alphaKeys[0].time = 0.0f;
            alphaKeys[1].alpha = 1.0f;
            alphaKeys[1].time = 1.0f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(colorKeys, alphaKeys);
            _gradients.Add(gradient);
        }*/
    }

    public Color GetColor(float gradientTime)
    {
        return _gradient.Evaluate(gradientTime);
    }
}
