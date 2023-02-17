using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openUpgradeMenu : MonoBehaviour {

	public GameObject closeMenuButton;
	private Image upgradeCloseImage;
	public GameObject upgradeMenu;
	RectTransform upgradeMenuTransform;
	float imageTransparency = 0;
	float scale = 0;
	float timer = 0;
	bool go = false;
	bool open = false;
	void Start () {
		upgradeCloseImage = closeMenuButton.GetComponent<Image> ();
		upgradeMenuTransform = upgradeMenu.GetComponent<RectTransform> ();
		}
	void Update () {
		if (go) {
			timer += Time.deltaTime;
			if (timer >= 0.01f) {
				timer = 0;
				if (open) {
					scale += 0.07f;
					if (scale < 1) {
						imageTransparency += 0.05f;
						upgradeCloseImage.color = new Color (0, 0, 0, imageTransparency);
						upgradeMenuTransform.localScale = new Vector2 (scale, scale);
					} else {
						upgradeCloseImage.raycastTarget = true;
						scale = 1;
						upgradeMenuTransform.localScale = new Vector2 (scale, scale);
						go = false;
					}
				}else {
					scale -= 0.1f;
					if (scale > 0) {
						imageTransparency -= 0.05f;
						upgradeCloseImage.color = new Color (0, 0, 0, imageTransparency);
						upgradeMenuTransform.localScale = new Vector2 (scale, scale);
					} else {
						upgradeCloseImage.raycastTarget = false;
						scale = 0;
						upgradeMenuTransform.localScale = new Vector2 (scale, scale);
						imageTransparency = 0;
						upgradeCloseImage.color = new Color (0, 0, 0, imageTransparency);
						go = false;
					}
				}
			} 
		}
	}

	public void openUpgrade() {
		GameObject.Find ("buttonClick").GetComponent<AudioSource> ().Play ();
		open = true;
		go = true;
	}
	public void closeUpgrade() {
		GameObject.Find ("buttonClick").GetComponent<AudioSource> ().Play ();
		open = false;
		go = true;
	}
}
