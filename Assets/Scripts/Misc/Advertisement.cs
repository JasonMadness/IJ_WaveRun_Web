using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class Advertisement : MonoBehaviour
{
    [SerializeField] private TotalScore _totalScore;
    public testing _testing;
    public TMPro.TMP_Text conTest;

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

        conTest.text += " Connected";
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
