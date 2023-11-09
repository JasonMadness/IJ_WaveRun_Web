using Agava.YandexGames;
using UnityEngine;

public class Advertaisment : MonoBehaviour
{
    [SerializeField] private TotalScore _totalScore;

    public void ShowAd()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;
        VideoAd.Show(onRewardedCallback: Reward, onCloseCallback: Close);
    }

    private void Reward()
    {
        int bonusScore = _totalScore.BonusValue * 5;
        _totalScore.StartIncreasing(bonusScore);
    }

    private void Close()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }
}
