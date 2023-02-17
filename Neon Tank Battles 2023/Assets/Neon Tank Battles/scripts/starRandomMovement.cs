using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starRandomMovement : MonoBehaviour {

	Vector2 currentPosition;
	float newPositionX;
	float newPositionY;
	float randomScale;
    float randomScale1;
	int rotation;
	float t = 0.1f;
	void Start () {
		randomScale = Random.Range (0.08f, 0.12f);
        randomScale1 = Random.Range(0.08f, 0.12f);
		rotation = Random.Range (-10, 10);
        if (this.gameObject.name == "star(Clone)")
        { 
		transform.localScale = new Vector2 (randomScale, randomScale);
        }
        if (this.gameObject.name == "Health(Clone)")
        {
            transform.localScale = new Vector2(randomScale1, randomScale1);
        }
		transform.localRotation = Quaternion.Euler (0, 0, rotation);
		currentPosition = transform.position;
		newPositionX = Random.Range (currentPosition.x - 3, currentPosition.x + 3);
		newPositionY = Random.Range (currentPosition.y - 3, currentPosition.y + 3);
		Destroy (GetComponent<starRandomMovement> (), 0.5f);
	}
	void Update () {
		transform.position = new Vector3(Mathf.Lerp(transform.position.x, newPositionX, t), Mathf.Lerp(transform.position.y, newPositionY, t), 0);
		t -= 0.05f * Time.deltaTime;
	}
}
