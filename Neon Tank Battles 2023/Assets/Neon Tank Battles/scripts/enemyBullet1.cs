using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet1 : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name == "playerSpacecraft") {
			Destroy (this.gameObject);
		} else if (col.gameObject.name.Contains ("Border")) {
			Destroy (this.gameObject);
		}
	}
}
