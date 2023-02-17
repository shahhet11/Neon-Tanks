using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisionWithEnemy : MonoBehaviour {
    public GameObject explosionPrefab;
    public float playerHealth = 100f;
	float startHelth = 0;
	public Text spacecraftHealth;
    public GameObject HitEffect;
    GameObject HitEffectx;
    public static collisionWithEnemy Instance;
    
    void Awake()
    {
        Instance = this;
    }
	void Start () {
		resetHealth (); 
	}
    void Update()
    {
       
        if (playerHealth == 100)
        {
            spacecraftHealth.text = "HEALTH: 100%";
        }
           
    }

	void resetHealth() {
		playerHealth = 100;
		if (GameObject.Find ("playersHealth") != null) {
			spacecraftHealth = GameObject.Find ("playersHealth").GetComponent<Text> ();
			spacecraftHealth.text = "HEALTH: 100%";
		}
		if (PlayerPrefs.GetInt ("healthLevel") > 1) {
			playerHealth = playerHealth * (int)((PlayerPrefs.GetInt ("healthLevel") + 1) / 2);
		}
		startHelth = playerHealth; 
	}
    
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Health(Clone)") && playerHealth != 100 )
        {
            Debug.Log("HEALTHHHHH");
            
             
            playerHealth += 5;
            spacecraftHealth.text = "HEALTH: " + (int)((playerHealth + 5f)) + "%";
            

        }
        if (FloatingPlayer2DController.Instance.ShieldGuard.activeInHierarchy == false)
        {
            if (col.gameObject.name.Contains("enemy"))
            {
                if (col.gameObject.name.Contains("enemyBullet"))
                {
                    ColorLerper.Instance.repeatable = true;
                    //GameObject.Find ("playerHitSound").GetComponent<AudioSource> ().Play ();
                    playerHealth -= 10 * Vars.bulletLevel;
                    CameraShake.Instance.ShakeCameraOnHit();

                    Vector3 pos = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, col.gameObject.transform.position.z);

                    HitEffectx = Instantiate(HitEffect, pos, Quaternion.identity) as GameObject;
                    HitEffectx.transform.SetParent(this.transform.root);
                    //explosionPrefab.SetActive(true);

                    //Invoke("DisableParticles", 1f);
                }
                else
                {

                    playerHealth -= (int)col.gameObject.GetComponent<enemyHit>().myHealth;
                    col.gameObject.GetComponent<enemyHit>().destroyEnemy();
                    Vector3 pos = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, col.gameObject.transform.position.z);

                    HitEffectx = Instantiate(HitEffect, pos, Quaternion.identity) as GameObject;
                    HitEffectx.transform.SetParent(this.transform.root);
                    ColorLerper.Instance.repeatable = true;
                }
                if (playerHealth <= 0)
                {

                    playerHealth = 0;
                    GameObject.Find("Canvas").GetComponent<gameover>().gameoverButton();
                    Destroy(GameObject.Find("player"));
                }
                if (spacecraftHealth != null)
                {
                    spacecraftHealth.text = "HEALTH: " + (int)((playerHealth / startHelth) * 100) + "%";
                }
                else
                {

                    spacecraftHealth = GameObject.Find("playersHealth").GetComponent<Text>();
                    spacecraftHealth.text = "HEALTH: " + (int)((playerHealth / startHelth) * 100) + "%";
                }
            }
            else if (col.gameObject.name.Contains("asteroid"))
            {
                playerHealth -= (int)col.gameObject.GetComponent<enemyHit>().myHealth;
                col.gameObject.GetComponent<enemyHit>().destroyEnemy();

                if (playerHealth <= 0)
                {
                    playerHealth = 0;
                    GameObject.Find("Canvas").GetComponent<gameover>().gameoverButton();
                    Destroy(GameObject.Find("player"));
                }
                if (spacecraftHealth != null)
                {
                    spacecraftHealth.text = "HEALTH: " + (int)((playerHealth / startHelth) * 100) + "%";
                }
                else
                {
                    spacecraftHealth = GameObject.Find("playersHealth").GetComponent<Text>();
                    spacecraftHealth.text = "HEALTH: " + (int)((playerHealth / startHelth) * 100) + "%";
                }
            }
        }
        else if (FloatingPlayer2DController.Instance.ShieldGuard.activeInHierarchy == true && col.transform.name.Contains("enemy"))
        {
            Vector3 pos = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, col.gameObject.transform.position.z);

            HitEffectx = Instantiate(HitEffect, pos, Quaternion.identity) as GameObject;
            HitEffectx.transform.SetParent(this.transform.root);
            Destroy(col.gameObject);
        }
	}
	public void calculateSpacecraftHealth() {
		resetHealth ();
		if (spacecraftHealth != null) {
			spacecraftHealth.text = "HEALTH: " + (int)((playerHealth / startHelth) * 100) + "%";
		}
	}

	void OnTriggerStay2D(Collider2D coll) {
		if (coll.gameObject.name == "star(Clone)") {
			coll.gameObject.GetComponent<destroyStar> ().enabled = true;
		}
        if (coll.gameObject.name == "Health(Clone)")
        {
            coll.gameObject.GetComponent<DestroyHealth>().enabled = true;
        }

	}

    void ExplosionParticles()
    {

    }
    void DisableParticles()
    {
        explosionPrefab.SetActive(false);
    }
}
