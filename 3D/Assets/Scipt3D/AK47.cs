using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : MonoBehaviour {
    public Vector3 _taget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        LookTaget();
	}
    void LookTaget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _taget = hit.point;
        }
        transform.LookAt(_taget);
    }
}
