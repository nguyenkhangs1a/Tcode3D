using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    int coin ;
    static int  DataCoin;

    private void Awake()
    {
        coin = 0;

    }
    IEnumerator DeleyforFire()
    {
      this.Iscanfire = false;
      this.CreatBullet();
      SouceManager.ins.souceAudio();
      yield return new WaitForSeconds(0.5f);
      this.Iscanfire = true;
    }
    void Update()
    {
        
    }
    public override void fire()
    {
      if(this.Iscanfire)
      {
          StartCoroutine(DeleyforFire());
      }
    }
	


    public override bool hit(int dame)
    {
     int CurrenHealth =  this.UpdateHealth(dame);
     UI._ui.UpdateHealthBar(GetPercenHealth());
        if(CurrenHealth<=0  && !this.Isdead)
        {
            dead();
            return true;
        }
        return false;
    }
    public override void dead()
    {
        this.Isdead = true;
        Init.isGameover = true;
        UI._ui.ShowDead();

        //Save data
        
        if(coin>DataCoin)
        {
            DataCoin = coin; 
        }
        Database.ins.Coin = DataCoin;
        Database.ins.Name = UI._ui._Name.text;
        Database.ins.SaveData();

        Debug.Log("Coin=" + UI._ui._Name.text);
        //Debug.Log("DAtaCoin=" + DataCoin);
    }
    public override void startCharacter()
    {
        UI._ui.UpdateHealthBar(this.GetPercenHealth());
        if(coin>DataCoin)
        {
            DataCoin = coin; 
        }
        DataCoin = Database.ins.Coin;
       // UI._ui._Name.text = Database.ins.Name;
       // UI._ui.UpDataName(UI._ui._Name.text);
      //  Debug.Log("Name=" + Database.ins.Name);
    }
   
    public void increaseCoin(int amout=1)
    {
        this.coin += amout;
        UI._ui.UpdataCoin(this.coin);
        UI._ui.UpDataCoin(DataCoin);
        ////Debug.Log("Coin=" + coin);
        ////Debug.Log("DAtaCoin=" + DataCoin);
    }

}
