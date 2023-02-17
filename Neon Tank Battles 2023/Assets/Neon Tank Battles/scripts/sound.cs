using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour {

	public void checkSound() {
		if (PlayerPrefs.GetInt ("sound") == 0) {
			GameObject.Find ("shoot").GetComponent<AudioSource> ().volume = 1;
			GameObject.Find ("bulletSound").GetComponent<AudioSource> ().volume = 1;
			GameObject.Find ("starCollected").GetComponent<AudioSource> ().volume = 1;
			GameObject.Find ("hitSound").GetComponent<AudioSource> ().volume = 1;
			GameObject.Find ("buttonClick").GetComponent<AudioSource> ().volume = 1;
		} else {
			GameObject.Find ("shoot").GetComponent<AudioSource> ().volume = 0;
			GameObject.Find ("bulletSound").GetComponent<AudioSource> ().volume = 0;
			GameObject.Find ("starCollected").GetComponent<AudioSource> ().volume = 0;
			GameObject.Find ("hitSound").GetComponent<AudioSource> ().volume = 0;
			GameObject.Find ("buttonClick").GetComponent<AudioSource> ().volume = 0;
		}
	}

	public void checkMusic () {
		if (PlayerPrefs.GetInt ("music") == 0) {
			
		} else {
	
		}
	}
}
