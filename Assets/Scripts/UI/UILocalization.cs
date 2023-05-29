using UnityEngine;
using UnityEngine.Localization;

public class UILocalization : MonoBehaviour
{
    [SerializeField] private LocalizedString[] _waveSize;

    public string GetSizeString(int index)
    {
        return _waveSize[index].GetLocalizedString();
    }
}
