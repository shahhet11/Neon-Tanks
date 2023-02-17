using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour {

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
						Time.timeScale = 0;
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

	public void pauseButton () {
		GameObject.Find ("buttonClick").GetComponent<AudioSource> ().Play ();
		if (pauza) {
			pauza = false;
			Time.timeScale = 1;
			pauseTransparency.GetComponent<Image> ().raycastTarget = false;
			Vars.gameover = false;
		} else {
			imageTranparency = 0;
			pauza = true;
			pauseTransparency.GetComponent<Image> ().raycastTarget = true;
			Vars.gameover = true;
		}
		activity = true;
	}
}
