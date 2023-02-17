using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour {

	public Rigidbody2D rb;
	public float rotation = 0;
	void Start () {
		this.transform.rotation = Quaternion.AngleAxis (rotation, Vector3.forward);
		//rb.AddRelativeForce(Vector3.up * 0.05f);
		rb.velocity = transform.TransformDirection (Vector2.up * 5);
	}
}
