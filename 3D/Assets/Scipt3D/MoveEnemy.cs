using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MoveEnemy : MonoBehaviour {
    [SerializeField]
    private Transform Player;
    private NavMeshAgent _nav;
	// Use this for initialization
	void Start () {
        _nav = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        _nav.SetDestination(Player.transform.position);
	}
}
