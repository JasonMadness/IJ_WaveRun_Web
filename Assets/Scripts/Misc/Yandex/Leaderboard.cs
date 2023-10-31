using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{  
    private const string ANONYMOUS_NAME = "Anonymous";
    private const string LEADERBOARD_NAME = "WaveRunLeaderboard";

    [SerializeField] private LeaderboardView _leaderboardView;

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new();

    public void SetPlayer(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
        {
            return;
        }

        Agava.YandexGames.Leaderboard.GetPlayerEntry(LEADERBOARD_NAME, _ => 
        {
            Agava.YandexGames.Leaderboard.SetScore(LEADERBOARD_NAME, score);
        });
    }

    private void Fill()
    {
        _leaderboardPlayers.Clear();

        if (PlayerAccount.IsAuthorized == false)
        {
            return;
        }

        Agava.YandexGames.Leaderboard.GetEntries(LEADERBOARD_NAME, onSuccessCallback: =>
        {

        })
    }

    public void OpenLeaderboard()
    {
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
        }
        else
        {
            return;
        }
    } 


}
