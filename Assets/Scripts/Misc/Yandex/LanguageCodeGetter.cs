using Agava.YandexGames;
using UnityEngine;

public class LanguageCodeGetter : MonoBehaviour
{
    [SerializeField] private Language _language;

    private void Start()
    {
        string languageCode = YandexGamesSdk.Environment.i18n.lang;

        switch (languageCode)
        {
            case "ru":
                _language.SetRussian();
                break;
            case "tr":
                _language.SetTurkish();
                break;
            default:
                _language.SetEnglish();
                break;
        }
    }
}