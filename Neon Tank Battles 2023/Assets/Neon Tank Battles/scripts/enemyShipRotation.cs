using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShipRotation : MonoBehaviour {

	private Transform target;
	private Transform enemyShip;
	void Start () {
		enemyShip = transform.Find ("enemy").GetComponent <Transform> ();
		target = GameObject.Find ("player").GetComponent <Transform> ();
	}

	void Update () {
		if (target) {
			Vector3 dir = transform.position - target.position;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			if (enemyShip) {
				enemyShip.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			} else {
				Destroy (this.gameObject);
			}
		}
	}
}
