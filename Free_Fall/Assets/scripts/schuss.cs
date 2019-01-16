using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schuss : MonoBehaviour {
	public float speed = 2f;
	public int damage;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		if((PlayerPrefs.GetInt("sound", 1) != 0))
			this.gameObject.GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate () {
			Vector2 boxMovement = new Vector2 (0, speed);
			transform.Translate (boxMovement*Time.deltaTime);
	}


	void OnTriggerEnter2D(Collider2D collision){
		if (collision.CompareTag ("enemy")) {
			collision.gameObject.GetComponent<Box_behaviour>().setLeben(damage);
			Vector2 weretospawn = new Vector2 (this.transform.position.x, this.transform.position.y);
			Instantiate (explosion, weretospawn, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

}
