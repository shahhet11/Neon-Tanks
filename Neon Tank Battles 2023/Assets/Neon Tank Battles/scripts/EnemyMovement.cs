using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	private Transform target;
	public float speed;
	void Start () {
		if (GameObject.Find ("player") != null) {
			target = GameObject.Find ("player").GetComponent <Transform> ();
		}
	}
	void Update() {
		if (target) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		}
	}
}
	