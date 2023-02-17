using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour {

    public EnemySpawn EnemySpawn;

    public GameObject hitParticles;

	public Transform target;
    public Transform Launcher;

	public float speed = 5f;
	public float rotateSpeed = 200f;
    public float maxAngularVelo;
    public float randomRotValue;
    public float destroyAfter;

    private float timerT;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        if (target)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            //if (rb.angularVelocity < -maxAngularVelo || rb.angularVelocity > maxAngularVelo)
            //{
            //    rb.angularVelocity = maxAngularVelo;
            //}

            rb.velocity = transform.up * speed;
        }
        else
        {
            Vector2 direction = transform.forward * 1000f;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;

            if (EnemySpawn.enemyList.Count > 0)
            {
                int rdm = Random.Range(0, EnemySpawn.enemyList.Count);

                target = EnemySpawn.enemyList[rdm].transform;
            }

            // Debug.Log("missile target null");
        }

        timerT += Time.deltaTime;

        if (timerT >= destroyAfter)
        {
            GameObject p = Instantiate(hitParticles, transform.position, Quaternion.identity);
            Destroy(p, 1f);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name.Contains("enemy"))
        {
            GameObject p = Instantiate(hitParticles, collision.contacts[0].point, Quaternion.identity);
            Destroy(p, 1f);

            Destroy(gameObject);
        }

        if(collision.collider.CompareTag("wall"))
        {
            GameObject p = Instantiate(hitParticles, collision.contacts[0].point, Quaternion.identity);
            Destroy(p, 1f);

            Destroy(gameObject);
        }
    }
}
