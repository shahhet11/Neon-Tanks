using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizedTank : MonoBehaviour
{

    public Sprite[] Bodies;
    public SpriteRenderer BodyObject;

    public Sprite[] Barrels;
    public SpriteRenderer BarrelObject;

    public Sprite[] Ladders;
    public SpriteRenderer LadderObject;

    public Sprite[] Towers;
    public SpriteRenderer TowerObject;

    public Sprite[] Tracks;
    public SpriteRenderer[] TrackObject;

    // Start is called before the first frame update
    void Start()
    {
        EquippedBody();
        EquippedWeapon();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SetDataFIrstTime()
    {
        if (PlayerPrefs.GetInt("TankSet") == 0)
        {
            // Set All Necessary Data
        }

    }

    public void EquippedTracks()
    {
        //Not Needed Yet
        //TrackObject[0].sprite = Tracks[0];
    }


    public void EquippedBody()
    {
        for (int i = 0; i < 9; i++)
        {
            if (PlayerPrefs.GetInt("Weapon" + i) == 2)
            {
                BodyObject.sprite = Bodies[i];
            }
        }
    }

    public void EquippedWeapon()
    {
       // call it in start
            for (int i = 0; i < 9; i++)
            {
            if (PlayerPrefs.GetInt("Weapon" + i) == 2)
            {
                BarrelObject.sprite = Barrels[i];
                LadderObject.sprite = Ladders[i];
                TowerObject.sprite = Towers[i];
            }
            }
        
    }
}
