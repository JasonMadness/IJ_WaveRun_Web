using Agava.YandexGames;
using UnityEngine;

public class Advertaisment : MonoBehaviour
{
    [SerializeField] private TotalScore _totalScore;

    public void ShowAd()
    {
        Debug.Log("Ad open");
        Time.timeScale = 0;
        AudioListener.volume = 0;
        VideoAd.Show(onRewardedCallback: Reward, onCloseCallback: Close);
    }

    private void Reward()
    {
        Debug.Log("Reward method. Bonus value from totalscore: " + _totalScore.BonusValue);
        int bonusScore = _totalScore.BonusValue * 5;
        Debug.Log("total bonus value: " + bonusScore);
        _totalScore.StartIncreasing(bonusScore);
    }

    private void Close()
    {
        Debug.Log("Ad closed");
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }
}
