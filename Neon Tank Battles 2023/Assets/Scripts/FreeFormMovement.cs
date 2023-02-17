using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFormMovement : MonoBehaviour
{
    public Transform[] LeftWallPosCheck; //Positions at Left Wall
    public Transform[] RightWallPosCheck; //Positions at right Wall
    public Transform[] TopWallPosCheck; //Positions at Top Wall
    public Transform[] BottomWallPosCheck; //Positions at Bottom Wall
    public Transform target;
    int ChooseWallAtBeginning; //Index for Choosing wall at beginning // 1 - Left , 2 - Right , 3 - Top , 4 - Bottom
    int ChooseWallRandomly;
    int ChoosePositionAtWall;
    float step; //Variable for storing speed at Time.deltatime
    float speed = 2.0f; //Speed at which the Wave will Move
    bool Type1;
    bool Type2;
    bool StartCheck;
    bool RandomCheck;
    // Start is called before the first frame update
    void Start()
    {
        ChooseWallAtBeginning = Random.Range(1, 5); // For Choosing Wall
        Debug.Log(ChooseWallAtBeginning + "ChooseWallAtBeginning");
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        if(!StartCheck)
            OnStartMovement();
        if (RandomCheck)
            OnRandomMovement();
    }

    void OnStartMovement()
    {

        if (ChooseWallAtBeginning == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, LeftWallPosCheck[0].position, step);
            target.position = LeftWallPosCheck[0].position;
        }
        else if (ChooseWallAtBeginning == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, RightWallPosCheck[0].position, step);
            target.position = RightWallPosCheck[0].position;
        }
        else if (ChooseWallAtBeginning == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, TopWallPosCheck[0].position, step);
            target.position = TopWallPosCheck[0].position;
        }
        else if (ChooseWallAtBeginning == 4)
        {
            transform.position = Vector3.MoveTowards(transform.position, BottomWallPosCheck[0].position, step);
            target.position = BottomWallPosCheck[0].position;
        }

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            Debug.Log("StartCheck");
            StartCheck = true; // OnStartMovement Finished
            RandomCheck = true; // OnRandomMovement Initialized
            if (ChooseWallAtBeginning == 1 || ChooseWallAtBeginning == 2)
            {
                Type1 = true;
            }
            else if (ChooseWallAtBeginning == 3 || ChooseWallAtBeginning == 4)
            {
                Type2 = true;
            }
            ChooseWallRandomly = Random.Range(1, 3);
            ChoosePositionAtWall = Random.Range(0, 6);
        }
        

    }

    void OnRandomMovement()
    {
        Debug.Log(ChooseWallRandomly + "ChooseWallRandomly");
        if (Type1)
        {
            
            if (ChooseWallRandomly == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, TopWallPosCheck[ChoosePositionAtWall].position, step);
                target.position = TopWallPosCheck[ChoosePositionAtWall].position;
            }
            else if (ChooseWallRandomly == 3)
            {
                transform.position = Vector3.MoveTowards(transform.position, BottomWallPosCheck[ChoosePositionAtWall].position, step);
                target.position = BottomWallPosCheck[ChoosePositionAtWall].position;
            }

            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                Type1 = false;
                Type2 = true;
                ChooseWallRandomly = Random.Range(1, 3);
                ChoosePositionAtWall = Random.Range(0, 6);
            }
        }
        else if (Type2)
        {
            if (ChooseWallRandomly == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, LeftWallPosCheck[ChoosePositionAtWall].position, step);
                target.position = LeftWallPosCheck[ChoosePositionAtWall].position;
            }
            else if (ChooseWallRandomly == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, RightWallPosCheck[ChoosePositionAtWall].position, step);
                target.position = RightWallPosCheck[ChoosePositionAtWall].position;
            }

            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                Type1 = true;
                Type2 = false;
                ChooseWallRandomly = Random.Range(1, 3);
                ChoosePositionAtWall = Random.Range(0, 6);
            }
        }


    }
}
