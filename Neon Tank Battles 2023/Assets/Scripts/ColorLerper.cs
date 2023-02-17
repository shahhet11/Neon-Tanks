using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerper : MonoBehaviour
{

    public float speed;
    public Color startColor;
    public Color endColor;
    public bool repeatable;
    bool Check;
    float startTime;
    int RandomColorno;
    public SpriteRenderer[] neon_bg;
    public static ColorLerper Instance;
    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (repeatable)
        {
            Debug.Log("Repeatable");
            float t = (Time.time - startTime) * speed;
            for (int i = 0; i < neon_bg.Length; i++)
            {
                neon_bg[i].color = Color.Lerp(startColor, endColor, t);  //Color32.Lerp(neon_bg[i].color, color, timer);
            }
            //GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
            repeatable = false;
            Invoke("CheckRepeateable", 0.2f);
        }
        else if (!repeatable && Check)
        {
            Debug.Log("!Repeatable");
            float t = (Time.time - startTime) * speed;
            //float t = (Mathf.Sin(Time.time - startTime) * speed);
            for (int i = 0; i < neon_bg.Length; i++)
            {
                neon_bg[i].color = Color.Lerp(endColor, startColor, t);  //Color32.Lerp(neon_bg[i].color, color, timer);
            }

            Check = false;
        }
    }
    void CheckRepeateable()
    {
        Check = true;
    }
    void GiveColors()
    {
        RandomColorno = Random.Range(0,5);
    }
}