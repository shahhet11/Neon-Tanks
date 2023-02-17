using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWeapons : MonoBehaviour
{
    public EnemySpawn EnemySpawn;

    public GameObject missilePref;
    public GameObject bulletPref;
    public GameObject lasertPref;
    public GameObject OrbPref;
    public GameObject StrikePref;
    public GameObject FlamePref;
    public GameObject DancingLinesPref;
    public GameObject[] shootFrom;

    public int weaponId;

    // Start is called before the first frame update
    void Start()
    {
        EquipWeapon();
    }

    void EquipWeapon()
    {
        weaponId = PlayerPrefs.GetInt("selectedWeapon");
    }
    // Update is called once per frame
    void Update()
    {
        if (ControlFreak2.CF2Input.GetButtonDown("ChangeWeapon") || Input.GetKeyDown(KeyCode.Q))
        {
            weaponId++;
            if (weaponId == 8)
            {
                weaponId = 0;

            }
        }


        if (Input.GetKeyDown(KeyCode.LeftControl) || (ControlFreak2.CF2Input.GetButtonDown("Fire")))
        {
            switch (weaponId)
            {
                case 0:

                    SimpleBulletShoot();

                    break;

                case 1:

                   
                    MissileShoot();

                    break;

                case 2:

                    MultipleBulletShoot();

                    break;

                case 3:

                    LaserShoot();

                    break;

                case 4:
                    BeamingOrb();

                    break;

                case 5:
                    Lightningstrike();

                    break;

                case 6:
                    FlameThrower();

                    break;

                case 7:
                    DancingLines();

                    break;
            }
        }
    }

    public void MissileShoot()
    {
        for (int i = 0; i < shootFrom.Length; i++)
        {
            GameObject sp = Instantiate(missilePref, new Vector3(shootFrom[i].transform.position.x, shootFrom[i].transform.position.y), shootFrom[i].transform.rotation);
            sp.GetComponent<HomingMissile>().EnemySpawn = this.EnemySpawn;

            //float[] valueArr = { 0.5f, -0.5f };
            //int rdmValue = Random.Range(0, valueArr.Length);
            //sp.GetComponent<HomingMissile>().randomRotValue = valueArr[rdmValue];
        }
    }

    public void SimpleBulletShoot()
    {
        Instantiate(bulletPref, shootFrom[1].transform.position, shootFrom[1].transform.rotation);
    }

    public void MultipleBulletShoot()
    {
        for (int i = 0; i < shootFrom.Length; i++)
        {
            Instantiate(bulletPref, new Vector3(shootFrom[i].transform.position.x, shootFrom[i].transform.position.y), shootFrom[i].transform.rotation);
        }
    }

    public void LaserShoot()
    {
        GameObject laser = Instantiate(lasertPref, shootFrom[1].transform.position, shootFrom[1].transform.rotation);
        laser.transform.SetParent(transform);
    }

    public void BeamingOrb()
    {
         Instantiate(OrbPref, shootFrom[3].transform.position, shootFrom[3].transform.rotation);
        //orb.transform.SetParent(transform);
    }

    public void Lightningstrike()
    {
        GameObject strike = Instantiate(StrikePref, shootFrom[5].transform.position, shootFrom[5].transform.rotation);
        strike.transform.SetParent(transform);
    }

    public void FlameThrower()
    {
        GameObject Flame = Instantiate(FlamePref, shootFrom[4].transform.position, shootFrom[4].transform.rotation);
        Flame.transform.SetParent(transform);
    }

    public void DancingLines()
    {
        Instantiate(DancingLinesPref, shootFrom[1].transform.position, shootFrom[1].transform.rotation);
        
    }


}
