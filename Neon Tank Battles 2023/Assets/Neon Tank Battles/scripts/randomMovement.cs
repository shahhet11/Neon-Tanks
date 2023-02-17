using UnityEngine;
using System.Collections;

public class randomMovement : MonoBehaviour {
	public float maxX= 5f;
	public float minX= -5f;
	public float maxY= 5f;
	public float minY= -5f;

	private float tChange = 0; // force new direction in the first Update
	private float randomX;
	private float randomY;
	public float moveSpeed = 1;

	public Transform target;

	void Start () {
		target = GameObject.Find ("player").GetComponent <Transform> ();
	}

	void  Update (){
		// change to random direction at random intervals
		if (Time.time >= tChange){
			randomX = Random.Range(-2.0f,2.0f); // with float parameters, a random float
			randomY = Random.Range(-2.0f,2.0f); //  between -2.0f and 2.0f is returned
			// set a random interval between 0.5f and 1.5f
			tChange = Time.time + Random.Range(0.5f,1.5f);
		}
		transform.Translate(new Vector3(randomX,randomY,0) * moveSpeed * Time.deltaTime);
		// if object reached any border, revert the appropriate direction
		if (transform.position.x >= maxX || transform.position.x <= minX) {
			randomX = -randomX;
		}
		if (transform.position.y >= maxY || transform.position.y <= minY) {
			randomY = -randomY;
		}
		float x = Mathf.Clamp(transform.position.x, minX, maxX);
		float y = Mathf.Clamp(transform.position.y, minY, maxY);
		transform.position = new Vector2 (x, y);
		if (target) {
			Vector3 dir = transform.position - target.position;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		}
	}
}