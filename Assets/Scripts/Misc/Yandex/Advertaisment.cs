using Agava.YandexGames;
using UnityEngine;

public class Advertaisment : MonoBehaviour
{
    [SerializeField] private TotalScore _totalScore;

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
