using Agava.YandexGames;
using UnityEngine;

public class Advertaisment : MonoBehaviour
{
    [SerializeField] private Score _score;

    public void ShowAd()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;
        VideoAd.Show(onRewardedCallback: Reward, onCloseCallback: Close);
    }

    private void Reward()
    {
        _score.AddBonusScore();
    }

    private void Close()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }
}
