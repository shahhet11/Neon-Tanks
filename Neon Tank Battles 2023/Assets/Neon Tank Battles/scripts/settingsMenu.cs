using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsMenu : MonoBehaviour {

	public Text soundText;
	public Text musicText;

	void Start () {
		GameObject.Find ("Canvas").GetComponent<sound> ().checkMusic ();
		GameObject.Find ("Canvas").GetComponent<sound> ().checkSound ();
		if (PlayerPrefs.GetInt ("sound") == 0) {
			soundText.text = "SOUND ON";
		} else {
			soundText.text = "SOUND OFF";
		}

		if (PlayerPrefs.GetInt ("music") == 0) {
			musicText.text = "MUSIC ON";
		} else {
			musicText.text = "MUSIC OFF";
		}
	}
	public void sound() {
		if (PlayerPrefs.GetInt ("sound") == 0) {
			PlayerPrefs.SetInt ("sound", 1);
			soundText.text = "SOUND OFF";
		} else {
			PlayerPrefs.SetInt ("sound", 0);
			soundText.text = "SOUND ON";
		}
		GameObject.Find ("Canvas").GetComponent<sound> ().checkMusic ();
		GameObject.Find ("Canvas").GetComponent<sound> ().checkSound ();
	}
	public void music() {
		if (PlayerPrefs.GetInt ("music") == 0) {
			PlayerPrefs.SetInt ("music", 1);
			musicText.text = "MUSIC OFF";
		} else {
			PlayerPrefs.SetInt ("music", 0);
			musicText.text = "MUSIC ON";
		}
		GameObject.Find ("Canvas").GetComponent<sound> ().checkMusic ();
		GameObject.Find ("Canvas").GetComponent<sound> ().checkSound ();
	}
	public void reset() {
		PlayerPrefs.DeleteAll ();

		PlayerPrefs.SetInt ("music", 0);
		musicText.text = "MUSIC ON";

		PlayerPrefs.SetInt ("sound", 0);
		soundText.text = "SOUND ON";

		GameObject.Find ("Canvas").GetComponent<sound> ().checkMusic ();
		GameObject.Find ("Canvas").GetComponent<sound> ().checkSound ();
	}
}
