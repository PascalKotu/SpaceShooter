using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_shooting : MonoBehaviour {
	private float zeitVergange = 0f; 
	private float raytime = 0f;

	public bool ray;

	public float shootRate;
	public float rayrate;
	public GameObject schuss;
	// Use this for initialization
	void Start () {
		if (!ray) {
			InvokeRepeating ("shoot", 0, shootRate);
		} 
	}

	void shoot(){
		Vector2  weretospawn = new Vector2 (this.transform.position.x  , this.transform.position.y );
		Instantiate (schuss, weretospawn, transform.rotation);
	}
	// Update is called once per frame
	void Update () {
		if (ray) {
			if (zeitVergange == 0f) {
			
				shoot ();
				if (raytime > rayrate) {
					raytime = 0f;
					zeitVergange = 0f;
				}
			}
			raytime += Time.deltaTime;
			if (raytime > rayrate) {
			
				zeitVergange += Time.deltaTime;
				if (zeitVergange > shootRate) {
					zeitVergange = 0f;
					raytime = 0f;
				}
			}
		}
	}
}
