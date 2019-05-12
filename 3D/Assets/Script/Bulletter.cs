using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletter : MonoBehaviour {
    public float _speed=300;
    private Rigidbody _rig;
    private bool isbullet;
    private Transform _transf;
    private bool canUpdate=true;

    private Character _parent;
	// Use this for initialization
	void Start () {
        _rig = GetComponent<Rigidbody>();
        _transf = this.transform;
       
	}
    IEnumerator DelayUpdate()
    {
        Vector3 v = _transf.forward * _speed * Time.deltaTime;
        _rig.velocity = v;
        canUpdate = false;
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(DelayUpdate());
        canUpdate = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(canUpdate)
        {
            StartCoroutine(DelayUpdate());
        }
	}
    private void OnTriggerEnter(Collider col)
    {
        string tag = col.gameObject.tag;
        GameObject obj = col.gameObject;
        if (tag == Constant.TAG_Player && _parent.isEnemy())          //đạn Enemy || Player //Đối tượng trúng đạn
        {
            Destroy(gameObject);   
            Player p= obj.GetComponent<Player>();               //hit Player
            p.hit(_parent.GetDame());           
        }
        if (tag == Constant.TAG_Enemy && _parent.isPlayer())
        {
            Destroy(gameObject); 
            Enemy e = obj.GetComponent<Enemy>();
            Player p = (Player)_parent;
            bool isdie=  e.hit(_parent.GetDame());
            if(isdie)
            {
                p.increaseCoin();
            }
            
        }
        if (tag == Constant.TAG_Wall)
        {
            Destroy(gameObject);
        }
    }

    public void SetParent(Character parent)
    {
        this._parent = parent;
    }
}
