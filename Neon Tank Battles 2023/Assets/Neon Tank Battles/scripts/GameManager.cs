using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Title;
    public GameObject Dissolve;
    public Text[] Gold;
    public Text[] Money;
    int Goldno;
    int Moneyno;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("SetWalletFirstTime", 0);

        if (PlayerPrefs.GetInt("SetWalletFirstTime") == 0)
        {
            PlayerPrefs.DeleteAll();
            SetWalletFirstTime();
            PlayerPrefs.SetInt("SetWalletFirstTime", 123124);
        }
        CheckWalletOnStart();
    }
    private void Awake()
    {
        Application.targetFrameRate = 180;
    }
    // Update is called once per frame
    void Update()
    {

        

    }

    public void TapStart()
    {
       
        Dissolve.SetActive(true);
        Invoke("CloseDissolve", 2f);
        Invoke("CloseTitle", 0.5f);
    }
    void CloseDissolve()
    {
        Dissolve.SetActive(false);
    }

    void CloseTitle()
    {
        
        Title.SetActive(false);
    }

    void SetWalletFirstTime()
    {
        PlayerPrefs.SetInt("TotalMoney", 5000);
        PlayerPrefs.SetInt("TotalGold", 1);
    }
    public void CheckWalletOnStart()
    {
        Goldno = PlayerPrefs.GetInt("TotalGold");
        Moneyno = PlayerPrefs.GetInt("TotalMoney");

        for (int i = 0; i < Gold.Length; i++)
        {
            Gold[i].text = Goldno.ToString();
            Money[i].text = Moneyno.ToString();
        }
        
    }
}
