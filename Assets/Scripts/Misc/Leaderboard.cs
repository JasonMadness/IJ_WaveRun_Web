using Agava.YandexGames;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private void Start()
    {
        YandexGamesSdk.Initialize();
    }

    /*public void OnGetLeaderboardEntriesButtonClick()
        {
            Leaderboard.GetEntries("PlaytestBoard", (result) =>
            {
                Debug.Log($"My rank = {result.userRank}");
                foreach (var entry in result.entries)
                {
                    string name = entry.player.publicName;
                    if (string.IsNullOrEmpty(name))
                        name = "Anonymous";
                    Debug.Log(name + " " + entry.score);
                }
            });
        }*/
}
