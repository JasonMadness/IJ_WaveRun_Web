using UnityEngine;
using UnityEngine.Localization;

public class LocalizationTables : MonoBehaviour
{
    [SerializeField] private LocalizedString[] _waveSize;

    public string GetWaveSize(int index)
    {
        return _waveSize[index].GetLocalizedString();
    }
}
