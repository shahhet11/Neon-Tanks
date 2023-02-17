using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine.UI;
using System.Collections.Generic;


public class play : MonoBehaviour {

	float timer = 0;
	float fade = 0;
	bool changeScene = false;
	bool gp = false;
	public GameObject image;
	public GameObject mainMenu;
	public GameObject gameUI;
    public GameObject Shield_Bar;
    public GameObject[] EnableNecessaryObjects;
    public Canvas MainUI;
    public Camera UICamera;
    public Image MobileStick;
    public static play Instance;
    Image im;
	float volume = 1;
    private PlayGamesClientConfiguration config;

    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 180;
        //playGame();
    }
    void Start () {
		im = image.GetComponent <Image> ();
        //EnableNecessaryObjects[0] = GameObject.Find("player") as GameObject;
        //playGame();
        Invoke("playGame", 0.2f);
    }
	void Update () {
        
		if (gp) {
			timer += Time.deltaTime;
			if (timer >= 0.02f) {
				timer = 0;
				if (changeScene == false) {
					fade += 0.1f;
					if (fade >= 1.5f) {
						volume = 0;
						mainMenu.SetActive (false);
						gameUI.SetActive (true);
						GameObject.Find("player").GetComponent <EnemySpawn> ().enabled = true;
						changeScene = true;
						if (GameObject.Find ("playerSpacecraft") != null) {
							GameObject.Find ("playerSpacecraft").GetComponent<collisionWithEnemy> ().playerHealth = 100;
						}
						if (GameObject.Find ("game").transform.Find ("score") != null) { 
							GameObject.Find ("game").transform.Find ("score").GetComponent <Text> ().text = "SCORE: 0";
						}
					}
				} else {
					
					fade -= 0.1f;
					if (fade <= 0f) {
						if (PlayerPrefs.GetInt ("music") == 0) {
							volume = 1;
						}
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

    public void DisableOnTap()
    {
        for (int q = 0; q < EnableNecessaryObjects.Length; q++)
        {
            EnableNecessaryObjects[q].SetActive(false);
        }
        MobileStick.enabled = false;
        //MainUI.enabled = true;
        //UICamera.enabled = true;
        //EnableNecessaryObjects[0] = GameObject.Find("player");
    }

    public void playGame () {
        //MainUI.enabled = false;
        //UICamera.enabled = false;
        MobileStick.enabled = true;
      
        for (int q = 0; q < EnableNecessaryObjects.Length; q++)
        {
            EnableNecessaryObjects[q].SetActive(true);
        }
        GameObject.Find ("buttonClick").GetComponent<AudioSource> ().Play ();
		Vars.score = 0;
		GameObject.Find ("camera").GetComponent<smoothCamera2D> ().newTarget ();
		gp = true;
		GameObject.Find ("Canvas").GetComponent<sound> ().checkMusic ();
		GameObject.Find ("Canvas").GetComponent<sound> ().checkSound ();
		Vars.gameover = false;
        Shield_Bar.SetActive(true);

    }

        
	}

