using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class exitGame : MonoBehaviour {

	float timer = 0;
	float fade = 0;
	bool changeScene = false;
	bool gp = false;
	public GameObject image;
	public GameObject mainMenu;
	public GameObject gameUI;
	public GameObject player;
	Image im;
	float volume = 1;
	void Start () {
		im = image.GetComponent <Image> ();
	}
	void Update () {
		if (gp) {
			timer += Time.deltaTime;
			if (timer >= 0.02f) {
				timer = 0;
				if (changeScene == false) {
					fade += 0.1f;
					if (fade >= 1.5f) {
						GameObject.Find ("Canvas").GetComponent<replay> ().replayGameFromPauseMenu ();
						volume = 0;
						if (GameObject.Find ("playersHealth") != null) {
							GameObject.Find ("playersHealth").GetComponent<Text> ().text = "HEALTH: 100%";
						}
						mainMenu.SetActive (true);
						gameUI.SetActive (false);
						if (GameObject.Find ("player") != null) {
							GameObject.Find ("player").GetComponent <EnemySpawn> ().enabled = false;
						} else {
							GameObject g = Instantiate (Resources.Load ("player"), new Vector2 (0, 0), Quaternion.identity) as GameObject;
							g.name = "player";
						}
						changeScene = true;
						Vars.gameover = true;
					}
				} else {

					fade -= 0.1f;
					if (fade <= 0f) {
						if (PlayerPrefs.GetInt ("music") == 0) {
							volume = 1;
						}
						GameObject.Find ("Canvas").GetComponent<sound> ().checkMusic ();
						GameObject.Find ("Canvas").GetComponent<sound> ().checkSound ();
						gp = false;
						fade = 0;
						changeScene = false;
					}
				}
				if (PlayerPrefs.GetInt ("music") == 1) {
					volume = 0;
				}
				im.color = new Color (0, 0, 0, fade);
			}
		}
	}

	public void exit () {
		GameObject.Find ("buttonClick").GetComponent<AudioSource> ().Play ();
		//Time.timeScale = 1f;
		//GameObject.Find("Canvas").GetComponent <pause> ().pauseButton ();
		gp = true;
		Vars.gameover = true;
        //GoogleMobileAdsDemoScript.ins.ShowInterstitial();
        //SceneManager.LoadScene("UIScene");
    }
	public void exitFromGameOverMenu () {
		GameObject.Find ("buttonClick").GetComponent<AudioSource> ().Play ();
		GameObject.Find("Canvas").GetComponent <gameover> ().gameoverButton ();
		gp = true;
		Vars.gameover = true;
        GoogleMobileAdsDemoScript.ins.ShowInterstitial();
        if (GameObject.Find("player") != null)
        {
            Debug.Log("ASd");
        }
        Invoke("EnablePlayer", 0.5f);
    }
    void EnablePlayer()
    {
        play.Instance.EnableNecessaryObjects[0] = GameObject.Find("player") as GameObject;
        play.Instance.DisableOnTap();
    }
}
