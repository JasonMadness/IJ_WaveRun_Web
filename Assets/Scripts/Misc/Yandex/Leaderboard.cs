using System;
using System.Collections;
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
        [SerializeField] private TotalScore _totalScore;
        [SerializeField] private LeaderboardView _leaderboardView;
        [SerializeField] private LeadeboardList _leaderboardList;

        private List<LeaderboardPlayer> _leaderboardPlayers = new();
        private LeaderboardPlayer _player;

        private int _savedScore = 0;
        private float _counter = 5;

        public int SavedScore;

        public void SetPlayer(int score)
        {
            if (PlayerAccount.IsAuthorized == false)
            {
                return;
            }

            Agava.YandexGames.Leaderboard.GetPlayerEntry(LEADERBOARD_NAME,
                result => { Agava.YandexGames.Leaderboard.SetScore(LEADERBOARD_NAME, score); });
        }

        private void GetPlayer()
        {
            Debug.Log("Start method GetPlayer");
            Debug.Log(System.DateTime.Now);
            Agava.YandexGames.Leaderboard.GetPlayerEntry(LEADERBOARD_NAME, result =>
            {
                int rank = result.rank;
                string name = result.player.publicName;
                _savedScore = result.score;
                _totalScore.SetScore(_savedScore);
                _player = new LeaderboardPlayer(rank, name, _savedScore);
                Debug.Log("End lambda func");
                Debug.Log(System.DateTime.Now);
            });
            Debug.Log("End method GetPlayer");
            Debug.Log(System.DateTime.Now);
        }

        private void Fill()
        {
            Debug.Log("Start method FillLeaderboadr");
            Debug.Log(System.DateTime.Now);
            _leaderboardPlayers.Clear();
            GetPlayer();

            Agava.YandexGames.Leaderboard.GetEntries(LEADERBOARD_NAME, onSuccessCallback: result =>
            {
                _leaderboardPlayers.Clear();
                int maxIndex = 3;

                if (result.entries.Length < 3)
                {
                    maxIndex = result.entries.Length;
                }

                for (int i = 0; i < maxIndex; i++)
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
                
                _leaderboardList.ConstructLeaderboard(_leaderboardPlayers, _player);
                //_leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
            });
        }

        public void OpenLeaderboard()
        {
            Debug.Log("Start method OpenLeaderboard");
            Debug.Log(System.DateTime.Now);
            if (PlayerAccount.IsAuthorized == false)
            {
                PlayerAccount.Authorize();
                return;
            }

            PlayerAccount.RequestPersonalProfileDataPermission();
            Fill();
            _leaderboard.SetActive(true);
            Debug.Log("End method OpenLeaderboard"); 
            Debug.Log(System.DateTime.Now);
        }

        private void Update()
        {
            _counter -= Time.deltaTime;

            if (_counter <= 0)
            {
                _counter = 5;
                GetPlayer();
                SavedScore = _savedScore;
            }
        }
    }
}