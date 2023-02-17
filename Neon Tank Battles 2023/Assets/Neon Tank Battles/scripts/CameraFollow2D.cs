using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public float FollowSpeed = 2f;
    private Transform Target;

    private void Update()
    {
        try
        {
            if (!Target)
            {
                Target = GameObject.Find("player").GetComponent<Transform>();
            }
            Vector3 newPosition = Target.position;
            newPosition.z = -10;
            transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
        }
        catch (System.Exception)
        {


        }



    }
}
