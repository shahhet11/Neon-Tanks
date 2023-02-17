using UnityEngine;
using System.Collections;

public class smoothCamera2D : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	private Camera c;
	private Transform player;
	private float xPoint = 0.5f;
	private float yPoint = 0.5f;
	Vector3 point;
	void Start () {
		c = GetComponent <Camera> ();
		player = GameObject.Find ("player").GetComponent <Transform> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (target) {
			bool yyy = true;
			bool upp = true;
			point = c.WorldToViewportPoint (new Vector3 (target.position.x, target.position.y, target.position.z));//(target.position);
			Vector3 delta = target.position - c.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z)); 
			Vector3 destination = transform.position + delta;
			if (player.position.y > -5 && player.position.y < 5) {
				yyy = true;
			} else {
				if (player.position.y > 5) {
					upp = false;
				} else {
					upp = true;
				}
				yyy = false;
			}
			if (player.position.x > -9.5f && player.position.x < 9.5f) {
				if (yyy) {
					transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
				} else {
					if (upp == false) {
						transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (destination.x, 5, destination.z), ref velocity, dampTime);
					} else {
						transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (destination.x, -5, destination.z), ref velocity, dampTime);
					}
				}
			} else {
				if (player.position.x < -9.5f) {
					if (yyy) {
						transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (-9.5f, destination.y, destination.z), ref velocity, dampTime);
					} else {
						if (upp == false) {
							transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (-9.5f, 5, destination.z), ref velocity, dampTime);
						} else {
							transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (-9.5f, -5, destination.z), ref velocity, dampTime);
						}
					}
				} else {
					if (yyy) {
						transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (9.5f, destination.y, destination.z), ref velocity, dampTime);
					} else {
						if (upp == false) {
							transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (9.5f, 5, destination.z), ref velocity, dampTime);
						} else {
							transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (9.5f, -5, destination.z), ref velocity, dampTime);
						}
					}
				}

			}
		}

	}
	public void newTarget() {
		player = GameObject.Find ("player").GetComponent <Transform> ();
		target = GameObject.Find ("playerSpacecraft").GetComponent<Transform> ();
	}
}