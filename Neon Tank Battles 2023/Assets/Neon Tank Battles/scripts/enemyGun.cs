using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGun : MonoBehaviour {

	public GameObject gun;
	private float timer = 0;
	public float shootingTimer = 3f;
	public int enemyType;
	GameObject bullet;

	void Update () {
		timer += Time.deltaTime;
		if (timer >= shootingTimer) {
			timer = 0;
			if (enemyType == 1) {
				bullet = Instantiate (Resources.Load ("enemyBullet"), new Vector2 (gun.transform.position.x, gun.transform.position.y), Quaternion.identity) as GameObject;
			} else {
				bullet = Instantiate (Resources.Load ("enemyBullet2"), new Vector2 (gun.transform.position.x, gun.transform.position.y), Quaternion.identity) as GameObject;
			}
			bullet.GetComponent<enemyBullet> ().rotation = transform.eulerAngles.z + 90;
		}
	}
}
