using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box_behaviour : MonoBehaviour {
	public float speed = 2f;
	//public Transform pointOrigin;
	public bool fixedPosition = false;
	public GameObject explosion;

	private bool inScreen = false;

	public float maxleben = 1f;
	private float leben;
	public Image healthbar;

	private GameObject target;

	private Camera cam;
	private float cam_Height;
	private float cam_witdh;
	// Use this for initialization
	void Start () {
		leben = maxleben;
		target = GameObject.FindGameObjectWithTag("Player");

		cam = Camera.main;
		cam_Height = 2f *cam.orthographicSize;
		cam_witdh = cam_Height * cam.aspect;

	}
	void Update(){
		healthbar.fillAmount = leben / maxleben;
		if (leben < 1) {
			Kreis_Stuerung.scoreValue += (int)maxleben;
			Vector2 weretospawn = new Vector2 (this.transform.position.x, this.transform.position.y);
			Instantiate (explosion, weretospawn, Quaternion.identity);
			Destroy (this.gameObject);
		}

	}
	// Update is called once per frame
	void FixedUpdate () {
		if (fixedPosition) {
			if (transform.position.y > cam_Height / 4 ) {
				Vector2 boxMovement = new Vector2 (0, -speed);
				transform.Translate (boxMovement * Time.deltaTime);
			} else {
				if (transform.position.y <= cam_Height / 4 && inScreen ==false) { 
					inScreen = true;
					this.GetComponent<ai_shooting> ().enabled = true;
				}
				Vector2 dir = transform.position - target.transform.position;
				transform.up = dir;
			}
		} else {
			if (transform.position.y < cam_Height / 2 && inScreen ==false) {
				inScreen = true;
				this.GetComponent<ai_shooting> ().enabled = true;
			}
			Vector2 boxMovement = new Vector2 (0, -speed);
			transform.Translate (boxMovement * Time.deltaTime);
		}
	}

	public void setLeben(int damage){
		if (inScreen) {
			leben -= (float) damage;
		}
	}

	private void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
