using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class Advertisement : MonoBehaviour
{
    [SerializeField] TotalScore _totalScore;

    private void Start()
    {
        YandexGamesSdk.Initialize();
    }

    /*private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
    }*/

    public void ShowAd()
    {
        VideoAd.Show();
        _totalScore.StartIncreasing(_totalScore.BonusValue * 5);
    }
}
