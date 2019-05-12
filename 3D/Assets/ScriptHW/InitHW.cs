using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitHW : MonoBehaviour {
    [SerializeField]
    private Transform PointEnemy;
    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private Transform taget;
	// Use this for initialization
	void Start () {
        StartCoroutine(CreatDelay());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator CreatDelay()
    {
        var rand = Random.Range(2f, 5f);
        yield return new WaitForSeconds(rand);
        CreatEnemy();
       StartCoroutine(CreatDelay());
    }
    void CreatEnemy()
    {
        GameObject obj = Instantiate(Enemy, PointEnemy.position, Quaternion.identity);
        EnemyHW e = obj.GetComponent<EnemyHW>();
        if(e!=null)
        {
            e.setTaget(taget);
        }
    }
}
