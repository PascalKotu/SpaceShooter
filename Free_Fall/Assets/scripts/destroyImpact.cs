using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyImpact : MonoBehaviour {
	public float lifetime;
	// Use this for initialization
	void Start () {
		InvokeRepeating("destroy", lifetime, 100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void destroy(){
		Destroy(gameObject);
	}
}
