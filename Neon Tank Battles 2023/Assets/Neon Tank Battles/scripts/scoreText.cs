using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using UnityEngine.UI;
using System.Collections.Generic;

public class scoreText : MonoBehaviour {

	public int score = 0;
	public TextMesh text;
	float timer = -2;
	float transparency = 1;
	void Start () {
		text.characterSize = 0.3f;
		text.text = "+" + score;
        
	}

	void Update () {
        Debug.Log(score);
        ReportScore(score);
        if (score > 100) {
            UnlockAchievement3(GPGSIds.achievement_keep_it_up_100_points);
        }
        if (score > 200)
        {
            UnlockAchievement4(GPGSIds.achievement_congratulations_for_200_points);
        }
        timer += Time.deltaTime;
		if (timer >= 0.01f) {
			timer = 0;
			transparency -= 0.01f;
			text.color = new Color (1, 1, 1, transparency);
			if (transparency <= 0) {
				Destroy (this.gameObject);
			}
		}
	}

    public void ReportScore(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_tank_destroyers, (bool success) =>
        {
            Debug.Log("Leaderboard" + success.ToString());
        });
    }

    public void UnlockAchievement3(string achievementID)
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

    public void UnlockAchievement4(string achievementID)
    {
        Social.ReportProgress(achievementID, 100.0f, (bool success) =>
        {
            
        });
    }
}
