using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectStars : MonoBehaviour {

    public float speed = 5f;

	void OnTriggerStay2D(Collider2D coll)
    {
		if (coll.gameObject.name == "star(Clone)")
        {
			float step = speed * Time.deltaTime;
			coll.transform.position = Vector2.MoveTowards (coll.transform.position, transform.position, step);
		}

        if (coll.gameObject.name == "Health(Clone)")
        {
            float step = speed * Time.deltaTime;
            coll.transform.position = Vector2.MoveTowards(coll.transform.position, transform.position, step);
             
        }
	}
}
