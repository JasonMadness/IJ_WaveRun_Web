using Agava.YandexGames;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{  
    private const string ANONYMOUS_NAME = "Anonymous";
    private const string LEADERBOARD_NAME = "WaveRunLeaderboard";

    [SerializeField] private GameObject _leaderboard;
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

        Agava.YandexGames.Leaderboard.GetEntries(LEADERBOARD_NAME, onSuccessCallback: result =>
        {
            for (int i = 0; i < result.entries.Length; i++)
            {
                int rank = result.entries[i].rank;
                string name = result.entries[i].player.publicName;
                int score = result.entries[i].score;

                if (String.IsNullOrEmpty(name))
                {
                    name = ANONYMOUS_NAME;
                }

                _leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));
            }

            _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
        });
    }

    public void OpenLeaderboard()
    {
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            _leaderboard.SetActive(true);
            Fill();
        }

        if (PlayerAccount.IsAuthorized == false)
        {
            return;
        }
    }
}
