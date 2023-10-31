using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YandexSDK : MonoBehaviour
{
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
#if !UNITY_EDITOR
        yield return YandexGamesSdk.Initialize(OnInitialized);
#endif
        yield return null;
    }

    private void OnInitialized()
    {
        SceneManager.LoadScene(1);
    }
}
