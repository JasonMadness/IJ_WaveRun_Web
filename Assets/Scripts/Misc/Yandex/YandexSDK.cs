using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class YandexSDK : MonoBehaviour
{
    [SerializeField] private TotalScore _totalScore;
    
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
#if !UNITY_EDITOR
        yield return YandexGamesSdk.Initialize();
#endif
        yield return null;
    }

    public void ShowAd()
    {
        VideoAd.Show(onRewardedCallback: Reward);
    }

    private void Reward()
    {
        int bonusScore = _totalScore.BonusValue * 5;
        _totalScore.StartIncreasing(bonusScore);
    }
}
