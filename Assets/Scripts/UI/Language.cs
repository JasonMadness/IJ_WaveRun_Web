using UnityEngine;
using UnityEngine.Localization.Settings;

public class Language : MonoBehaviour
{
    private int _english = 0;
    private int _russian = 1;
    private int _turkish = 2;

    private void Set(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    public void SetEnglish()
    {
        Set(_english);
    }

    public void SetRussian()
    {
        Set(_russian);
    }

    public void SetTurkish()
    {
        Set(_turkish);
    }
}
