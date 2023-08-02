using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class Advertisement : MonoBehaviour
{
    [SerializeField] private TotalScore _totalScore;
    
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private void Start()
    {
#if !UNITY_EDITOR
        YandexGamesSdk.Initialize();
#endif
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
