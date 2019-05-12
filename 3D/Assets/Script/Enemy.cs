using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : Character {
    private NavMeshAgent _nav;
    private Transform _tager;
	// Use this for initialization
    public override void startCharacter()
    {
        _nav = GetComponent<NavMeshAgent>();
        _nav.destination = _tager.position;
    }
	
	// Update is called once per frame
	void Update () {
        
       
            Vector3 origi = transform.position;
            Vector3 desti = _tager.position;
            float distan = Vector3.Distance(origi, desti);
            if (distan <= 1f)
            {
                _nav.velocity = Vector3.zero;
                //Destroy(gameObject,2f);
                fire();
            }
  
        
	}
    public void settaget(Transform taget)
    {
        this._tager = taget;
    }
    public override void fire()
    {
             if (this.Iscanfire)
        {
            StartCoroutine(DeleyforFire());
        }
        
    }
    IEnumerator DeleyforFire()
    {
        this.Iscanfire = false;
        CreatBullet();
        yield return new WaitForSeconds(2f);
        this.Iscanfire = true;
    }

    

    public override bool hit(int dame)
    {
        int CurrenHealth = this.UpdateHealth(dame);

        if (CurrenHealth <= 0 && !this.Isdead)
        {
            dead();
            return true;
        }
        //UI._ui.UpdateHealthBar(GetPercenHealth());
        return false;
    }
    public override void dead()
    {
        this.Isdead = true;
        CreatEffectWithTime(2);
        Destroy(gameObject);
    }

}
