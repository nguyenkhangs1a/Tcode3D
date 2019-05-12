using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private Transform[] trans;
    [SerializeField]
    private Transform _taget;
    private float time;

    public static bool isGameover = false;
	// Use this for initialization
    IEnumerator Creatanddelay()
    {
        var timerand=Random.Range(2f,5f);
        yield return new WaitForSeconds(timerand);
        creatEnemy();
        StartCoroutine(Creatanddelay());
    }
    void creatEnemy()
    {
        int rand = Random.Range(0, trans.Length);
        GameObject objEnemy = Instantiate(obj, trans[rand].position, Quaternion.identity);
        Enemy e = objEnemy.GetComponent<Enemy>();
        if(e!=null)
        {
            e.settaget(_taget);
        }
    }
	void Start () {
            StartCoroutine(Creatanddelay());
            isGameover = false;
	}
	
	// Update is called once per frame
	void Update () {
        //init();
        time += Time.deltaTime;

	}
    
    void init()
    {
        if(time>5f)
        {
            var a = Random.Range(0, 3);
            {
                if (a == 0)
                {
                    Instantiate(obj, trans[0].position, Quaternion.identity);
                    time = 0;
                }
                if (a == 1)
                {
                    Instantiate(obj, trans[1].position, Quaternion.identity);
                    time = 0;
                }
                if (a == 2)
                {
                    Instantiate(obj, trans[2].position, Quaternion.identity);
                    time = 0;
                }
            }
        }
    }
}
