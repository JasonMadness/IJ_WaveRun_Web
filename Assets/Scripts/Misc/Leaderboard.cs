using System.Collections.Generic;

public class Leaderboard
{
    public List<string> GetLeaderboardEntries()
    {
        List<string> names = new List<string>();
        
        Agava.YandexGames.Leaderboard.GetEntries("WaveRunLeaderboard", (result) =>
        {
            foreach (var entry in result.entries)
            {
                string name = entry.player.publicName;
                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";
                names.Add(name);
            }
        });

        return names;
    }    
}
