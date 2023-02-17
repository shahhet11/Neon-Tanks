using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public GameObject[] HitEffect;
    GameObject HitEffectx;
    private void Start()
    {
        
    }
    void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name.Contains ("Border")) {
           Debug.Log("sadasdsad");
			Destroy (this.gameObject);
		}
        if (col.gameObject.name.Contains("enemy"))
        {
            Debug.Log("Enemy Hit" + col.gameObject.transform.root.name);
            
            Vector3 pos = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, col.gameObject.transform.position.z);

            //Blue - enemy2
            //Red - enemy
            //Yellow - enemy1
            //Yellow - enemy3
            if (col.gameObject.name == "enemy" && col.gameObject.transform.root.name == "enemy2(Clone)")
            {
                Debug.Log("Blue");
             HitEffectx = Instantiate(HitEffect[0], pos, Quaternion.identity) as GameObject;
            }
            else if (col.gameObject.name == "enemy" && col.gameObject.transform.root.name == "enemy(Clone)")
            {
                Debug.Log("Red");
                HitEffectx = Instantiate(HitEffect[1], pos, Quaternion.identity) as GameObject;
            }
            else if (col.gameObject.name == "enemy" && (col.gameObject.transform.root.name == "enemy1(Clone)" || col.gameObject.transform.root.name == "enemy3(Clone)"))
            {
                Debug.Log("Yellow");
                HitEffectx = Instantiate(HitEffect[2], pos, Quaternion.identity) as GameObject;
            }
            

            //HitEffectx.transform.SetParent(col.gameObject.transform);
            Destroy(HitEffectx, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name.Contains("Border"))
        {
            Debug.Log("BorderOnCollision");
            Destroy(this.gameObject);
        }

        if (collision.gameObject.name.Contains("enemy"))
        {
            Debug.Log("Enemy Hit");
            ContactPoint2D contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            //Instantiate(HitEffect, pos, rot);
            //HitEffect.transform.SetParent(collision.collider.gameObject.transform);

            GameObject HitEffectx = Instantiate(HitEffect[0], pos, rot) as GameObject;
            HitEffectx.transform.SetParent(collision.collider.gameObject.transform);
        }
        

    }
}
