using Agava.YandexGames;
using UnityEngine;

public class Advertaisment : MonoBehaviour
{
    [SerializeField] private Score _score;

    public void ShowAd()
    {
        VideoAd.Show(OnOpenCallback, OnRewardedCallback, OnCloseCallback);
    }

    private void OnOpenCallback()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;
    }

    private void OnRewardedCallback()
    {
        _score.AddBonusScore();
    }

    private void OnCloseCallback()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }
}
