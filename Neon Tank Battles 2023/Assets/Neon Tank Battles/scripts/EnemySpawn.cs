using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	private bool spawn = false;
	public float timer = 0;
    public List<GameObject> enemyList;
	private int enemyType = 0;
	private float upDown;
	private float leftRight;
	private float positionX;
	private float positionY;
	private float enemyLevelTimer = 0;

	void OnEnable ()
    {
		Vars.level = 1;
	}
	void Update () {//x-14,15   y-7,7
        
	    enemyLevelTimer+=Time.deltaTime;
		if (enemyLevelTimer >= 10) {
			Vars.level++;
			enemyLevelTimer = 0;
		}
		if (spawn) {
			spawn = false;
			timer = 0;
			upDown = Random.Range (1, 3);
			positionX = Random.Range (-15, 15);
			while (Mathf.Abs((Mathf.Abs (positionX) - Mathf.Abs (transform.position.x))) < 2f) {
				positionX = Random.Range (-15, 15);
			}
			positionY = Random.Range (-10, 10);
			while (Mathf.Abs((Mathf.Abs (positionY) - Mathf.Abs (transform.position.y))) < 2f) {
				positionY = Random.Range (-10, 10);
			}
	
			enemyType = Random.Range (1, 6);
			if (enemyType == 1)
            {
				GameObject g = Instantiate (Resources.Load ("enemy"), new Vector2 (positionX, positionY), Quaternion.identity) as GameObject;
                enemyList.Add(g);
                g.GetComponentInChildren<enemyHit>().ene_spawn = this;
			}
            else if (enemyType == 2)
            {
				GameObject g = Instantiate (Resources.Load ("enemy1"), new Vector2 (positionX, positionY), Quaternion.identity) as GameObject;
                enemyList.Add(g);
                g.GetComponentInChildren<enemyHit>().ene_spawn = this;
            }
            else if(enemyType == 3)
            {
				GameObject g = Instantiate (Resources.Load ("enemy2"), new Vector2 (positionX, positionY), Quaternion.identity) as GameObject;
                enemyList.Add(g);
                g.GetComponentInChildren<enemyHit>().ene_spawn = this;
            }
            else if(enemyType == 4)
            {
				GameObject g = Instantiate (Resources.Load ("enemy3"), new Vector2 (positionX, positionY), Quaternion.identity) as GameObject;
                enemyList.Add(g);
                g.GetComponentInChildren<enemyHit>().ene_spawn = this;
            }
            else
            {
				//GameObject gg = Instantiate (Resources.Load ("asteroid"), new Vector2 (positionX, positionY), Quaternion.identity) as GameObject;
				int r = Random.Range (0, 2);
				int g = Random.Range (0, 2);
				int b = Random.Range (0, 2);
				if (r == 0 && g == 0 && b == 0) {
					g = 1;
				}
				//gg.GetComponent<SpriteRenderer> ().color = new Color (r, g, b, 0.78f);
			}

		}
        else
        {
			timer += Time.deltaTime;

            if (timer >= 2.5f)
            {
				spawn = true;
			}
		} 
	}
}
