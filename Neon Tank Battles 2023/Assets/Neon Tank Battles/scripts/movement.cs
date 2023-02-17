// Code auto-converted by Control Freak 2 on Thursday, July 26, 2018!
using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {


	void Update () {
		if (ControlFreak2.CF2Input.GetKey (KeyCode.W)) {
			transform.Translate (0, 2 * Time.deltaTime, 0);
		}
		if (ControlFreak2.CF2Input.GetKey (KeyCode.S)) {
			transform.Translate (0, -2 * Time.deltaTime, 0);
		}
		if (ControlFreak2.CF2Input.GetKey (KeyCode.D)) {
			transform.Translate (2 * Time.deltaTime, 0, 0);
		}
		if (ControlFreak2.CF2Input.GetKey (KeyCode.A)) {
			transform.Translate (-2 * Time.deltaTime, 0, 0);
		}
	}
}
