using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class UI : MonoBehaviour {
    [SerializeField]
    private GameObject _UIdead;
    public static UI _ui;

    [SerializeField]
    private Image prosessHealthbar;

    [SerializeField]
    private Text _Coin;
    [SerializeField]
    private Text _DataCoin;
    [SerializeField]
    public  Text _Name;

    public GameObject data;
    void Awake()
    {
        if (_ui != null && _ui != this)             //tranh double OBJ
        {
            Destroy(this.gameObject);
            return;
        }
        _ui = this;
    }
    // Use this for initialization
    void Start()
    {
        UpDataCoin(Database.ins.Coin);
        UpDataName(Database.ins.Name);

        Debug.Log("NameData " + Database.ins.Name);
        
        //Textfile();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowDead()
    {
        _UIdead.SetActive(true);
    }

    public void UpdateHealthBar(float percent)
    {
        prosessHealthbar.fillAmount = percent;
    }
    public void UpDataCoin(int coin)
    {
        _DataCoin.text = FomatCoin(coin);
    }
    public void UpDataName(string name)
    {
        _Name.text = name;
    }
    public void UpdataCoin(int coin)
    {
        _Coin.text = FomatCoin(coin);
    }
    string FomatCoin(int coin)
    {
        string strCoin = "" + coin;
        if(strCoin.Length <= 1)
        {
            return "000" + strCoin;
        }
        else if (strCoin.Length <= 2)
        {
            return "00" + strCoin;
        }
        else if (strCoin.Length <= 3)
        {
            return "0" + strCoin;
        }
            return  strCoin;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
   void Textfile()
    {
        string path = Application.dataPath + "/Textfile.txt";
       if(!File.Exists(path))
       {
           File.WriteAllText(path, "Name:");
       }

           string content ="ABC="+_Name.text;
       if(Input.GetKeyDown(KeyCode.S))
       {
           File.AppendAllText(path, content);  
       }
          
   }
}
