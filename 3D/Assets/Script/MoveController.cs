using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class MoveController : MonoBehaviour {
    Player _player;
	// Use this for initialization
	void Start () {
        _player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        bool isjum = CrossPlatformInputManager.GetButtonDown("Jump");
        bool isfire = CrossPlatformInputManager.GetButtonDown("Fire");
        if (Init.isGameover)
        {
            return;
        }
		if(Input.GetKey(KeyCode.W) || v > 0.5f)
        {
            _player.movingForward();
        }
        else if(Input.GetKey(KeyCode.S)||v <-0.5f)
        {
            _player.moveback();
        }
        if(Input.GetKey(KeyCode.A)||h <- 0.5f)
        {
            _player.rotationleft();
        }
        else if (Input.GetKey(KeyCode.D) || h > 0.5f)
        {
            _player.rotationRight();
        }
        if(Input.GetKeyDown(KeyCode.Space) || isjum)
        {
            _player.jump();
        }
        if(Input.GetKeyDown(KeyCode.Keypad0) || isfire)
        {
            _player.fire();
        }
	}
}
