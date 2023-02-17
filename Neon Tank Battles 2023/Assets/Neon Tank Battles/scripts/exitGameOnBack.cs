using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine.UI;
using System.Collections.Generic;

public class exitGameOnBack : MonoBehaviour {
    

    void Start() {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

        // Enable debugging output (recommended)
        PlayGamesPlatform.DebugLogEnabled = true;

        // Initialize and activate the platform
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        SignIn();
    }
	void Update(){
		if (ControlFreak2.CF2Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit (); 

		}
        
    }

    public void SignIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Logged in");
                UnlockAchievement1(GPGSIds.achievement_welcome);
            }
        });
    }

    public void UnlockAchievement1(string achievementID)
    {
        Social.ReportProgress(achievementID, 100.0f, (bool success) =>
        {

        });
    }

    public void OnLeaderboardClick()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }

    public void OnAchievementClick()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }
}
