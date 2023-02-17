using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStart : MonoBehaviour {

	public GameObject enemy;
	Transform enemyTransform;
	float timer = 0;
	float scale = 0;
	void Start () {
		enemyTransform = enemy.GetComponent<Transform> ();
	}

	void Update () {
		timer += Time.deltaTime;
		if (timer >= 0.01f) {
			timer = 0;
			scale += 0.01f;
			if (enemy.gameObject.name == "enemy(Clone)" || enemy.gameObject.name == "enemy1(Clone)") {
				if (scale > 0.8f) {
					GetComponent<CircleCollider2D> ().enabled = true;
					enemy.GetComponent<EnemyMovement> ().enabled = true;
					Destroy (GetComponent<enemyStart> ());
				}
			} else {
				if (scale > 1) {
					GetComponent<CircleCollider2D> ().enabled = true;
					Destroy (GetComponent<enemyStart> ());
				}
			}
			enemyTransform.localScale = new Vector2 (scale, scale);
		}
	}
}
