using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadeboardList : MonoBehaviour
{
    [SerializeField] private LeaderboardElement[] _leaderboardElements = new LeaderboardElement[3];
    [SerializeField] private LeaderboardElement _playerElement;

    public void ConstructLeaderboard(List<LeaderboardPlayer> elements, LeaderboardPlayer player)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            _leaderboardElements[i].Initialize(elements[i].Rank, elements[i].Name, elements[i].Score);
        }

        _playerElement.Initialize(player.Rank, player.Name, player.Score);
    }
}
