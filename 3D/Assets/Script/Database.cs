using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour {
    public static Database ins;
    private const string Key="1";
    private int _coin = 0;
    private string _name = "";

    private ItemOBJ _itemobj;
   // private ArrayItems _arrayItem;

    private const string Key_data = "dataJson";
   // private const string KeyArray_data = "dataArrayJson";
    private void Awake()
    {
        if (ins != null && ins != this)
        {
            Destroy(this.gameObject);
            return;
        }
        ins = this;
        DontDestroyOnLoad(ins);
        _coin = PlayerPrefs.GetInt(Key, 0);
        _name = PlayerPrefs.GetString(Key, "");

        _itemobj = JsonUtility.FromJson<ItemOBJ>(JsonData);
        if (_itemobj == null)
        {
            _itemobj = new ItemOBJ();
        }
    }
	// Use this for initialization
    public int Coin
    {
        get { return this._itemobj.coin; }
        set { _itemobj.coin = value; }
    }
    public string Name
    {
        get { return this._itemobj.name; }
        set { _itemobj.name = value; }
    }
	
	// Update is called once per frame
    void Start()
    {
        //_arrayItem=JsonUtility.FromJson<ArrayItems>(this.ArrayDataitem);
       //if(_arrayItem==null)     //creat item[10]
       //{
       //    _arrayItem = new ArrayItems();
       //    _arrayItem.CreateArrayObject();
       //}
        //save file
     //  string dataJson = JsonUtility.ToJson(_arrayItem);
      // this.ArrayDataitem = dataJson;
        //log file Json
      // Debug.Log(dataJson);
        
    }
	void Update () {
		
	}
    public string JsonData
    {
        get { return PlayerPrefs.GetString(Key_data, ""); }
        set { PlayerPrefs.SetString(Key_data, value); }
    }
    //public string    ArrayDataitem
    //{
    //    get { return PlayerPrefs.GetString(KeyArray_data, ""); }
    //    set { PlayerPrefs.SetString(Key_data, value); }
    //}

    public void SaveData()
    {
        string jsonData=JsonUtility.ToJson(_itemobj);
        this.JsonData = jsonData;
    }
    //private void OnApplicationQuit()
    //{
    //    SaveData();
    //}
}
