using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChange : MonoBehaviour
{

    public float timeInterval = 1.0f;
    public float speed = 2.0f;
    public SpriteRenderer[] neon_bg;

    void Start()
    {
        StartCoroutine(ColorChangeRoutine());
    }

    private IEnumerator ColorChangeRoutine()
    {
        float timer = 0.0f;
        Color32 color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);

        while (timer < timeInterval)
        {
            timer += Time.deltaTime * speed;
            for (int i = 0; i < neon_bg.Length; i++)
            {
                neon_bg[i].color = Color32.Lerp(neon_bg[i].color, color, timer);
            }
            //GetComponent<Camera>().backgroundColor = Color32.Lerp(GetComponent<Camera>().backgroundColor, color, timer);

            yield return null;
        }

        // On finish recursively call the same routine
        //yield return new WaitForSeconds(5f);
        StartCoroutine(ColorChangeRoutine());
    }

}
