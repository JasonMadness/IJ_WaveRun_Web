using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class Advertisement : MonoBehaviour
{
    [SerializeField] private TotalScore _totalScore;
    public testing _testing;

    /*private void Start()
    {
        YandexGamesSdk.Initialize();
    }*/
    
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
    }

    public void ShowAd()
    {
        VideoAd.Show(onRewardedCallback: Reward);
    }

    private void Reward()
    {
        _testing.setWatched("!");
        int bonusScore = _totalScore.BonusValue * 5;
        _totalScore.StartIncreasing(bonusScore);
        _testing.setScore(bonusScore.ToString());
    }
}
