using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHealth : MonoBehaviour
{

    float scale;
    float timer = 0;
    void Start()
    {
        scale = transform.localScale.x;
        GameObject.Find("starCollected").GetComponent<AudioSource>().Play();
    }
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= 0.1f)
        {
            timer = 0;
            scale -= 0.2f;
            transform.localScale = new Vector2(scale, scale);
            if (scale <= 0)
            {
                PlayerPrefs.SetInt("HealthIncreased", PlayerPrefs.GetInt("HealthIncreased") + 5);
                 
                Destroy(this.gameObject);
            }
        }
    }
}
