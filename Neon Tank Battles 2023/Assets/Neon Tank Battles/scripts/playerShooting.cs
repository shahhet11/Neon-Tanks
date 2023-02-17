// Code auto-converted by Control Freak 2 on Thursday, July 26, 2018!
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerShooting : MonoBehaviour {
	public GameObject player;
	private GameObject playerObject;
	private AudioSource shootAudio;
	public float shootingTimer = 0;
	private float timer = 0.3f;
    
    void Start() {
		shootAudio = GameObject.Find ("shoot").GetComponent <AudioSource> ();
		playerObject = GameObject.Find ("gun");
        

        if (PlayerPrefs.GetInt ("fireSpeedLevel") > 1) {
			shootingTimer = 0.4f - ((float)PlayerPrefs.GetInt ("fireSpeedLevel") / 200);
		} else {
			shootingTimer = 0.4f;
		}

	}
	void Update () {
		if (player && Vars.gameover == false) {
			if (ControlFreak2.CF2Input.GetKey (KeyCode.A)) {
				if (player.transform.position.x > -16.8f) {
					player.transform.position = new Vector3 (player.transform.position.x - 0.10f, player.transform.position.y);
				}
			}
			if (ControlFreak2.CF2Input.GetKey (KeyCode.D)) {
				if (player.transform.position.x < 16.8f) {
					player.transform.position = new Vector3 (player.transform.position.x + 0.10f, player.transform.position.y);
				}
			}
			if (ControlFreak2.CF2Input.GetKey (KeyCode.W)) {
				if (player.transform.position.y < 9.2f) {
					player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y  + 0.10f);
				}
			}
			if (ControlFreak2.CF2Input.GetKey (KeyCode.S)) {
				if (player.transform.position.y > -9.2f) {
					player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y  - 0.10f);
				}
			}
            /*Vector3 vec = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			Vector3 dir = transform.position - vec;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			player.transform.rotation = Quaternion.AngleAxis(angle-180, Vector3.forward);*/
            


            Vars.angle = player.transform.rotation.eulerAngles.z;

			timer += Time.deltaTime;

			//if (timer >= shootingTimer) {
			//	timer = 0;
			//	shootAudio.Play ();
			//	GameObject bullet = Instantiate (Resources.Load ("bullet1"), new Vector2 (playerObject.transform.position.x, playerObject.transform.position.y), Quaternion.identity) as GameObject;
			//}

		} else {
			player = GameObject.Find ("player");
			if (GameObject.Find ("playerSpacecraft") != null) {
				playerObject = GameObject.Find ("playerSpacecraft").transform.Find ("gun").gameObject;

				if (PlayerPrefs.GetInt ("fireSpeedLevel") > 1) {
					shootingTimer = 0.4f - ((float)PlayerPrefs.GetInt ("fireSpeedLevel") / 200);
				} else {
					shootingTimer = 0.4f;
				}

			}
		}
	}
}
