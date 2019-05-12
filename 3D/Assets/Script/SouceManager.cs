using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouceManager : MonoBehaviour {
    public static SouceManager ins;
    AudioSource _audio;
   public AudioClip[] _souce;
	// Use this for initialization
	void Start () {
        _audio = GetComponent<AudioSource>();
	}
    private void Awake()
    {
        if(ins!=null && ins!=this)
        {
            Destroy(this.gameObject);
            return;
        }
        ins = this;
        DontDestroyOnLoad(ins);
    }
	public void  souceAudio()
    {
        _audio.PlayOneShot(_souce[0]);  
    }
	// Update is called once per frame
}
