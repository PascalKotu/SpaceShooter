using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {
	private float timePassed = 0f;

	// Use this for initialization
	void Start () {
		if((PlayerPrefs.GetInt("sound", 1) != 0))
			this.gameObject.GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime; 
		if (timePassed > 1 ) {
			timePassed = 0f;
			Destroy (this.gameObject);
		}	
	}
}
