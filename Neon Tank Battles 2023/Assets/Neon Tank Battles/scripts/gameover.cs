using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using UnityEngine.UI;
using System.Collections.Generic;

public class gameover : MonoBehaviour {

	bool pauza = false;
	float timer = 0;
	float scale = 0;
	float imageTranparency = 0;
	public GameObject pauseMenu;
	bool activity = false;
	RectTransform pauseRect;
	public GameObject pauseTransparency;
	Image transparency;
	void Start () {
		pauseRect = pauseMenu.GetComponent<RectTransform> ();
		transparency = pauseTransparency.GetComponent<Image> ();
	}

	void Update () {
		if (activity == true) {
			timer += Time.deltaTime;
			if (timer >= 0.01f) {
				timer = 0;
				if (pauza) {
					scale += 0.1f;
					pauseRect.localScale = new Vector2 (scale, scale);
					if(scale>0.5f) imageTranparency += 0.1f;
					transparency.color = new Color (0,0,0,imageTranparency);
					if (scale >= 1) {
						activity = false;
					}

				} else {
					scale -= 0.1f;
					imageTranparency -= 0.1f;
					pauseRect.localScale = new Vector2 (scale, scale);
					transparency.color = new Color (0,0,0,imageTranparency);
					if (scale < 0.1f) {
						activity = false;
					}
				}

			} 
		}
	}

	public void gameoverButton () {
		if (PlayerPrefs.GetInt ("bestScore") < Vars.score) {
			PlayerPrefs.SetInt ("bestScore", Vars.score);
		}
		if (pauza) {
			pauza = false;
			pauseTransparency.GetComponent<Image> ().raycastTarget = false;
		} else {
			imageTranparency = 0;
			pauza = true;
            
            pauseTransparency.GetComponent<Image> ().raycastTarget = true;
		}
		activity = true;
		Vars.gameover = true;
        if (Vars.gameover == true) {
            UnlockAchievement2(GPGSIds.achievement_you_died_better_luck_next_time);
        }
        
        
    }
    public void UnlockAchievement2(string achievementID)
    {
        Social.ReportProgress(achievementID, 100.0f, (bool success) =>
        {
          
        });
    }
}
