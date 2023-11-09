using System;
using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;

namespace Misc.Yandex
{
    public class Leaderboard : MonoBehaviour
    {
        private const string ANONYMOUS_NAME = "Anonymous";
        private const string LEADERBOARD_NAME = "WaveRunLeaderboard";

        [SerializeField] private GameObject _leaderboard;
        [SerializeField] private LeaderboardView _leaderboardView;

        private readonly List<LeaderboardPlayer> _leaderboardPlayers = new();

        private int _savedScore = 0;

        public void SetPlayer(int score)
        {
            if (PlayerAccount.IsAuthorized == false)
            {
                return;
            }

            Agava.YandexGames.Leaderboard.GetPlayerEntry(LEADERBOARD_NAME,
                result => { Agava.YandexGames.Leaderboard.SetScore(LEADERBOARD_NAME, score); });
        }

        public int GetPlayerScore()
        {
            Agava.YandexGames.Leaderboard.GetPlayerEntry(LEADERBOARD_NAME, result => _savedScore = result.score);
            return _savedScore;
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
                    string publicName = result.entries[i].player.publicName;
                    int score = result.entries[i].score;

                    if (string.IsNullOrEmpty(publicName))
                    {
                        publicName = ANONYMOUS_NAME;
                    }

                    _leaderboardPlayers.Add(new LeaderboardPlayer(rank, publicName, score));
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
}