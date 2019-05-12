using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHW : MonoBehaviour {
    private Transform taget;
    private NavMeshAgent _nav;
	// Use this for initialization
	void Start () {
        _nav = GetComponent<NavMeshAgent>();
        _nav.destination = taget.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 origi = transform.position;
        Vector3 distan = taget.position;
        float disce = Vector3.Distance(origi, distan);
        Debug.Log("khoang cach="+ disce);
        if (disce <= 1f)
        {
            _nav.velocity = Vector3.zero;
        }
	}
   
    public void setTaget(Transform _taget)
    {
        this.taget = _taget;
    }
}
