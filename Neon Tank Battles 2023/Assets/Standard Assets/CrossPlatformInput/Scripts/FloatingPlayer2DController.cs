
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
public class FloatingPlayer2DController : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float moveForce = 5;
	Rigidbody2D myBody;
    public GameObject ShieldGuard;
    public Animation shieldanim;
    string shieldname = "Shield";
    public Image LevelSCR;
    public Text LevelText;
    bool fake_var;
    AsyncOperation ASY;
    float COUNTER = 100f;
    public static FloatingPlayer2DController Instance;
	void Start ()
	{
        
        myBody = this.GetComponent<Rigidbody2D>();
        if (GameObject.Find("SwordSpinBlue") != null)
        {
            ShieldGuard = GameObject.Find("playersHealth").GetComponent<GameObject>();
 
        }
       if (GameObject.Find("Filled_Amount") != null)
       {
           LevelSCR = GameObject.Find("Filled_Amount").GetComponent<Image>();
           LevelSCR.fillAmount = 1f;
       }
       if (GameObject.Find("Fill_Text") != null)
       {
           LevelText = GameObject.Find("Fill_Text").GetComponent<Text>();
           LevelText.text = "100%".ToString();


       }
        
	}

    void Awake()
    {
        Instance = this;
    }

	void FixedUpdate ()
	{
        Vector3 moveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"),
            CrossPlatformInputManager.GetAxis("Vertical"), 4096);
        if (moveVec.x != 0 && moveVec.y != 0) {
            transform.rotation = Quaternion.LookRotation(moveVec, Vector3.back);
        }



    }

    void Update()
    {

        if (fake_var == true)
        {
            if (COUNTER >= 0 || COUNTER <= 100f)
            {
                if (COUNTER > 100f)
                {
                    fake_var = false;
                }
                StartCoroutine("StartCounterFill");
            }
        }

        if (ControlFreak2.CF2Input.GetButtonDown("Fire1"))//&& shieldanim[shieldname].speed == 2
        {
            Debug.Log("LOOL");
            ShieldGuard.SetActive(true);

            //shieldanim[shieldname].speed = 2;
            //shieldanim.Play();
            //ShieldGuard.GetComponent<ParticleSystem>().playbackSpeed = 2.0f;

        }
        else if (ControlFreak2.CF2Input.GetButtonUp("Fire1"))
        {
            Debug.Log("LOOL11");
            ShieldGuard.SetActive(false);
            //shieldanim[shieldname].speed = -1;
            //shieldanim[shieldname].time = shieldanim[shieldname].length; 
            //shieldanim.Play();
            Invoke("DisableShield", 0.9f);
            StartCoroutine("StartCounterFill");
            fake_var = true;

        }

        if (ControlFreak2.CF2Input.GetButton("Fire1"))
        {
            StartCoroutine("StartCounterUse");
            fake_var = false;
            if (COUNTER <= 0f)
            {
                COUNTER = 0f;
                ShieldGuard.SetActive(false);
            }
            else
            {
                ShieldGuard.SetActive(true);
            }

        }
    }

    //void DisableShield()
    //{
    //    ShieldGuard.SetActive(false);
    //    shieldanim[shieldname].speed = 2;
    //}
    IEnumerator StartCounterUse()
    {
            yield return new WaitForSeconds(0.00015f);
       
            COUNTER -= Time.deltaTime * 15f;
            LevelSCR.fillAmount = COUNTER / 100f;

            LevelText.text = COUNTER.ToString("00") + "%";
    }
    IEnumerator StartCounterFill()
    {
        yield return new WaitForSeconds(0.00015f);
        Debug.Log("FILlIng");
        COUNTER += Time.deltaTime * 10f;
        LevelSCR.fillAmount = COUNTER / 100f;

        LevelText.text = COUNTER.ToString("00") + "%";
    }
    

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("adsad13");
    //    if (collision.gameObject.name.Contains("enemy"))
    //    {
    //        Debug.Log("adsad13");
    //        if (collision.gameObject.name.Contains("enemyBullet"))
    //        {
    //            Debug.Log("adsad");
    //            ContactPoint2D contact = collision.contacts[0];
    //            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
    //            Vector3 pos = contact.point;
    //            Instantiate(explosionPrefab, pos, rot);
    //            //Destroy(gameObject);
    //        }
    //    }
    //}

}