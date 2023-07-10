using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Agava.YandexGames;

public class testing : MonoBehaviour
{
    public GameObject[] TetstingPanelChildrens;
    public TotalScore score;
    public TMP_Text _authorizationStatusText;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    public void activateUI()
    {
        foreach(GameObject go in TetstingPanelChildrens)
        {
            go.SetActive(!go.activeSelf);
        }
    }

    private IEnumerator Start()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            yield break;
#endif

            // Always wait for it if invoking something immediately in the first scene.
            yield return YandexGamesSdk.Initialize();

            while (true)
            {
                _authorizationStatusText.color = PlayerAccount.IsAuthorized ? Color.green : Color.red;

                /*if (PlayerAccount.IsAuthorized)
                    _personalProfileDataPermissionStatusText.color = PlayerAccount.HasPersonalProfileDataPermission ? Color.green : Color.red;
                else
                    _personalProfileDataPermissionStatusText.color = Color.red;*/

                yield return new WaitForSecondsRealtime(0.25f);
            }
        }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activateUI();
        }
    }
}
