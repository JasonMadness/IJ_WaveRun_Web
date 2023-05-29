using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

public class UILocalization : MonoBehaviour
{
    [SerializeField] LocalizedStringTable _stringTable;
    public LocalizedString[] locStr;
    
    private void Start()
    {
        GetWaveLocalizedName();
    }
    

    public string GetWaveLocalizedName()
    {
        StringTableEntry entry = null;
        StringTable table = _stringTable.GetTable();
        SharedTableData sharedData = table.SharedData;
        var x = sharedData.Entries[0];
        table.TryGetValue(0, out entry);
        Debug.Log(entry.GetLocalizedString());
        return entry.GetLocalizedString();
    }
}
