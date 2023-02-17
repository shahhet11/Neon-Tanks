using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Quaternion DefaultCamRot;
    private Quaternion CamPosition;
    public float ShakeSmooth = 5f;
    public float ShakeIntense = 0.03f;
    public static CameraShake Instance;
    void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        CameraShakeLerp();
    }
    void CameraShakeLerp()// in update
    {
        Camera.main.transform.localRotation = Quaternion.Lerp(Camera.main.transform.localRotation, CamPosition, Time.deltaTime * ShakeSmooth);
    }


    IEnumerator CamShake() // Start Corountine when hit with bullet
    {

        float shakeIntensity = 0.00001f;
        while (shakeIntensity > 0)
        {
            CamPosition = new Quaternion(
                Random.Range(-ShakeIntense * 2.5f, ShakeIntense * 2.5f),
                Random.Range(-ShakeIntense * 2.5f, ShakeIntense * 2.5f),
                Random.Range(-ShakeIntense * 2.5f, ShakeIntense * 2.5f),
                Random.Range(-ShakeIntense * 4.1f, ShakeIntense * 4.1f)

            );
            shakeIntensity -= 0.0075f;
            yield return false;
        }
        //yield return new WaitForSeconds(0.03f);
        CamPosition = DefaultCamRot;

    }
    public void ShakeCameraOnHit()
    {
        StartCoroutine(CamShake());
    }


    void Start()
    {
        DefaultCamRot = Camera.main.transform.localRotation;
    }
}
