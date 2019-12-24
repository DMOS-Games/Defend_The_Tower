using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro;

public class Auth : MonoBehaviour
{

    public TextMeshProUGUI AuthText;

    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        AuthenticateUser();
    }

    void AuthenticateUser()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                Debug.Log("Loggato");
                SceneManager.LoadScene("Game");
                AuthText.text = "Loggato!";
            }
            else
            {
                Debug.Log("Non loggato");
                AuthText.text = "Non loggato!";
            }
        });
    }
}
