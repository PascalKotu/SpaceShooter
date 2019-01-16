using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muteIt : MonoBehaviour {
	public AudioSource audi;
	// Use this for initialization
	void Start () {
		if(ScoreScript.musicIsEnabeld == false){
			audi.mute = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
