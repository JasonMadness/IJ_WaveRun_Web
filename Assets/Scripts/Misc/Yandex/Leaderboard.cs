using Agava.YandexGames;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{  
    private const string ANONYMOUS_NAME = "Anonymous";
    private const string LEADERBOARD_NAME = "WaveRunLeaderboard";

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
